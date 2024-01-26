using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaskTracker.Enums;

namespace TaskTracker.Models
{
    public class Project
    {
        public long Id { get; set; }
        [Required(ErrorMessage="Name of the project is required!")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Starting date of the project is required!")]

        public DateTime? StartDate { get; set; }
        public DateTime? CompletionDate { get; set;}
        [Required(ErrorMessage = "Status of the project is required!")]
        [Range(1, 5, ErrorMessage = "Priority must be between 0 and 2")]

        public ProjectStatus Status { get; set; }
        [Required(ErrorMessage = "Priority of the project is required!")]
        [Range(1, 5, ErrorMessage = "Priority must be between 1 and 5")]
        public int Priority { get; set; }
        [JsonIgnore]
        public ICollection<Task_>? Tasks { get; set; } = new List<Task_>();

    }
}
