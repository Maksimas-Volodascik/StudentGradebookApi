namespace StudentGradebookApi.DTOs.Enrollments
{
    public class StudentEnrollments
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int ClassId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
