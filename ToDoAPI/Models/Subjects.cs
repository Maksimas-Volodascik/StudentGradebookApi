using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Subjects
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Must contain subject name!")]
        public string Subject_name { get; set; } = null!;
        [Required(ErrorMessage = "Must contain subject code!")]
        public string Subject_code { get; set; } = null!;
        public int Class_id { get; set; }
        public Classes Classes { get; set; } = null!;

    }
}
