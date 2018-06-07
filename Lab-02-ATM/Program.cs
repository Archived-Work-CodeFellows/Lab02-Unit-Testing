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
        /// <summary>
        /// This houses the main UI interaction and calls
        /// the appropriate methods based on user input
        /// </summary>
        /// <returns>a boolean to determine if the app continues or not</returns>
        static bool AppMenu()
        {
            bool isRunning = true;

            switch (UserSelection())
            {
                case "1":
                    Console.Clear();
                    ViewBalance();
                    break;
                case "2":
                    Console.Clear();
                    UserWithdraw();
                    break;
                case "3":
                    Console.Clear();
                    try
                    {
                        UserDeposit();
                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                    break;
                default:

                    isRunning = false;
                    break;
            }
            return isRunning;
        }
        /// <summary>
        /// This houses the text for the main menu of the
        /// application
        /// </summary>
        /// <returns>user selection</returns>
        static string UserSelection()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Monies Bank filled with memes and Dreams");
            Console.WriteLine("Please make a selection!");
            Console.WriteLine(" ");
            Console.WriteLine("1) View your current available balance");
            Console.WriteLine("2) Withdraw money from your account");
            Console.WriteLine("3) Add money to your account");
            Console.WriteLine("4) exit application");
            string input = Console.ReadLine();
            return input;
        }
        /// <summary>
        /// This is shows the user balance. For this application
        /// the starting balance is 2500
        /// </summary>
        static void ViewBalance()
        {
            Console.WriteLine("You've selected to view your current balance");
            Console.WriteLine(" ");
            Console.WriteLine($"Your current available balance: {balance}");
            Console.ReadLine();
        }
        /// <summary>
        /// This method houses the interaction for the WithdrawSelect method
        /// and implements a try-catch-finally block to ensure
        /// valid user input
        /// </summary>
        static void UserWithdraw()
        {
            Console.Clear();
            int input = 0;
            try
            {
                Console.WriteLine("You've select to withdraw monies");
                Console.WriteLine("How much would you like to withdraw?");
                input = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("I'm sorry I don't quite understand that");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {
                balance = WithdrawSelect(input, balance);
            }
        }
        /// <summary>
        /// This method houses the interaction for the DepositSelect method
        /// and implements a try-catch-finally block to ensure
        /// valid user input
        /// </summary>
        static void UserDeposit()
        {
            Console.Clear();
            int input = 0;

            try
            {
                Console.WriteLine("You've selected to add some monies!");
                Console.WriteLine("How much would you like to deposit?");
                input = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                throw;
            }
            finally
            {
                balance = DepositSelect(input, balance);
            }
        }
        /// <summary>
        /// This is the algorithm that is for if the user selects to withdraw
        /// from their account. User cannot withdraw more than what is available
        /// </summary>
        /// <param name="amount">deisred amount to withdraw</param>
        /// <param name="balance">current balance</param>
        /// <returns>the new balance</returns>
        public static decimal WithdrawSelect(decimal amount, decimal balance)
        {
            if (amount <= balance && amount >= 0)
            {
                balance = balance - amount;
                Console.WriteLine($"Your new balance is: {balance}");
            }
            else
            {
                Console.WriteLine("I'm sorry, you do not have enough monies for that");
            }
            return balance;
        }
        /// <summary>
        /// This is the algorithm that is for if the user selects to deposit money
        /// to their account. User cannot deposit negative values
        /// </summary>
        /// <param name="amount">deisred amount to withdraw</param>
        /// <param name="balance">current balance</param>
        /// <returns>the new balance</returns>
        public static decimal DepositSelect(decimal amount, decimal balance)
        {
            if(amount < 0)
            {
                Console.WriteLine("I can't deposit that. I'm sorry");

            } else balance = balance + amount;

            return balance;
        }
    }
}
