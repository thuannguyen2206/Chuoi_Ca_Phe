using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.QRCode
{
    public class OrderQrCode
    {
        public string Customer { get; set; }

        public Guid OrderCode { get; set; }

        public string Website { get; set; }
    }
}
