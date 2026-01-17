namespace ToDoAPI.DTOs.SubjectClass
{
    public class NewClassSubject
    {
        public string AcademicYear { get; set; } = null!;
        public int Room { get; set; }
        public string SubjectName { get; set; } = null!;
        public string SubjectCode { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
    }
}
