using System;

namespace Zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            var longValue = long.MaxValue;

            int intValue;

            try
            {
                checked
                {
                    intValue = (int)longValue;
                }

            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
