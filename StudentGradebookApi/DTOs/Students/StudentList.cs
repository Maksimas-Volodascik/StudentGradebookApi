using System.ComponentModel.DataAnnotations;
using StudentGradebookApi.Models;

namespace StudentGradebookApi.DTOs.Students
{
    public class StudentList
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTimeOffset DateOfBirth { get; set; }
        public DateTimeOffset EnrollmentDate { get; set; }
        public string ?Status { get; set; }
    }
}
