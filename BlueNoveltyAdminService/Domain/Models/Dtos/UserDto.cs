using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Domain.Models.Dtos
{
    public class UserDto
    {
        [Required]
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [Required]
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [Required]
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [DataMember(Name = "email")]
        public string Email { get; set; }

        [Required]
        [DataMember(Name = "password")]
        public string Password { get; set; }

        [DataMember(Name = "dateOfBirth")]
        public DateOnly? DateOfBirth { get; set; }

        [DataMember(Name = "prefferedLanguage")]
        public string? PrefferedLanguage { get; set; }
    }
}
