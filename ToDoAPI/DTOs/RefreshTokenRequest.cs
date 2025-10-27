namespace ToDoAPI.DTOs
{
    public class RefreshTokenRequest
    {
        public int StudentID { get; set; }
        public required string RefreshToken { get; set; }   
    }
}
