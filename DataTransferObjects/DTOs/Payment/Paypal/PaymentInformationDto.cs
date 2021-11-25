using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataTransferObjects.DTOs.Payment.Paypal
{
    public class PaymentInformationDto
    {
        public string id { get; set; } // id transaction

        public string intent { get; set; }

        public string state { get; set; }

        public string cart { get; set; }

        public Payer payer { get; set; }

        public DateTime create_time { get; set; }

        public DateTime update_time { get; set; }

        public List<Transaction> transactions { get; set; }

        public List<Link> links { get; set; }
    }

    public class Payer
    {

        public string payment_method { get; set; }

        public string status { get; set; }

        public object payer_info { get; set; }
    }

    public class Transaction
    {
        public Amount amount { get; set; }

        public string invoice_number { get; set; }

        public string description { get; set; }

        public ItemList item_list { get; set; }

        public Payee payee { get; set; }

        public List<RelatedResources> related_resources { get; set; }
    }

    public class Payee
    {
        public string merchant_id { get; set; }

        public string email { get; set; }
    }

    public class Amount
    {
        public string total { get; set; }

        public string currency { get; set; }

        public AmountDetail details { get; set; }
    }

    public class AmountDetail
    {
        public string shipping { get; set; }

        public string subtotal { get; set; }

        public string shipping_discount { get; set; }

        public string tax { get; set; }

        public string insurance { get; set; }

        public string handling_fee { get; set; }
    }

    public class ItemList
    {
        public List<Item> items { get; set; }

        public ShippingAddress shipping_address { get; set; }
    }

    public class Item
    {
        public string name { get; set; }

        public string currency { get; set; }

        public string quantity { get; set; }

        public string description { get; set; }

        public string sku { get; set; }

        public string price { get; set; }

        public string tax { get; set; }
    }

    public class ShippingAddress
    {
        public string recipient_name { get; set; }

        public string line1 { get; set; }

        public string line2 { get; set; }

        public string city { get; set; }

        public string country_code { get; set; }

        public string postal_code { get; set; }

        public string phone { get; set; }

        public string state { get; set; }
    }

    public class RelatedResources
    {
        public Sale sale { get; set; }
    }

    public class Sale
    {
        public string id { get; set; }

        public string state { get; set; }

        public Amount amount { get; set; }

        public object transaction_fee { get; set; }

        public string parent_payment { get; set; }

        public DateTime create_time { get; set; }

        public DateTime update_time { get; set; }

        public List<Link> links { get; set; }
    }


}
