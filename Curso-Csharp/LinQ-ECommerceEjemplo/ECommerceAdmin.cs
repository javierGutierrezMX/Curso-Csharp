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

namespace LinQ_ECommerceEjemplo
{
    public partial class ECommerceConsole
    {
        public void AdminMenu()
        {
            bool band = true;
            do
            {

                Clear();
                WriteLine("Wlecome see our options ");
                WriteLine("1.-Add Product");
                WriteLine("2.-Search Product");
                WriteLine("3.-Edit Product");
                WriteLine("4.-Delete Product");
                WriteLine("5.-List of Products");
                WriteLine("6.-Reports");
                WriteLine("7.-Purchase Orders");
                WriteLine("Choose an option: ");
                Int32.TryParse(ReadLine(), out int option);
                switch (option)
                {
                    case 1:
                        AddProduct();
                        break;
                    case 2:
                        SearchProdcut();
                        break;
                    case 3:
                        ListProducts();
                        EditProduct();
                        break;
                    case 4:
                        ListProducts();
                        DeleteProduct();
                        break;
                    case 5:
                        ListProducts();
                        break;
                    case 6:
                        MenuReports();
                        break;
                    case 7:
                        MenuPurchaseOrders();
                        break;
                    default:
                        WriteLine("Invalid option!!!");
                        break;

                };
                WriteLine("Do you want to do something else? (y/n)");
                var respond = ReadLine();
                if (respond == "n") band = false;
            }
            while (band == true);
        }
        public void AddProduct()
        {
            Clear();
            WriteLine("Write the requirments :");
            WriteLine("Id: ");
            Int32.TryParse(ReadLine(), out int id);
            WriteLine("Name: ");
            var name = ReadLine();
            WriteLine("Price : ");
            Decimal.TryParse(ReadLine(), out decimal price);
            WriteLine("Description : ");
            var description = ReadLine();
            WriteLine("Brand : ");
            var brand = ReadLine();
            WriteLine("Sku : ");
            var sku = ReadLine();
            WriteLine("\nChoose a Department");
            ListDepartments();
            WriteLine("Department : ");
            var selectDep = ReadLine();
            WriteLine("\nChoose a Subdepartment");
            ListSubdepartments(selectDep);
            WriteLine("Subdepartment : ");
            var selectSubd = ReadLine();
            try
            {
                var product = new Product(id, name, price, description, brand, sku);
                var tempd = _depServices.GetDepartments().Find(d => d.Name == selectDep);
                var tempSubD = _depServices.GetSubdepartments(tempd).FirstOrDefault(sb => sb.Name == selectSubd);
                product.AddSubd(tempSubD);
                _productServices.AddProduct(product);
                WriteLine("Product Added");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                throw;
            }
        }
        public void SearchProdcut()
        {
            try
            {
                Clear();
                WriteLine("Write the requirments :");
                WriteLine("Id: ");
                Int32.TryParse(ReadLine(), out int id);
                Clear();
                var p = _productServices.GetProduct(id);
                if (p != null)
                    WriteLine($"Producto : {p.Name} Precio : {p.Price} Marca : {p.Brand} Sku : {p.Sku} Stock : {p.Stock}");
                else
                    WriteLine("Product not found");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                throw;
            }
        }
        public void EditProduct()
        {
            WriteLine("Write the requirments :");
            WriteLine("Id (write the same id): ");
            Int32.TryParse(ReadLine(), out int id);
            WriteLine("Name: ");
            var name = ReadLine();
            WriteLine("Price : ");
            Decimal.TryParse(ReadLine(), out decimal price);
            WriteLine("Description : ");
            var description = ReadLine();
            WriteLine("Brand : ");
            var brand = ReadLine();
            WriteLine("Sku : ");
            var sku = ReadLine();
            try
            {
                var product = new Product(id, name, price, description, brand, sku);
                _productServices.EditProdcut(product);
                WriteLine("Product Updated");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                throw;
            }
        }
        public void DeleteProduct(bool isSell = false, Cart cart = null)
        {
            try
            {
                //Clear();
                WriteLine("Write the requirments :");
                WriteLine("Id for delete: ");
                Int32.TryParse(ReadLine(), out int id);
                Clear();
                if (isSell)
                    _clientServices.DeleteProductInCart(id, cart);
                else
                    _productServices.DeleteProduct(id);
                
                WriteLine("Product deleted");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                throw;
            }
        }
    }
}
