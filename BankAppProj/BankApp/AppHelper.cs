using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public static class AppHelper
    {
        public static void PrintLine(int widthOfTable)
        {
            Console.WriteLine(new string('-', widthOfTable));
        }

        public static void PrintRow(int widthOfTable, params string[] columns)
        {
            int width = (widthOfTable - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += CenterText(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        private static string CenterText(string column, int width)
        {
            column = column.Length > width ? column.Substring(0, width - 3) + "..." : column;

            if (!string.IsNullOrEmpty(column))
            {
                return column.PadRight(width - (width - column.Length) / 2).PadLeft(width);
            }
            else
            {
                return new string(' ', width);
            }
        }

        public static void DisplayTitle(int windowWidth)
        {

            PrintLine(windowWidth);
            PrintRow(windowWidth, "SQ016 First Week1 Task Solution - Clone a Bank App");
            PrintLine(windowWidth);
        }

        public static void DisplayOperations(int windowWidth, User user, Account account)
        {

            Thread.Sleep(5000);
            Console.Clear();

            AppHelper.DisplayTitle(windowWidth);

            Console.WriteLine();
            Console.WriteLine($"Welcome! {user.FirstName} - you are logged-In");
            if(account != null && !string.IsNullOrEmpty(account.AccountNumber)) {
                Console.WriteLine($"{account.AccountNumber} - {account.AccountName} " +
                    $"[{account.AccountType.ToString().ToLower()}] account.");
            }

            Console.WriteLine();
            Console.WriteLine("[1] Create Account \t | \t[2] Withdrawal");
            Console.WriteLine();
            Console.WriteLine("[3] Transfer \t | \t[4] Deposit ");
            Console.WriteLine();
            Console.WriteLine("[5] Print Statement \t | [6] Logout");
            Console.WriteLine();

            while (GlobalState.tranxChoice < 1 || GlobalState.tranxChoice > 6)
            {
                if (GlobalState.counter2 > 0)
                {
                    Console.WriteLine("Invalid entry!");
                }
                Console.Write("\nChoose a transaction you wish to perform\t");
                GlobalState.counter2 += 1;

                GlobalState.tranxChoice = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine();
        }
    }
}
