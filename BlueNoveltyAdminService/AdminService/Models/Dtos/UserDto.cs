﻿using AdminService.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AdminService.Models.Dtos
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
        [DataMember(Name = "userType")]
        public UserType UserType { get; set; }

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

        [Required]
        [DataMember(Name = "confirmPassword")]
        public string ConfirmPassword { get; set; }
    }
}
