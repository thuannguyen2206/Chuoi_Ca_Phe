using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class TokenConfirm : BaseModel
    {
        public string Token { get; set; }

        public string Email { get; set; }

        public DateTime ExpireTime { get; set; }

        public bool IsValid { get; set; }
    }
}
