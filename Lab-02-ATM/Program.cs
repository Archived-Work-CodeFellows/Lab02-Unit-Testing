using System;

namespace Lab_02_ATM
{

    public class Program
    {
        public static decimal balance = 2500;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            bool isRunning = true;
            do
            {
                isRunning = AppMenu();

            } while (isRunning);
        }

        //This houses a switch statment to direct the user
        //based on their selections on the screen.
        static bool AppMenu()
        {
            bool isRunning = true;

            switch (UserSelection())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("view");
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("withdraw");
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("deposit");
                    break;
                default:

                    isRunning = false;
                    break;
            }
            return isRunning;
        }

        static string UserSelection()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Monies Bank filled with memes and Dreams");
            Console.WriteLine("Please make a selection!");
            Console.WriteLine(" ");
            Console.WriteLine($"Your current available balance: {balance}");
            Console.WriteLine(" ");
            Console.WriteLine("1) View your current available balance");
            Console.WriteLine("2) Withdraw money from your account");
            Console.WriteLine("3) Add money to your account");
            Console.WriteLine("4) exit application");
            string input = Console.ReadLine();
            return input;
        }

        static void UserWithdraw()
        {
            Console.Clear();
        }

        public static decimal withdrawSelect(decimal amount, decimal balance)
        {
            if (amount <= balance)
            {
                balance = balance - amount;
                Console.WriteLine($"Your new balance is: {balance}");
            }
            else Console.WriteLine("I'm sorry, you do not have enough monies for that");
            return balance;
        }
    }
}
