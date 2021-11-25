using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Payment.Momo
{
    public class MomoCreatePaymentResponseDto
    {
        public string partnerCode { get; set; }

        public string requestId { get; set; }

        public string orderId { get; set; }

        public long amount { get; set; }

        public string responseTime { get; set; }

        public string message { get; set; }

        public string resultCode { get; set; }

        public string payUrl { get; set; }

        public string deeplink { get; set; }

        public string qrCodeUrl { get; set; }

        public string deeplinkWebInApp { get; set; }
    }
}
