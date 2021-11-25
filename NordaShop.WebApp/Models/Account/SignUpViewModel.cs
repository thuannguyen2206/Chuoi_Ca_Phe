using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Account
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(100, ErrorMessage = "Username too long")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Re-Password not match")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
