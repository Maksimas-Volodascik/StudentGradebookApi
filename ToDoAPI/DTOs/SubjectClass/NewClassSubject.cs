namespace ToDoAPI.DTOs.SubjectClass
{
    public class NewClassSubject
    {
        public string Academic_year { get; set; } = null!;
        public int Room { get; set; }
        public string Subject_name { get; set; } = null!;
        public string Subject_code { get; set; } = null!;
        public int Class_id { get; set; }
    }
}
