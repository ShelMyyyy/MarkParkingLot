using System.ComponentModel.DataAnnotations;

namespace ParkingLot.Models.DataBaseModels
{
    public class SysUsers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string PasswordHash { get; set; } = string.Empty;  // ´æ¹þÏ£Öµ

        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
