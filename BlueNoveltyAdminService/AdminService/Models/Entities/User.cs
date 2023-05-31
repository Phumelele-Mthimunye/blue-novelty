using AdminService.Enums;
using AdminService.Models.Dtos;
using AdminService.SharedServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminService.Models.Entities
{
    [Table("User")]
    public class User : IEntityFrameworkObjectId<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public UserType UserType { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? PrefferedLanguage { get; set; }
        public Skill? MainSkill { get; set; }

        public virtual List<Skill>? Skills { get; set; }

        public void ToEntity(UserDto request)
        {
            
        }
    }
}
