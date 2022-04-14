using ECommerce_Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Business.Services.Abstractions
{
    interface IPurchaseOrderService
    {
        public void AddPurchaseOrder(PurchaseOrder purchaseOrder);
        public List<PurchaseOrder> GetPurchaseOrders();
    }
}
