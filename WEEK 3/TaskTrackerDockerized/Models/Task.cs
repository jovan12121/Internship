using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaskTracker.Enums;

namespace TaskTracker.Models
{
    public class Task_
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Name of the task is required!")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Priority of the project is required!")]
        [Range(0, 2, ErrorMessage = "Priority must be between 1 and 5")]
        public TaskStatus_ Status { get; set; }
        [StringLength(1000, ErrorMessage = "Name cannot be longer than 1000 characters")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Priority of the task is required!")]
        [Range(1, 5, ErrorMessage = "Priority must be between 1 and 5")]
        public int Priority { get; set; }
        [JsonIgnore]
        public Project? Project { get; set; }
    }
}
