using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class BaseModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
