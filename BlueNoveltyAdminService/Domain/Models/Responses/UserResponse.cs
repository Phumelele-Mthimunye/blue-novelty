using Domain.Enums;
using Domain.Models.Responses;
using System.Runtime.Serialization;

namespace Domain.Models.Dtos
{
    public class UserResponse : ResponseBase
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "dateOfBirth")]
        public DateOnly? DateOfBirth { get; set; }

        [DataMember(Name = "prefferedLanguage")]
        public string? PrefferedLanguage { get; set; }

        [DataMember(Name = "token")]
        public string Token { get; set; }
    }
}
