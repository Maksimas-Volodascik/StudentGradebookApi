namespace ToDoAPI.DTOs.Students
{
    public class NewStudent
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string First_name { get; set; } = null!;
        public string Last_name { get; set; } = null!;
        public DateTime Date_of_birth { get; set; }
    }
}
