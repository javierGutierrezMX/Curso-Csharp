using ECommerce_Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Business.Services.Abstractions
{
    interface IReportServices
    {
        public List<string> Top5Expensive(List<Product> list);
        public List<string> FiveOrLessInStock(List<Product> list);
        public List<string> OrderedByBrand(List<Product> list);
        public List<string> OrderedByDepartment(List<Product> list);
        public List<string> POStatusPaidLast7days(List<PurchaseOrder> list);
        public List<string> POChair(List<PurchaseOrder> list);
        public List<string> POpendingOfLevis(List<PurchaseOrder> list);
        public string POBestProduct(List<PurchaseOrder> list);
    }
}
