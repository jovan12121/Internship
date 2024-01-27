using TaskTracker.Infrastructure;
using TaskTracker.Interfaces;
using TaskTracker.Models;
using TaskTracker.Repository;

namespace TaskTracker.Services
{
    public class TasksService : ITasksService
    {
        private readonly TaskTrackerRepository _repository;
        public TasksService(TaskTrackerContext dbContext)
        {
            _repository = new TaskTrackerRepository(dbContext);
        }

        public Task_ AddTask(Task_ task)
        {
            return _repository.AddTask(task);
        }

        public bool DeleteTask(long taskId)
        {
            return _repository.DeleteTask(taskId);
        }

        public Task_ EditTask(Task_ task)
        {
            return _repository.EditTask(task);
        }

        public List<Task_> GetAllTasks()
        {
            return _repository.GetAllTasks();
        }

        public Task_ GetTask(long taskId)
        {
            return _repository.GetTask(taskId);
        }
    }
}
