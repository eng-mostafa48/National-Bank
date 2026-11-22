using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National_Bank.Helpers
{
    internal static class ReadInputs
    {
        public static int ReadIntBetween(string message, int min, int max)
        {
            int number;

            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out number) &&
                    number >= min && number <= max)
                {
                    return number;
                }

                Console.WriteLine($"Please enter an integer between {min} and {max}.");
            }
        }

        public static string ReadString(string message)
        {
            string? input;

            do
            {
                Console.Write(message);
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("Input cannot be empty. Try again.");

            } while (string.IsNullOrWhiteSpace(input));

            return input.Trim();
        }

        public static DateTime ReadDate(string message)
        {
            DateTime date;

            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (DateTime.TryParseExact(
                    input,
                    "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out date))
                {
                    return date;
                }

                Console.WriteLine("Invalid date! Use yyyy-MM-dd format.");
            }
        }
    }


}
