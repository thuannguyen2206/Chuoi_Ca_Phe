using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Contact
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name too long")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Email too long")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(200, ErrorMessage = "Subject too long")]
        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
