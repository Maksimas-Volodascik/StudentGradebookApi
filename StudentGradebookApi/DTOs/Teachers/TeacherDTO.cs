namespace StudentGradebookApi.DTOs.Teachers
{
    public class TeacherDTO
    {
        //DTO For 'Get Teacher' and 'Edit Teacher'
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;   
        public string LastName { get; set; } = string.Empty;
        public string? SubjectName { get; set; }
        public int? ClassSubjectId { get; set; }
    }
}
