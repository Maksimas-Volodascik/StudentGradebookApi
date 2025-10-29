using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Students
    {
        [Key]
        public int student_id { get; set; }

        [Required]
        [MaxLength(100)]
        public string first_name { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string last_name { get; set; } = null!;
        [Required]
        public string email { get; set; }
        [Required]
        public string passwordHash { get; set; }
        public DateTime date_of_birth { get; set; }
        public DateTime enrollment_date { get; set; }
        public string status { get; set; } = "Enrolled";
        public string role { get; set; } = string.Empty;
        public string? refreshToken { get; set; }
        public DateTime? refreshTokenExpiryTime { get; set; }
        public List<Enrollments> enrollments { get; set; } = new();  //student can enroll in many classes
    }
}
