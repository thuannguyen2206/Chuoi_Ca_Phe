using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Account
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage ="Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
