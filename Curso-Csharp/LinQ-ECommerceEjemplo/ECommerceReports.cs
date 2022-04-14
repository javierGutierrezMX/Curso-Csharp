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


namespace LinQ_ECommerceEjemplo
{
    public partial class ECommerceConsole
    {
        public void MenuReports()
        {
            bool band = true;
            do
            {
                Clear();
                WriteLine("see our options ");
                WriteLine("1.-Top 5 expensive products");
                WriteLine("2.-Products with 5 items or less in stock");
                WriteLine("3.-Prodcuts ordered by Brand");
                WriteLine("4.-Prodcuts ordered by subdepartment and department");
                WriteLine("5.-Best Product");
                WriteLine("6.-PO to chair");
                WriteLine("7.-Paid PO in the last 7 days");
                WriteLine("8.-Pending of Levis");
                WriteLine("Choose an option: ");
                Int32.TryParse(ReadLine(), out int option);
                switch (option)
                {
                    case 1:
                        Clear();
                        var q1 = _repServices.Top5Expensive(_productServices.GetProducts());
                        q1.ForEach(p => WriteLine(p));
                        break;
                    case 2:
                        Clear();
                        var q2 = _repServices.FiveOrLessInStock(_productServices.GetProducts());
                        q2.ForEach(p => WriteLine(p));
                        break;
                    case 3:
                        Clear();
                        var q3 = _repServices.OrderedByBrand(_productServices.GetProducts());
                        q3.ForEach(p => WriteLine(p));
                        break;
                    case 4:
                        Clear();
                        var q4 = _repServices.OrderedByDepartment(_productServices.GetProducts());
                        q4.ForEach(p => WriteLine(p));
                        break;
                    case 5:
                        Clear();
                        var q5 = _repServices.POBestProduct(_purchaseOrderServices.GetPurchaseOrders());
                        WriteLine(q5);
                        break;
                    case 6:
                        Clear();
                        var q6 = _repServices.POChair(_purchaseOrderServices.GetPurchaseOrders());
                        q6.ForEach(p => WriteLine(p));
                        break;
                    case 7:
                        Clear();
                        var q7 = _repServices.POStatusPaidLast7days(_purchaseOrderServices.GetPurchaseOrders());
                        q7.ForEach(p => WriteLine(p));
                        break;
                    case 8:
                        Clear();
                        var q8 = _repServices.POpendingOfLevis(_purchaseOrderServices.GetPurchaseOrders());
                        q8.ForEach(p => WriteLine(p));
                        break;
                    default:
                        WriteLine("Invalid option!!!");
                        break;

                };
                WriteLine("Do you want to do something else with report? (y/n)");
                var respond = ReadLine();
                if (respond == "n") band = false;
            }
            while (band == true);
        }
    }
}
