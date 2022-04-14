using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using System.Globalization;
using ECommerce_Data.Entities;
using ECommerce_Business.Services.Implementations;
using LinQ_ECommerceEjemplo;

namespace ECommerceEShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new ECommerceConsole();
            console.MainMenu();
        }
        

    }
}
