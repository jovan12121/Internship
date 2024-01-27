using TaskTracker.Infrastructure;
using TaskTracker.Interfaces;
using TaskTracker.Models;
using TaskTracker.Repository;

namespace TaskTracker.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly TaskTrackerRepository _repository;
        public ProjectsService(TaskTrackerContext dbContext)
        {
            _repository = new TaskTrackerRepository(dbContext);
        }

        public Project AddProject(Project project)
        {
            return _repository.AddProject(project);
        }

        public bool AddTaskToProject(long projectId, long taskId)
        {
            Project requestedProject = _repository.GetProject(projectId);
            Task_ taskToAddToProject = _repository.GetTask(taskId);
            if (taskToAddToProject == null)
            {
                throw new Exception("Task with that ID doesn't exist.");
            }
            if (requestedProject == null)
            {
                throw new Exception("Project with that ID doesn't exist.");
            }
            if (requestedProject.Tasks != null)
            {
                requestedProject.Tasks.Add(taskToAddToProject);
            }
            else
            {
                requestedProject.Tasks.Add(taskToAddToProject);
            }
            taskToAddToProject.Project = requestedProject;
            _repository.EditTask(taskToAddToProject);
            _repository.EditProject(requestedProject);
            return true;
        }

        public bool DeleteProject(long projectId)
        {
            return _repository.DeleteProject(projectId);
        }

        public bool DeleteTaskFromProject(long projectId, long taskId)
        {
            Project requestedProject = _repository.GetProject(projectId);
            Task_ taskToDeleteFromProject = _repository.GetTask(taskId);
            if (taskToDeleteFromProject == null)
            {
                throw new Exception("Task with that ID doesn't exist.");
            }
            if (requestedProject == null)
            {
                throw new Exception("Project with that ID doesn't exist.");
            }
            if(requestedProject.Tasks != null && requestedProject.Tasks.Contains(taskToDeleteFromProject)) 
            {
                requestedProject.Tasks.Remove(taskToDeleteFromProject);
            }
            taskToDeleteFromProject.Project = null;
            _repository.EditTask(taskToDeleteFromProject);
            _repository.EditProject(requestedProject);
            return true;

        }

        public Project EditProject(Project project)
        {
            return _repository.EditProject(project);
        }

        public List<Project> GetAllProjects()
        {
            return _repository.GetAllProjects();
        }

        public List<Task_> GetAllTasksInProject(long projectId)
        { 
            Project requestedProject = _repository.GetProject(projectId);
            if (requestedProject == null)
            {
                throw new Exception("Project with that ID doesn't exist.");
            }
            List<Task_> AllTasks = _repository.GetAllTasks();
            List<Task_> retVal = AllTasks.Where(task => task.Project == requestedProject).ToList();
            return retVal;
        }

        public Project GetProject(long projectId)
        {
            return _repository.GetProject(projectId);
        }
    }
}
