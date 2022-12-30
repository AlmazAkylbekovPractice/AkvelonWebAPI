using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AkvelonWebAPI.EFCore;
using AkvelonWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AkvelonWebAPI.Controllers
{

    [Route("api/[controller]")]
    public class AkvelonAPIController : Controller
    {

        private readonly DatabaseHelper _dbHelper;
        public AkvelonAPIController(EFDataContext eFDataContext)
        {
            _dbHelper = new DatabaseHelper(eFDataContext);
        }

        // GET: api/<AkvelonAPIController>
        [HttpGet("projects")]
        public ActionResult<List<ProjectModel>> GetProjects()
        {
            try
            {
                return _dbHelper.GetProjects();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.ToString());
                // Return a server error response
                return StatusCode(500);
            }
        }

        [HttpGet("projects/{id}")]
        public ActionResult<ProjectModel> GetProjectById(int id)
        {
            // Validate the input
            if (id <= 0)
            {
                // Return a bad request response if the input is invalid
                return BadRequest();
            }

            try
            {
                var project = _dbHelper.GetProjectById(id);
                // Return the project if it was found
                if (project != null)
                {
                    return Ok(project);
                }
                // Return a not found response if the project was not found
                return NotFound();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.ToString());
                // Return a server error response
                return StatusCode(500);
            }
        }

        [HttpPost("projects")]
        public ActionResult CreateProject(ProjectModel projectModel)
        {
            // Validate the input
            if (projectModel == null || string.IsNullOrEmpty(projectModel.name))
            {
                // Return a bad request response if the input is invalid
                return BadRequest();
            }

            try
            {
                _dbHelper.CreateProject(projectModel);
                // Return a success response
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.ToString());
                // Return a server error response
                return StatusCode(500);
            }
        }

        [HttpPut("projects/{id}")]
        public ActionResult UpdateProject(int id, ProjectModel projectModel)
        {
            try
            {
                // Update the project using the DbHelper class
                _dbHelper.UpdateProject(id, projectModel);

                // Return a success response
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.ToString());
                // Return a server error response
                return StatusCode(500);
            }
        }

        [HttpDelete("projects/{id}")]
        public ActionResult DeleteProject(int id)
        {
            // Validate the input
            if (id <= 0)
            {
                // Return a bad request response if the input is invalid
                return BadRequest();
            }

            try
            {
                _dbHelper.DeleteProject(id);
                // Return a success response
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.ToString());
                // Return a server error response
                return StatusCode(500);
            }
        }
    }
}

