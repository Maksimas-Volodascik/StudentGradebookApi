using System.ComponentModel.DataAnnotations;
using ToDoAPI.Models;

namespace ToDoAPI.DTOs.Students
{
    public class StudentList
    {
        public int Id { get; set; }
        public string First_name { get; set; } = null!;
        public string Last_name { get; set; } = null!;
        public DateTimeOffset Date_of_birth { get; set; }
        public DateTimeOffset Enrollment_date { get; set; }
        public string Status { get; set; }
    }
}
