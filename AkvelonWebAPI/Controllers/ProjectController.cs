using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AkvelonWebAPI.EFCore;
using AkvelonWebAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace AkvelonWebAPI.Controllers
{

    [Route("api/[controller]")]
    public class ProjectController : Controller
    {

        private readonly ProjectRepository _projectRepository;

        public ProjectController(DatabaseContext eFDataContext)
        {
            _projectRepository = new ProjectRepository(eFDataContext);
        }

        [HttpGet("/projects")]
        public ActionResult<List<ProjectDto>> GetProjects()
        {
            try
            {
                return _projectRepository.GetProjects();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // Return a server error response
                return StatusCode(500);
            }
        }

        [HttpGet("project/{id}")]
        public ActionResult<ProjectDto> GetProjectById(int id)
        {
            try
            {
                var project = _projectRepository.GetProjectById(id);
                return Ok(project);
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500);
            }
        }

        [HttpPost("/project")]
        public ActionResult CreateProject(ProjectDto projectDto)
        {
            try
            {
                _projectRepository.CreateProject(projectDto);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500);
            }
        }

        [HttpPut("project/{id}")]
        public ActionResult UpdateProject(int id, ProjectDto projectDto)
        {
            try
            {
                _projectRepository.UpdateProject(id, projectDto);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500);
            }
        }

        [HttpDelete("project/{id}")]
        public ActionResult DeleteProject(int id)
        {
            try
            {
                _projectRepository.DeleteProject(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500);
            }
        }
    }
}

