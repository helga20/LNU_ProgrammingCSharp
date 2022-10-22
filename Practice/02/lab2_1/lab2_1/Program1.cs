using System;

namespace MyApp
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please, enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            double m = 1;
            for (int i = 0; i < n; ++i)
            {
                m *= Math.Pow((a + i), 2);
            }

            Console.Write("S = " + m);
        }
    }
}
