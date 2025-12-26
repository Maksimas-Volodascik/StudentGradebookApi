using System.ComponentModel.DataAnnotations;
using ToDoAPI.Models;

namespace ToDoAPI.DTOs.Students
{
    public class StudentList
    {
        public int Student_id { get; set; }
        public string First_name { get; set; } = null!;
        public string Last_name { get; set; } = null!;
        public DateTime Date_of_birth { get; set; }
        public DateTime Enrollment_date { get; set; }
        public string Status { get; set; }
    }
}
