namespace StudentGradebookApi.DTOs.Grades
{
    public class StudentGradesBySubjectDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ClassSubjectId { get; set; }
        public List<GradesListDTO> Grades { get; set; }
    }
}
