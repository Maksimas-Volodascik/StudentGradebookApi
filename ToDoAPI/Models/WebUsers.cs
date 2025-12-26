using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class WebUsers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string Role { get; set; } = "demo";
        public Teachers Teachers { get; set; } = null!;
        public Students Students { get; set; } = null!;
    }
}
