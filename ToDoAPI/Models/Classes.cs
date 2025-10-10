using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Classes
    {
        [Key]
        public int class_id { get; set; }
        public DateTime academic_year { get; set; }
        public int room {  get; set; }
        public Teachers teachers { get; set; } = null!;
        public Subjects subjects { get; set; } = null!;
        public List<Enrollments> enrollments { get; set; } = new(); //each class has many student enrollments
    }
}
