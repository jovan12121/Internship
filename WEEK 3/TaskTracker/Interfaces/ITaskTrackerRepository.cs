using TaskTracker.Models;

namespace TaskTracker.Interfaces
{
    public interface ITaskTrackerRepository
    {
        Project AddProject(Project project);
        Task_ AddTask(Task_ task);
        List<Task_> GetAllTasks();
        bool DeleteTask(long taskId);
        Task_ GetTask(long taskId);
        Task_ EditTask(Task_ task);
        List<Project> GetAllProjects();
        Project GetProject(long projectId);
        bool DeleteProject(long projectId);
        Project EditProject(Project project);
        User FindUserByUsername(string username);
        User Register(User user);
    }
}
