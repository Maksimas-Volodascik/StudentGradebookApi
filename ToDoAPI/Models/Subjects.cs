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
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        public ICollection<ClassSubjects> ClassSubjects { get; set; }

    }
}
