namespace ToDoAPI.DTOs.Students
{
    public class EditStudent
    {
        public string First_name { get; set; } = null!;
        public string Last_name { get; set; } = null!;
        public DateTime Date_of_birth { get; set; }
    }
}
