using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Interfaces;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _projectsService;
        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }
        [HttpGet("getProject/{id}")]
        public ActionResult GetProject(long id)
        {
            try
            {
                return Ok(_projectsService.GetProject(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("addProject")]
        public ActionResult AddProject(Project project)
        {
            try
            {
                return Ok(_projectsService.AddProject(project));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("editProject")]
        public ActionResult EditProject(Project project)
        {
            try
            {
                return Ok(_projectsService.EditProject(project));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("deleteProject/{id}")]
        public ActionResult DeleteProject(long id)
        {
            try
            {
                return Ok(_projectsService.DeleteProject(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("getAllProjects")]
        public ActionResult GetAllProject()
        {
            try
            {
                return Ok(_projectsService.GetAllProjects());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("addTaskToProject")]
        public ActionResult AddTaskToProject(long projectId,long taskId)
        {
            try
            {
                return Ok(_projectsService.AddTaskToProject(projectId,taskId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("deleteTaskFromProject")]
        public ActionResult DeleteTaskFromProject(long projectId, long taskId)
        {
            try
            {
                return Ok(_projectsService.DeleteTaskFromProject(projectId, taskId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("getTasksInProject")]
        public ActionResult GetTasksInProject(long projectId)
        {
            try
            {
                return Ok(_projectsService.GetAllTasksInProject(projectId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
