using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Data.Entities
{
    public class SellOrder
    {
        public DateTime SellDate { get; set; }
        public decimal TotalBill { get; set; }
        public Cart Cart { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public string ClientName { get; set; }
    }
}
