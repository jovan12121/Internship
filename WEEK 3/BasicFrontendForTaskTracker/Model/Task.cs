namespace TaskTracker.Models
{
    public class Task_
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public TaskStatus Status { get; set; }
        public string? Description { get; set; }
        public int Priority { get; set; }
    }
}
