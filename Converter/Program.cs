using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Converter
{
    class Program
    {
        static readonly string[] inArray = { "inch", "inches", "''", "\"", "in", "ins" };
        static readonly string[] cmArray = { "centimeter", "centimeters", "cm", "cms" };

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Convert-o-matic.");

            string source;

            Regex re = new Regex(@"([\d\.]*)[\s-]*(.*)");

            while (true)
            {
                Console.WriteLine("\n===============================\nPlease input a number either in centimeters or inches\nand receive the converted value right away.\nNote that you should input your number with the unit.");
                Console.Write("> ");
                source = Console.ReadLine();

                if (string.IsNullOrEmpty(source) || source == "exit" || source == "q") { break; }

                if (source == "help" || source == "?")
                {
                    Console.WriteLine("\nAccepted symbols for inches are " + string.Join(", ", inArray) + ".\nAccepted symbols for centimeters are " + string.Join(", ", cmArray) + ".\nTo display this message write '?' or 'help'.\nTo exit just press enter or write 'exit'.");
                    continue;
                }

                string digit = "";
                string units = "";
                source = source.Trim();

                Match m = re.Match(source);

                if (m.Success)
                {
                    digit = m.Groups[1].Value;
                    units = m.Groups[2].Value;
                }

                if (digit.Length < 1 || (units.Length < 1 || (!inArray.Any(units.Contains) && !cmArray.Any(units.Contains))))
                {
                    Console.WriteLine("Your input is false.");
                    if (digit.Length < 1) { Console.WriteLine("You haven't sent a number."); }
                    if (units.Length < 1 || (!inArray.Any(units.Contains) && !cmArray.Any(units.Contains))) { Console.WriteLine("You haven't defined a unit or you defined it wrongly."); }
                    continue;
                }

                Console.WriteLine("-------------------------------\n");

                if (inArray.Any(units.Contains)) {
                    Console.WriteLine($"{digit} in = {Math.Round(Convert.ToDouble(digit) * 2.54, 3)} cm");
                } else if (cmArray.Any(units.Contains))
                {
                    Console.WriteLine($"{digit} cm =  {Math.Round(Convert.ToDouble(digit) * 0.393701, 3)} in");
                }
            }
        }
    }
}
