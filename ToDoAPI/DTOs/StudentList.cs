using System.ComponentModel.DataAnnotations;
using ToDoAPI.Models;

namespace ToDoAPI.DTOs
{
    public class StudentList
    {
        public int student_id { get; set; }
        public string first_name { get; set; } = null!;
        public string last_name { get; set; } = null!;
        public string email { get; set; }
        public DateTime date_of_birth { get; set; }
        public DateTime enrollment_date { get; set; }
        public string status { get; set; }
    }
}
