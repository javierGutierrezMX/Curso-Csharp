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
    class InvestAccount : Account
    {
        public InvestAccount(string name, decimal initialBalance, int minimumBalance) : base(name, initialBalance, minimumBalance) { }
        public override void EndOfMonth()
        {
            if(Balance > _minimumBalance)
            {
                var extra = (Balance - 500) *.07m;
                WriteLine("Depositando intereses");
                Deposit(extra, DateTime.Now, "deposito de intereses del periodo.");
                WriteLine($"Su inversion genero rendimientos, su pago de intereses al 7% es de {extra}  y se agrego a su cuenta. Saldo actual : {Balance}");
            }
            else WriteLine($"Su inversion no genero intereses, su saldo es de {Balance}");
        }
    }
}
