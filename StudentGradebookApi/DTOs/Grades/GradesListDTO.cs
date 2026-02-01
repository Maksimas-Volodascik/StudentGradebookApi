namespace StudentGradebookApi.DTOs.Grades
{
    public class GradesListDTO
    {
        public int Score { get; set; }
        public string Grade_Type { get; set; }
        public DateTimeOffset GradingDate { get; set; }
    }
}
