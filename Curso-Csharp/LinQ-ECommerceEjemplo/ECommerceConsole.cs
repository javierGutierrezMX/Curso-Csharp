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
        private static ProductService _productServices;
        private static DepartmentServices _depServices;
        private static ReportServices _repServices;
        private static PurchaseOrderService _purchaseOrderServices;
        private static ClientServices _clientServices;
        public string clientName;
        public ECommerceConsole()
        {
            _productServices = new ProductService();
            _depServices = new DepartmentServices();
            _repServices = new ReportServices();
            _purchaseOrderServices = new PurchaseOrderService();
            _clientServices = new ClientServices();
        }

        public  void MainMenu()
        {
            bool band = true;
            do
            {

                Clear();
                WriteLine("Wlecome, select your profile");
                WriteLine("1.-Admin");
                WriteLine("2.-Client");
                WriteLine("Choose an option: ");
                Int32.TryParse(ReadLine(), out int option);
                switch (option)
                {
                    case 1:
                        AdminMenu();
                        break;
                    case 2:
                        WriteLine("Client Name: ");
                        if (clientName != null)
                            clientName = ReadLine();
                        else
                        {
                            clientName = null;
                            clientName = ReadLine();
                        }
                        ClientMenu(clientName);
                        break;
                    default:
                        WriteLine("Invalid option!!!");
                        break;

                };
                WriteLine("Do you want to close the system? (y/n)");
                var respond = ReadLine();
                if (respond == "y") band = false;
            }
            while (band == true);
        }
        
        
    }
}
