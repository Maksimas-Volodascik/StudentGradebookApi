using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Classes
    {
        [Key]
        public int Id { get; set; }
        public string Academic_year { get; set; }
        [Required(ErrorMessage = "Must pick a room!")]
        public int Room {  get; set; }
        public Teachers Teachers { get; set; } = null!;
        public Subjects Subjects { get; set; } = null!;
        public List<Enrollments> Enrollments { get; set; } = new(); //each class has many student enrollments
    }
}
