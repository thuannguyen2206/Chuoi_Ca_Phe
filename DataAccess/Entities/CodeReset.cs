using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class CodeReset : BaseModel
    {
        public int Code { get; set; }

        public string Email { get; set; }

        public DateTime ExpireTime { get; set; }

        public bool IsValid { get; set; }
    }
}
