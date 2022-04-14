using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Data.Entities
{
    public class Cart
    {
        public List<Product> ProductsInCart { get; set; }
        public DateTime AddedDate { get; set; }
        public string ClientName { get; set; }
    }
}
