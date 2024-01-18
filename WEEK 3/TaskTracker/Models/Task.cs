using TaskTracker.Enums;

namespace TaskTracker.Models
{
    public class Task_
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public TaskStatus_ Status { get; set; }
        public string? Description { get; set; }
        public int Priority { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
