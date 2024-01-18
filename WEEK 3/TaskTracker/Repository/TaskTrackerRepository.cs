using TaskTracker.Infrastructure;
using TaskTracker.Interfaces;
using TaskTracker.Models;

namespace TaskTracker.Repository
{
    public class TaskTrackerRepository : ITaskTrackerRepository
    {
        private readonly TaskTrackerContext dbContext;
        public TaskTrackerRepository(TaskTrackerContext context)
        {
            dbContext = context;
        }

        public Project AddProject(Project project)
        {
            Project returnVal = dbContext.Projects.Add(project).Entity;
            dbContext.SaveChanges();
            return returnVal;
        }

        public Task_ AddTask(Task_ task)
        {
            Task_ retVal = dbContext.Tasks.Add(task).Entity;
            dbContext.SaveChanges();
            return retVal;
        }

        public bool DeleteProject(long projectId)
        {
            Project projectToDelete = dbContext.Projects.First(project => project.Id == projectId);
            if(projectToDelete == null)
            {
                throw new Exception("project with that id doesn't exist");
            }
            else
            {
                dbContext.Projects.Remove(projectToDelete);
                dbContext.SaveChanges();
                return true;
            }
        }

        public bool DeleteTask(long taskId)
        {
            Task_ taskToDelete = dbContext.Tasks.First(task => task.Id == taskId);
            if (taskToDelete == null)
            {
                throw new Exception("project with that id doesn't exist");
            }
            else
            {
                dbContext.Tasks.Remove(taskToDelete);
                dbContext.SaveChanges();
                return true;
            }
        }

        public Project EditProject(Project project)
        {
            return dbContext.Projects.Update(project).Entity;
        }

        public Task_ EditTask(Task_ task)
        {
            Task_ retVal = dbContext.Tasks.Update(task).Entity;
            dbContext.SaveChanges();
            return retVal;
        }

        public List<Project> GetAllProjects()
        {
            return dbContext.Projects.ToList();
        }

        public List<Task_> GetAllTasks()
        {
            return dbContext.Tasks.ToList();
        }

        public Project GetProject(long projectId)
        {
            Project projectById = dbContext.Projects.First(project => project.Id == projectId);
            if (projectById == null)
            {
                throw new Exception("project with that id doesn't exist");
            }
            else
            {
                return projectById;
            }
        }

        public Task_ GetTask(long taskId)
        {
            Task_ taskById = dbContext.Tasks.First(task => task.Id == taskId);
            if (taskById == null)
            {
                throw new Exception("task with that id doesn't exist");
            }
            else
            {
                return taskById;
            }
        }
    }
}
