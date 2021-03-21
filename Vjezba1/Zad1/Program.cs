using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba1
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInt(out int num1);
            ReadInt(out int num2);

            if (num1 != 0 && num2 != 0)
            {
                int result = num1 / num2;
                Console.WriteLine("General: " + result.ToString("G"));
                Console.WriteLine("Number: " + result.ToString("N"));
                Console.WriteLine("Integer: " + result);
                Console.WriteLine("Float: " + result.ToString("F"));
                Console.WriteLine("Currency: " + result.ToString("C"));
                Console.WriteLine("Scientific: " + string.Format("{0:E2}", result));
                Console.WriteLine("Hexadecimal: " + result.ToString("X"));
            }
        }

        private static void ReadInt(out int number)
        {
            Console.WriteLine("Upisi broj:");

            string numberFromConsole = Console.ReadLine();

            if (!int.TryParse(numberFromConsole, out number))
            {
                Console.WriteLine("Wrong input value");
                ReadInt(out number);
            }


        }
    }
}
