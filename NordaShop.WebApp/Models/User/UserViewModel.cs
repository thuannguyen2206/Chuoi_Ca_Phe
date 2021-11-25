using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.User
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [MaxLength(100, ErrorMessage = "Username too long")]
        public string Username { get; set; }

        public string Email { get; set; }

        [MaxLength(20, ErrorMessage = "Phone number too long")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [MaxLength(200, ErrorMessage ="Address too long")]
        public string Address { get; set; }

        [MaxLength(100, ErrorMessage ="First name too long")]
        public string FirstName { get; set; }

        [MaxLength(100, ErrorMessage = "Last name too long")]
        public string LastName { get; set; }

        public string AvatarLink { get; set; }

        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Confirm password not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

}
