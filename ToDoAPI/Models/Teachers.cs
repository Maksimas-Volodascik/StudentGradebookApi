using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Teachers
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required!")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Last name is required!")]
        public string LastName { get; set; } = null!;
        public int UserID { get; set; } //FK
        public WebUsers User { get; set; } = null!;
        public List<ClassSubjects> ClassSubjects { get; set; }
    }
}
