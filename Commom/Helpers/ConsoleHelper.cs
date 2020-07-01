using System;
using System.Collections.Generic;
using System.Text;

namespace Commom.Helpers
{
    public static class ConsoleHelper
    {
        public static int ReadPositiveOrZeroInt(string message)
        {
            Console.WriteLine(message);

            string input = Console.ReadLine();

            int value;
            while (!int.TryParse(input, out value) || value < 0)
            {
                Console.WriteLine("Valor inválido, tente novamente.");
                Console.WriteLine(message);
                input = Console.ReadLine();
            }

            return value;
        }
        public static void ReadPositiveInt(string message, out int value)
            => value = ReadPositiveOrZeroInt(message);

        public static decimal ReadPositiveOrZeroDecimal(string message)
        {
            Console.WriteLine(message);

            string input = Console.ReadLine();

            decimal value;
            while (!decimal.TryParse(input, out value) || value < 0)
            {
                Console.WriteLine("Valor inválido, tente novamente.");
                Console.WriteLine(message);
                input = Console.ReadLine();
            }

            return value;
        }
        public static void ReadPositiveOrZeroDecimal(string message, out decimal value)
            => value = ReadPositiveOrZeroDecimal(message);
    }
}
