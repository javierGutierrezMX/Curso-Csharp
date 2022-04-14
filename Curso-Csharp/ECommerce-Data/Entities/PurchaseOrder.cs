using ECommerce_Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce_Data.Entities
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Provider Provider { get; set; }
        public List<Product> PurchaseProducts { get; set; }
        public PurchaseOrderStatus Status { get; set; }

        public PurchaseOrder(Provider provider, List<Product> listP, DateTime? purchasedate = null )
        {
            Random rnd = new Random();
            Id = rnd.Next(1, 999);
            Total = listP.Sum(x => x.Price);
            Provider = provider == null ? throw new InvalidOperationException(" problem with  \"provider\"") : provider;
            PurchaseProducts = listP == null ? throw new InvalidOperationException(" problem with  \"listP\"") : listP;
            PurchaseDate = purchasedate?? DateTime.Now;
            Status = PurchaseOrderStatus.Pending;
        }
    }
}
