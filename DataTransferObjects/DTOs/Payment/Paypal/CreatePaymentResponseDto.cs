using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DataTransferObjects.DTOs.Payment.Paypal
{
    public class CreatePaymentResponseDto
    {
        public string Ii { get; set; }

        public string intent { get; set; }

        public string state { get; set; }

        public DateTime create_time { get; set; }

        public List<Link> links { get; set; }

        public object transactions { get; set; }
    }

    public class Link
    {
        public string href { get; set; }

        public string rel { get; set; }

        public string method { get; set; }
    }


}
