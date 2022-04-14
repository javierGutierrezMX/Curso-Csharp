using ECommerce_Business.Services.Abstractions;
using ECommerce_Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Business.Services.Implementations
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        public static Random rnd = new Random();
        public static List<Product> list = new List<Product> {

        new Product(rnd.Next(1, 8), "product" + rnd.Next(1, 8).ToString(),(decimal) rnd.Next(1000, 1999), "test product", "testBrand1", "123abc",rnd.Next(0, 100)),
        new Product(rnd.Next(1, 8), "product" + rnd.Next(1, 8).ToString(),(decimal) rnd.Next(1000, 1999), "test product" + rnd.Next(5, 25).ToString(), "testBrand1", "123abc",rnd.Next(0, 100)),
        new Product(rnd.Next(1, 8), "product" + rnd.Next(1, 8).ToString(),(decimal) rnd.Next(1000, 1999), "test product" + rnd.Next(5, 25).ToString(), "testBrand1", "123abc",rnd.Next(0, 100)),
        new Product(rnd.Next(1, 8), "product" + rnd.Next(1, 8).ToString(),(decimal) rnd.Next(1000, 1999), "test product" + rnd.Next(5, 25).ToString(), "testBrand1", "123abc",rnd.Next(0, 100))
        };
        private List<PurchaseOrder> _purchaseOrders = new List<PurchaseOrder>()
        {
            new PurchaseOrder(new Provider(rnd.Next(2, 10),"Levis","ejemplo@ejemplo.com"), list, DateTime.Now.AddDays(rnd.Next(0, 15))),
            new PurchaseOrder(new Provider(rnd.Next(2, 10),"Levis" + rnd.Next(0, 2).ToString(),"ejemplo@ejemplo.com"), list, DateTime.Now.AddDays(rnd.Next(0, 15))),
            new PurchaseOrder(new Provider(rnd.Next(2, 10),"Levis" + rnd.Next(0, 2).ToString(),"ejemplo@ejemplo.com"), list, DateTime.Now.AddDays(rnd.Next(0, 15)))
        };
        public void AddPurchaseOrder(PurchaseOrder purchaseOrder) => _purchaseOrders.Add(purchaseOrder);
        public List<PurchaseOrder> GetPurchaseOrders() =>  _purchaseOrders;
    }
}
