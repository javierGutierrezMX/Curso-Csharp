using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using System.Globalization;
using System.Threading;
namespace EjemploPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Name: ");
            var name = ReadLine();
            WriteLine("Invest: ");
            decimal.TryParse(ReadLine(), out decimal IB);
            WriteLine("Minimum Balance: ");
            Int32.TryParse(ReadLine(), out int MB);

            //CreditAccount creditCard = new CreditAccount(name, IB);
            InvestAccount investAccount = new InvestAccount(name, IB, MB);
            //Account creditCard = new Account(name, IB, MB);

            WriteLine("Balance : " + investAccount.Balance);
            WriteLine("Deposito : 500");
            investAccount.Deposit(500, DateTime.Today, "Deposito 1");
            WriteLine("Balance : " + investAccount.Balance);
            WriteLine("Deposito : 500");
            investAccount.Deposit(500, DateTime.Today, "Deposito 2");
            WriteLine("Balance : " + investAccount.Balance);

            investAccount.EndOfMonth();
            WriteLine("Historico: ");
            investAccount.GetAccountHistory();

        }
    }
}
