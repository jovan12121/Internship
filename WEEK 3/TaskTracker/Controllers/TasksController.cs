using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Interfaces;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _taskService;
        public TasksController(ITasksService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet("getTask")]
        [Authorize(Roles = "user")]
        public ActionResult GetTask(long id)
        {
            try
            {
                return Ok(_taskService.GetTask(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("getAllTasks")]
        [Authorize(Roles = "user")]

        public ActionResult GetAllTasks()
        {
            try
            {
                return Ok(_taskService.GetAllTasks());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("deleteTask/{id}")]
        [Authorize(Roles = "user")]

        public ActionResult DeleteTask(long id)
        {
            try
            {
                return Ok(_taskService.DeleteTask(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("editTask")]
        [Authorize(Roles = "user")]

        public ActionResult EditTask(Task_ task)
        {
            try
            {
                return Ok(_taskService.EditTask(task));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("addTask")]
        [Authorize(Roles = "user")]

        public ActionResult AddTask(Task_ task)
        {
            try
            {
                return Ok(_taskService.AddTask(task));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
