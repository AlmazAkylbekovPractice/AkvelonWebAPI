using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AkvelonWebAPI.Database;
using AkvelonWebAPI.EFCore;
using AkvelonWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AkvelonWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly TaskRepository _taskRepository;

        public TasksController(DatabaseContext eFDataContext)
        {
            _taskRepository = new TaskRepository(eFDataContext);
        }

        [HttpGet("/tasks")]
        public ActionResult<List<TaskDto>> GetTasks()
        {
            try
            {
                return _taskRepository.GetTasks();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // Return a server error response
                return StatusCode(500);
            }
        }

        [HttpGet("task/{id}")]
        public ActionResult<TaskDto> GetTaskById(int id)
        {
            try
            {
                var project = _taskRepository.GetTaskById(id);
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

        [HttpPost("/projects/{id}/task")]
        public ActionResult CreateTask(int projectId, TaskDto taskDto)
        {
            try
            {
                _taskRepository.CreateTask(taskDto,projectId);
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


        [HttpPut("task/{id}")]
        public ActionResult UpdateTask(int id, TaskDto taskDto)
        {
            try
            {
                _taskRepository.UpdateTask(id, taskDto);
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

        [HttpDelete("task/{id}")]
        public ActionResult DeleteTask(int id)
        {
            try
            {
                _taskRepository.DeleteTask(id);
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

