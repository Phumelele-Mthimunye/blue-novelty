using AdminService.Enums;
using AdminService.Models.Dtos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace AdminService.Models.Entities
{
    [Table("User")]
    public class User : BaseEntity
    {
        [Column("Username")]
        public string Username { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Column("UserType")]
        public UserType UserType { get; set; }

        [Column("PasswordSalt")]
        public byte[] PasswordSalt { get; set; }

        [Column("PasswordHash")]
        public byte[] PasswordHash { get; set; }

        [Column("DateOfBirth")]
        public DateOnly? DateOfBirth { get; set; }

        [Column("PrefferedLanguage")]
        public string? PrefferedLanguage { get; set; }

        [Column("MainSkill")]
        public Skill? MainSkill { get; set; }

        public virtual List<Skill>? Skills { get; set; }

        public void ToEntity(UserDto request)
        {
            Active = true;
            Username = request.Username;
            FirstName = request.FirstName;
            LastName = request.LastName;
            UserType = request.UserType;
            PhoneNumber = request.PhoneNumber;
            Email = request.Email;
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
            };
        }

        public UserResponse ToDomain()
        {
            return new UserResponse()
            {
                Id = Id,
                Active = Active,
                Username = Username,
                FirstName = FirstName,
                LastName = LastName,
                UserType = UserType,
                PhoneNumber = PhoneNumber,
                Email = Email,
                DateOfBirth = DateOfBirth,
                PrefferedLanguage = PrefferedLanguage,
                MainSkill = MainSkill,        
            };
        }
    }
}
