using ECommerce_Business.Services.Abstractions;
using ECommerce_Data.Entities;
using ECommerce_Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce_Business.Services.Implementations
{
    public class ReportServices : IReportServices
    {
        public List<string> FiveOrLessInStock(List<Product> list)
        {
            return list.Where(p => p.Stock <= 5).Select(p => $"Product : {p.Name} Current Stock : {p.Stock}").ToList();
        }

        public List<string> OrderedByBrand(List<Product> list)
        {
            return list.OrderByDescending(p => p.Brand).Select(p => $"Brand : {p.Brand} Product : {p.Name} ").ToList();
        }

        public List<string> OrderedByDepartment(List<Product> list)
        {
            var result = new List<string>();
            list.GroupBy(x => new { dep = x.Subdepartment.Department.Name, subd = x.Subdepartment.Name })
            .Select(p => p.Select(x => $"Department : {p.Key.dep} Subdepartment : {p.Key.subd} Product : {x.Name}").ToList()).ToList()
            .ForEach(g => g.ForEach(s => result.Add(s)));
            return result;
        }

        public string POBestProduct(List<PurchaseOrder> list)
        {
            var result = list.SelectMany(po => po.PurchaseProducts).GroupBy(p => p.Name)
                .Select(p => new
                {
                    BestProdcut = p.Key,
                    TotalUnits = p.Sum(x => x.Stock)
                }).OrderByDescending(x => x.TotalUnits).FirstOrDefault();
            return $"Prod : {result.BestProdcut} total : {result.TotalUnits}";
        }

        public List<string> POChair(List<PurchaseOrder> list)
        {
            return list.Where(po => po.PurchaseProducts.Any(p => p.Name == "Chair"))
                .Select(po => $"PO id: {po.Id} Provider : {po.Provider.Name}").ToList();
        }

        public List<string> POpendingOfLevis(List<PurchaseOrder> list)
        {
            return list.Where(po => po.Status == PurchaseOrderStatus.Pending && po.Provider.Name == "Levis")
                .Select(x => $"Id : {x.Id} provider :{x.Provider.Name}").ToList();
        }

        public List<string> POStatusPaidLast7days(List<PurchaseOrder> list)
        {
            return list.Where(po => po.PurchaseDate >= DateTime.Now.AddDays(-7) && po.Status == PurchaseOrderStatus.Paid).Select(x => $"Id : {x.Id} provider :{x.Provider.Name}").ToList();
        }

        public List<string> Top5Expensive(List<Product> list)
        {
            return list.OrderByDescending(p => p.Price).Take(5).Select(p => $"Product : {p.Name} Price : {p.Price}").ToList();
        }
    }
}
