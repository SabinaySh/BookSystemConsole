using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.Lib
{
    public class HelperConsole
    {
        public static int ReadInt(string msg)
        {
            l1:
            Console.Write($"{msg}: ");
            string input = Console.ReadLine();
            bool isValid = int.TryParse(input, out int a);
            if (!isValid)
            {
                goto l1;
            }
            return a;
        }
        public static string ReadText(string msg,int? minLength)
        {
        l1:
            Console.Write($"{msg}: ");
            string input = Console.ReadLine();
            if(minLength.HasValue && input.Length < minLength)
            {
                goto l1;
            }
            return input;
        }
        public static string ReadTextWithLengthEqual(string msg,int length)
        {
            if (length < 1)
                length = 1;

            l1:
            Console.Write(msg);
            string input = Console.ReadLine();
            if (input.Length != length)
                goto l1;
            return input;
        }

        public static void ListMenu(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n============ {msg} ============\n");
            Console.ResetColor();
        }

        public static void ConsoleRedColor(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{msg}\n");
            Console.ResetColor();
        }

        public static void ConsoleDarkYellow(string msg)
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\n-------------- {msg} --------------\n");
            Console.ResetColor();
        }
        public static void ConsoleGreenColor(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n-------------- {msg} --------------\n");
            Console.ResetColor();
        }
    }
}
