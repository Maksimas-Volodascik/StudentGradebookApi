using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Subjects
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Must contain subject name!")]
        public string SubjectName { get; set; } = null!;
        [Required(ErrorMessage = "Must contain subject code!")]
        public string SubjectCode { get; set; } = null!;
        public int ClassId { get; set; }
        public Classes Classes { get; set; } = null!;

    }
}
