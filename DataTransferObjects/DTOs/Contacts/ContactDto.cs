using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Contacts
{
    public class ContactDto
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public bool IsRead { get; set; }

    }
}
