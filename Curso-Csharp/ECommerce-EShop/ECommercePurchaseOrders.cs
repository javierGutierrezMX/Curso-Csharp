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
using ECommerce_Data.Enums;
using ECommerce_Business;

namespace LinQ_ECommerceEjemplo
{
    public partial class ECommerceConsole
    {
        public void MenuPurchaseOrders()
        {
            bool band = true;
            do
            {
                Clear();
                WriteLine("see our options ");
                WriteLine("1.-Register Purchase order");
                WriteLine("2.-Purchase order list");
                WriteLine("3.-Change Status");
                //WriteLine("4.-Prodcuts ordered by subdepartment and department");
                WriteLine("Choose an option: ");
                Int32.TryParse(ReadLine(), out int option);
                switch (option)
                {
                    case 1:
                        Clear();
                        AddPurchaseOrder();
                        break;
                    case 2:
                        ListPurchaseOrder();
                        break;
                    case 3:
                        ChangePurchaseorderStatus();
                        break;
                    //case 4:
                    //    break;
                    default:
                        WriteLine("Invalid option!!!");
                        break;

                };
                WriteLine("Do you want to do something else with purchase orders? (y/n)");
                var respond = ReadLine();
                if (respond == "n") band = false;
            }
            while (band == true);
        }

        public void AddPurchaseOrder()
        {
            Clear();
            WriteLine("Write the requirments :");
            WriteLine("Provider: ");
            ListProviders();
            WriteLine("Name of provider: ");
            var providerName = ReadLine();
            var products = ListOfSelectedProducts();
            Clear();
            WriteLine("Date of purchase (MM/dd/yyyy): ");
            if (!DateTime.TryParseExact(ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime pruchaseDate))
                WriteLine("Fecha invalida\n");
            try
            {
                var provider = TestData.GetProvider().FirstOrDefault(p => p.Name == providerName);
                var purchaseTemp = new PurchaseOrder(provider, products, pruchaseDate);
                _purchaseOrderServices.AddPurchaseOrder(purchaseTemp);
                WriteLine("Purchase order Added");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                throw;
            }
        }
        public void ChangePurchaseorderStatus()
        {
            Clear();
            WriteLine("Select a purchase Order: ");
            ListPurchaseOrder();
            WriteLine("Purchase order Id : ");
            Int32.TryParse(ReadLine(), out int piId);
            Enum.GetNames(typeof(PurchaseOrderStatus)).ToList().ForEach( s => WriteLine($"Status = {s}"));
            WriteLine("status option : ");
            var option = ReadLine();
            _purchaseOrderServices.GetPurchaseOrders().FirstOrDefault(po => po.Id == piId).Status =
                option == "Pending" ? PurchaseOrderStatus.Pending :
                option == "Processing" ? PurchaseOrderStatus.Processing :
                PurchaseOrderStatus.Paid;
            WriteLine("Status Modified");
            //Modify stock
            var tempPO = _purchaseOrderServices.GetPurchaseOrders().FirstOrDefault(po => po.Id == piId);
            if (tempPO.Status == PurchaseOrderStatus.Paid)
            {
                tempPO.PurchaseProducts.ForEach(
                    p =>
                    {
                        //buscamos cada producto de la orden en la "base" de productos
                        _productServices.GetProducts().FirstOrDefault(ps => ps.Id == p.Id).Stock = p.Stock;
                        WriteLine($"Product {p.Name} updated to new stock {p.Stock}");
                    }
                    );
            }
        }
    }
}
