using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Payment.Paypal
{
    public class ExcutePaymentResponseDto
    {
        public string id { get; set; }

        public string intent { get; set; }

        public string state { get; set; }

        public string statusCode { get; set; }

        public DateTime create_time { get; set; }

        public DateTime update_time { get; set; }

        public List<Link> links { get; set; }

        public object transactions { get; set; }

        public object payer { get; set; }

    }

}
