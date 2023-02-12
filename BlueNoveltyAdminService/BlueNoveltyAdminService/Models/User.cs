using System.ComponentModel.DataAnnotations;

namespace BlueNoveltyAdminService.Models
{
    public class User
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
    }
}
