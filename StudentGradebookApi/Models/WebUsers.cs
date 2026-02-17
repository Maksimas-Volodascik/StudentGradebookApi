using System.ComponentModel.DataAnnotations;

namespace StudentGradebookApi.Models
{
    public class WebUsers
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string Role { get; set; } = "demo";
        public Teachers Teachers { get; set; } = null!;
        public Students Students { get; set; } = null!;
    }
}
