using TaskTracker.Models;

namespace TaskTracker.Interfaces
{
    public interface IProjectsService
    {
        Project AddProject(Project project);
        Project EditProject(Project project);
        bool DeleteProject(long projectId);
        Project GetProject(long projectId);
        List<Project> GetAllProjects();
        bool AddTaskToProject(long projectId, long taskId);
        bool DeleteTaskFromProject(long projectId, long taskId);
        List<Task_> GetAllTasksInProject(long projectId);

    }
}
