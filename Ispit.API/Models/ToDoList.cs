using System.ComponentModel.DataAnnotations;

namespace Ispit.API.Models
{
    public class ToDoList
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool? IsComplited { get; set; } = false;


    }
}
