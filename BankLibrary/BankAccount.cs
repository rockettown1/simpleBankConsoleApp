using System;
using System.Collections.Generic;
using System.Text;
using Humanizer;

namespace BankLibrary
{
    public class BankAccount
    {
        public string Owner { get; set; }
        public string Number { get; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransations)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        private static int accountNumberSeed = 1234567890;

        private List<Transaction> allTransations = new List<Transaction>();

        public BankAccount(string name, decimal initalDeposit)
        {
            this.Owner = name;
            MakeDeposit(initalDeposit, DateTime.Now, "Initial Balance");
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }


        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0) {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransations.Add(deposit);

        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            if (this.Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransations.Add(withdrawal);
        }


        public string GetAccountHistory()
        {

            
            var report = new StringBuilder();

            //header
            report.AppendLine("Date\t\tAmount\tNote");

            foreach (var item in allTransations)
            {
                //ows
                report.AppendLine($"{item.Date.ToShortDateString()}\t{((int)item.Amount).ToWords()}\t{item.Notes}");
            }

            return report.ToString();
        }


    }
}
