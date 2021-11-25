using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Models.User
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string ShortMessage 
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Message) && this.Message.Length > 50)
                {
                    return string.Format("{0}...", this.Message.Substring(0, 50));
                }
                return this.Message;
            } 
        
        }

        public bool IsRead { get; set; }
    }
}
