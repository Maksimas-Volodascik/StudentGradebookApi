namespace ToDoAPI.DTOs.Students
{
    public class NewStudent
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string First_name { get; set; } = null!;
        public string Last_name { get; set; } = null!;
        public DateTime Date_of_birth { get; set; }
    }
}
