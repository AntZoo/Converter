using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Unit Converter 3000.");
            string source;
            while (true)
            {
                Console.WriteLine("\n===============================\nPlease input a number either in centimeters or inches\nand receive the converted value right away.\nNote that you should input your number with the unit.");
                source = Console.ReadLine();

                if (source.Length < 1) { break; }

                Regex re = new Regex(@"(\d*)\s*(.*)");
                Match m = re.Match(source);

                string digit = "";
                string units = "";

                if (m.Success)
                {
                    digit = m.Groups[1].Value;
                    units = m.Groups[2].Value;
                }

                if (digit.Length < 1 || units.Length < 1)
                {
                    Console.WriteLine("Your input is false.");
                    if (digit.Length < 1) { Console.WriteLine("You haven't sent a number."); }
                    if (units.Length < 1) { Console.WriteLine("You haven't defined a unit."); }
                }

                Console.WriteLine(digit + " " + units);
            }
        }
    }
}
