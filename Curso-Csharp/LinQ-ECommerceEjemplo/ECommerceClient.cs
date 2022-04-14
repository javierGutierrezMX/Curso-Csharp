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
        public void ClientMenu(string clientName)
        {
            bool band = true;
            do
            {

                Clear();
                WriteLine("Wlecome see our options ");
                WriteLine("1.-Buy products");
                WriteLine("2.-Go to bill");
                WriteLine("3.-See cart");
                WriteLine("4.-See sellorders");
                WriteLine("Choose an option: ");
                Int32.TryParse(ReadLine(), out int option);
                switch (option)
                {
                    case 1:
                        AddProductsToCart(clientName);
                        break;
                    case 2:
                        GotoBill(clientName);
                        break;
                    case 3:
                        SeeCart(clientName);
                        break;
                    case 4:
                        SeeOrders(clientName);
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

        public void AddProductsToCart(string clientName)
        {
            if (_clientServices.GetCarts().FirstOrDefault(c => c.ClientName == clientName) == null)
            {
                var products = ListOfSelectedProducts(true);
                var cart = new Cart() { ClientName = clientName, AddedDate = DateTime.Now, ProductsInCart = products };
                _clientServices.AddCart(cart);
                WriteLine($"Productos en el carrito : ");
                ListProducts(cart.ProductsInCart);
                WriteLine("Do you want to pass to pay ? ");
                var respond = ReadLine();
                if (respond == "y") GotoBill(clientName);
            }
            else
                WriteLine("You have cart registered.");
        }
        public void SeeCart(string clientName)
        {
            var cart = _clientServices.GetCart(clientName);
            if (cart != null)
            {
                ListProducts(cart.ProductsInCart);
            }
            else
                WriteLine("Without cart");
            

            WriteLine("Do you want to delete something (y/n)? ");
            var respond = ReadLine();
            if (respond == "y" && cart != null) DeleteProduct(true, cart);

        }
        public void GotoBill(string clientName = null)
        {
            var cart = _clientServices.GetCart(clientName);
            if (cart != null && cart.ProductsInCart != null)
            {
                var saleOrder = new SellOrder()
                { SellDate = DateTime.Now, TotalBill = cart.ProductsInCart.Sum(p => (p.Price * p.Stock)), ClientName = cart.ClientName, Cart = cart };
                _clientServices.AddSellOrder(saleOrder);
                //restar stock
                saleOrder.Cart.ProductsInCart.ForEach(
                  p =>
                  {
                      //buscamos cada producto de la orden en la "base" de productos y restamos stock y migramos lista de p a sellorder.
                      _productServices.GetProducts().FirstOrDefault(ps => ps.Id == p.Id).Stock -= p.Stock;
                          var newP = new Product(p.Id, p.Name, p.Price, p.Description, p.Brand, p.Sku, p.Stock);
                          newP.AddSubd(p.Subdepartment);
                          saleOrder.Products.Add(newP);
                      //borramos el carrito
                      _clientServices.GetCarts().Remove(saleOrder.Cart);

                      WriteLine($"Product {p.Name} updated to new stock {p.Stock}");
                  }
                  );
                //_clientServices.PassToBill(cart, saleOrder);
            }
            else
                WriteLine("without cart");
        }
        public void SeeOrders(string clientName)
        {
            var saleOrders = _clientServices.GetSellOrders().Where(so => so.ClientName == clientName).ToList();
            ListSaleOrders(saleOrders, clientName);
        }  
    }
}
