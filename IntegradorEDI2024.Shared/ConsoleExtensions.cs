

using System.Diagnostics.Metrics;
using System.Diagnostics;

namespace IntegradorEDI2024.Shared
{
    public static class ConsoleExtensions
    {
        public static int calculatePages(int records, int itemsPerPage)
        {
            if (records < itemsPerPage)
            {
                return 1;
            }
            else if (records % itemsPerPage == 0)
            {
                return records / itemsPerPage;
            }
            else
            {
                return records / itemsPerPage + 1;
            }
        }
        public static string GetString(string message)
        {
            string? value = string.Empty;
            
            do
            {
                Console.Write(message);
                value =Console.ReadLine();
                if (!string.IsNullOrEmpty(value))
                {
                    break;
                }
                Console.WriteLine("You must enter a brand, try again....");
            } while (true);
            return value;
        }
        public static int GetInt(string message)
        {
            int value = 0;
            do
            {
                if (int.TryParse(GetString(message),out value))
                {
                    break;
                }
                Console.WriteLine("You most enter a number value, try again....");
            } while (true);
            return value;
        }

        public static void wait()
        {
            Thread.Sleep(2000);
        }
        public static void Continue()
        {
            Console.WriteLine("Press ENTER for continue");
            Console.ReadKey();
        }
        public static string GetOptions(string message, List<string>? Options)
        {
            string selection = string.Empty;
            if (Options!=null)
            {
                Options.Insert(0, "N");
                do
                {
                    selection = GetString(message);
                    if (Options.Any(o=>o.Equals(selection)))
                    {
                        break;
                    }
                    Console.WriteLine("option not considered...try again");
                    //wait();
                    //Console.Clear();
                } while (!Options.Any(o => o.Equals(selection)));
            }
            return selection;
        }

        public static decimal GetDecimal(string message, int minValue)
        {
            decimal value = 0;
            do
            {
                if (decimal.TryParse(GetString(message),out value))
                {
                    if (value>minValue)
                    {
                        break;
                    }
                }
                Console.WriteLine("You must enter the price, try to enter a value greater than 1000...try again!");
            } while (true);
            return value;
        }
    }
}
