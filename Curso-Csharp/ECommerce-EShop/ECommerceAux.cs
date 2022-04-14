using ECommerce_Business.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using System.Globalization;
using ECommerce_Data.Entities;
using ConsoleTables;
using ECommerce_Business;

namespace LinQ_ECommerceEjemplo
{
    public partial class ECommerceConsole
    {
        public void ListProducts(List<Product> list = null)
        {
            try
            {
                Clear();
                var products = list == null ? _productServices.GetProducts() : list;
                var tempd = _depServices.GetDepartments().Find(d => d.Name == "Home");
                var tempSubD = _depServices.GetSubdepartments(tempd).FirstOrDefault(sb => sb.Name == "Tables");
                products.Where(p => p.Subdepartment == null).ToList().ForEach(p => p.AddSubd(tempSubD));
                var table = new ConsoleTable("Id", "Producto", "Precio", "Marca", "Stock", "Department", "SubDepartment");
                products.ForEach(p => table.AddRow(p.Id, p.Name, p.Price, p.Brand, p.Stock, p.Subdepartment.Department.Name, p.Subdepartment.Name));
                WriteLine(table);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                throw;
            }
        }
        public void ListDepartments()
        {
            try
            {
                var deps = _depServices.GetDepartments();
                deps.ForEach(p => WriteLine($"Name : {p.Name} "));
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                throw;
            }
        }
        public void ListSubdepartments(string depName)
        {
            try
            {
                var selectDep = _depServices.GetDepartments().Find(d => d.Name == depName);
                var subDeps = _depServices.GetSubdepartments(selectDep);
                subDeps.ForEach(p => WriteLine($"Subdepartment : {p.Name} "));
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                throw;
            }
        }
        public List<Product> ListOfSelectedProducts(bool isSell = false)
        {
            var band = true;
            var products = new List<Product>();
            do
            {
                Clear();
                ListProducts();
                WriteLine("Product id : ");
                Int32.TryParse(ReadLine(), out int productId);
                WriteLine("Amount : ");
                Int32.TryParse(ReadLine(), out int productAmount);
                var tP = isSell ?
                    _productServices.GetProduct(productId).Stock >= productAmount ? _productServices.GetProduct(productId) : null
                    :
                    products.Contains(_productServices.GetProduct(productId)) ? 
                    null
                    :
                    _productServices.GetProduct(productId);
                if (tP != null)
                {
                    var productAdd = new Product(tP.Id, tP.Name, tP.Price, tP.Description, tP.Brand, tP.Sku, productAmount);
                    products.Add(productAdd);
                    WriteLine("Do you want to add more prodcuts? (y/n)");
                    var respond = ReadLine();
                    if (respond == "n") band = false;
                }
                else
                {
                    WriteLine("We don't have enough units of this product, please try with less"
                        +"\n or the product already exist in your cart.");
                    ReadLine();
                } 
            } while (band == true);
            return products;
        }
        public void ListProviders()
        {
            try
            {
                TestData.GetProvider().ForEach(p => WriteLine($"Name : {p.Name} email : {p.EmailAddress}"));
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                throw;
            }
        }
        public void ListPurchaseOrder()
        {
            try
            {
                Clear();
                var purchaseOrders = _purchaseOrderServices.GetPurchaseOrders();
                purchaseOrders.ForEach(p => WriteLine($"Id: {p.Id} Date : {p.PurchaseDate} Provider : {p.Provider.Name} Total : {p.Total} Status : {p.Status}"));
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                throw;
            }
        }
        public void ListSaleOrders(List<SellOrder> sellOrders, string clientName)
        {
            Clear();
            var table = new ConsoleTable("Client", "SellDate", "TotalBill", "TotalProducts");
            sellOrders.ForEach(p => table.AddRow(p.ClientName, p.SellDate.ToShortDateString(), p.TotalBill, p.Products.Count));
            WriteLine(table);
            var total = sellOrders.Sum(so => so.TotalBill);
            WriteLine($"Cliente : {clientName}  Total : {total}");
            
        }
    }
}
