using System;
using BankLibrary;


namespace MyBank
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine(@"Hey! Welcome to the bank of Dan!

Let's create you an account! What's your name?");

            string name = Console.ReadLine();

            Console.WriteLine($@"Hi {name}, thanks for banking with us.");

            var initialAmount = 0;

            while (initialAmount == 0)
            {
                Console.WriteLine("How much would you like to deposit initially?");
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    initialAmount = result;
                }
                else
                {
                    Console.WriteLine("Please enter a number greater than zero.");
                }
            }


            var account1 = new BankAccount(name, initialAmount);
            Console.WriteLine($"Bank account with number {account1.Number} created for {account1.Owner} with £{account1.Balance}");

            string requests = "y";

            while (requests == "y")
            {
                Console.WriteLine("Would you like any other services today?");
                Console.WriteLine(@"
                Press 1 to make a deposit.
                Press 2 to make a withdrawal.
                Press 3 to check your balance.
                Press 4 to check your account history.
                Press n to exit the bank.");

                string response = Console.ReadLine();
                if (response == "1")
                {
                    Console.WriteLine("How much would you like to deposit?");
                    string thisMuch = Console.ReadLine();
                    decimal thisMuchDecimal = 0;

                    if (decimal.TryParse(thisMuch, out decimal amount))
                    {
                        thisMuchDecimal = amount;
                    }
                    else
                    {
                        Console.WriteLine("That's not a number");
                    }

                    account1.MakeDeposit(thisMuchDecimal, DateTime.Now, "Deposit");

                }
                else if (response == "2")
                {
                    Console.WriteLine("What item are you buying?");
                    string item = Console.ReadLine();
                    Console.WriteLine("How much does it cost?");
                    string price = Console.ReadLine();
                    decimal priceDecimal = 0;
                    if (decimal.TryParse(price, out decimal amount))
                    {
                        priceDecimal = amount;
                    }
                    else
                    {
                        Console.WriteLine("That's not a number");
                    }

                    try
                    {
                        account1.MakeWithdrawal(priceDecimal, DateTime.Now, item);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                else if (response == "3")
                {
                    Console.WriteLine($"Your account balance is £{account1.Balance}");

                }
                else if (response == "4")
                {
                    Console.WriteLine(account1.GetAccountHistory());
                }
                else if (response == "n")
                {
                    Console.WriteLine($"Ok, bye {name}");
                    requests = "n";
                }

            }
        }
    }
}
