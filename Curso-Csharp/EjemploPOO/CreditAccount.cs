using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using System.Globalization;

namespace EjemploPOO
{
    class CreditAccount : Account
    {
        public CreditAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {lineaCredito = initialBalance * -1;}
        public decimal lineaCredito { get; set; }

        public override void EndOfMonth()
        {
            decimal deuda = 0;
            if(Balance < lineaCredito)
            {
                var extra = (Balance - lineaCredito) *1.07m;
                deuda = (lineaCredito + extra)* -1;
                WriteLine($"Su linea fue excedida, su pago es de {deuda} que incluye un cargo al 7% por su excedente de {extra}");
            }
            else
            {
                deuda = Balance * -1;
                WriteLine($"Su linea no fue excedida, su pago es de {deuda}");
            }
        }
        public void Charge(decimal amount, DateTime date, string description)
        {
            if (Balance <= lineaCredito)
                WriteLine("Linea excedida, 7% extra por este cargo.");
                var charge = new Transaction() { Amount = amount * -1, Date = date, Description = description };
                TransactionList.Add(charge);
        }
    }
}
