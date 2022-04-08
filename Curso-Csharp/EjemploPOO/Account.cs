using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using System.Globalization;
using System.Text;

namespace EjemploPOO
{
    public class Account
    {
        public string Owner { get; set; }
        public string Number { get; set; }
        public decimal  Balance { 
            get 
            {
                decimal balance = 0;
                foreach (var tran in TransactionList)
                {
                    balance += tran.Amount;
                }
                return balance;
            }
        }

        public List<Transaction> TransactionList = new List<Transaction>();

        public readonly int _minimumBalance;
        private static int accountNumberSeed = 123456780;

        //Constructor de Invset y debit (normal account)
        public Account (string name,decimal initialBalance, int minimumBalance)
        {
            Owner = name;
            _minimumBalance = minimumBalance;
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            Deposit(initialBalance, DateTime.Now, "initial deposit");
        }
        //Constructor de CreditAccount
        public Account(string name, decimal initialBalance)
        {
            Owner = name;
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void Deposit(decimal amount, DateTime date, string description)
        {
            if(!AmountValidation(amount))
                WriteLine("Deposito debe ser mayor a 0");
            else
            {
                var deposit = new Transaction() { Amount = amount , Date = date, Description = description };
                TransactionList.Add(deposit);
            }
        }
        public void Withdraw(decimal amount, DateTime date, string description)
        {
            if (!AmountValidation(amount))
                WriteLine("Deposito debe ser mayor a 0");
            else
            {
                var trans = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
                var withdrawal = new Transaction() { Amount = amount * -1, Date = date, Description = description };
                TransactionList.Add(withdrawal);
            }
        }

        protected virtual Transaction CheckWithdrawalLimit (bool isOverCharge)
        {
            if (isOverCharge)
                throw new InvalidOperationException("No tienes fondos");
            else
                return default;
        }
        protected bool AmountValidation(decimal amount) => amount > 0 ? true : false;

        public string GetAccountHistory()
        {
            decimal balance = 0;
            var report = new StringBuilder();
            report.AppendLine("Date\tAmount\tBalance\tDescription\t");
            foreach (var item in TransactionList)
            {
                balance += item.Amount;
                WriteLine($"{item.Date}\t{item.Amount}\t{balance}\t{item.Description}\t");
                report.AppendLine($"Date\tAmount\tBalance\tDescription\t");
            }
            return report.ToString();
        }

        public virtual void EndOfMonth() { }
    }
}
