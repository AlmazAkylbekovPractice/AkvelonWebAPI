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
            return _dbHelper.GetProjects();
        }

        [HttpPost("projects")]
        public void CreateProject(ProjectModel projectModel)
        {
            _dbHelper.CreateProject(projectModel);
        }
    }
}

