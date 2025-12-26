namespace ToDoAPI.DTOs.Users
{
    public class RefreshTokenRequest
    {
        public int UserID { get; set; }
        public required string RefreshToken { get; set; }   
    }
}
