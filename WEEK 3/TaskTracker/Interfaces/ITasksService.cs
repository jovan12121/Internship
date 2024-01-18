using TaskTracker.Models;

namespace TaskTracker.Interfaces
{
    public interface ITasksService
    {
        Task_ GetTask(long taskId);
        List<Task_> GetAllTasks();
        bool DeleteTask(long taskId);
        Task_ EditTask(Task_ task);
        Task_ AddTask(Task_ task);
    }
}
