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
    }
}
