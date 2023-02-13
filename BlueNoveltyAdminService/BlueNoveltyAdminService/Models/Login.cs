﻿using System.ComponentModel.DataAnnotations;

namespace BlueNoveltyAdminService.Models
{
    public class Login
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
