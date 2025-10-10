using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Subjects
    {
        [Key]
        public int subject_id { get; set; }
        [Required(ErrorMessage = "Must contain subject name!")]
        public string subject_name { get; set; } = null!;
        [Required(ErrorMessage = "Must contain subject code!")]
        public string subject_code { get; set; } = null!;
        public int class_id { get; set; }
        public Classes classes { get; set; } = null!;

    }
}
