using Domain.Enums;
using Domain.Models.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Models.Entities
{
    [Table("Customers")]
    public class Customer : BaseEntity
    {
        [Required]
        [Column("Username")]
        public string? Username { get; set; }

        [Required]
        [Column("FirstName")]
        public string? FirstName { get; set; }

        [Required]
        [Column("LastName")]
        public string? LastName { get; set; }

        [Required]
        [Column("Email")]
        public string? Email { get; set; }

        [Required]
        [Column("PhoneNumber")]
        public string? PhoneNumber { get; set; }

        [Required]
        [Column("PasswordSalt")]
        public byte[]? PasswordSalt { get; set; }

        [Required]
        [Column("PasswordHash")]
        public byte[]? PasswordHash { get; set; }

        public virtual List<CleaningRequest>? CleaningRequests { get; set; }

        public void ToEntity(UserDto request)
        {
            Active = true;
            Username = request.Username;
            FirstName = request.FirstName;
            LastName = request.LastName;
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
                PhoneNumber = PhoneNumber,
                Email = Email,
            };
        }
    }
}
