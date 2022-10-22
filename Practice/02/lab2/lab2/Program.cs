using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int rn = 0;
            while (n > 0)
            {
                rn = rn * 10 + n % 10;
                n = n / 10;
            }

            Console.Write("Reverse order:" + rn);
        }
    }
}
