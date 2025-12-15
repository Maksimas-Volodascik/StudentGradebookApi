using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Teachers
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required!")]
        public string First_name { get; set; } = null!;
        [Required(ErrorMessage = "Last name is required!")]
        public string Last_name { get; set; } = null!;
        public int Class_id { get; set; }
        public Classes Classes { get; set; } = null!;
        public WebUsers User { get; set; } = null!;
    }
}
