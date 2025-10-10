using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Teachers
    {
        [Key]
        public int teacher_id { get; set; }
        public string first_name { get; set; } = null!;
        public string last_name { get; set; } = null!;
        public string email { get; set; }
        public int class_id { get; set; }
        public Classes classes { get; set; } = null!;

    }
}
