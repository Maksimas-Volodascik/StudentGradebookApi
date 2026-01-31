namespace StudentGradebookApi.DTOs.Grades
{
    public class StudentGradesBySubjectDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Score { get; set; }
        public DateTimeOffset GradingDate { get; set; }
        public string Grade_Type { get; set; }
        public int ClassSubjectId { get; set; }
    }
}
