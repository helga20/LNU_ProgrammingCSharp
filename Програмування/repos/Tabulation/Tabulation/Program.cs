using System;

namespace Tabulation
{
    class Program
    {
        static string Recurrent(double x, double eps)
        {
            int k;

            double sum = 0, dodanok = 1;
            for (k = 0; k < 1000; k++)
            {
                if (Math.Abs(dodanok) <= eps)
                    break;
                sum += dodanok;
                dodanok *= -(Math.Pow(x, 2) / ((2 * k + 1) * (2 * k + 2)));
            }

            return $"{sum} done in {k} steps";
        }

        static void Main()
        {
            Console.Write("Input A: ");
            int a = Int32.Parse(Console.ReadLine());
            Console.Write("Input B: ");
            int b = Int32.Parse(Console.ReadLine());
            Console.Write("Input Epsilon: ");
            double epsilon = Double.Parse(Console.ReadLine());
            Console.Write("Input Step: ");
            double step = Double.Parse(Console.ReadLine());

            double limit = b + (step / 2);
            for (double x = a; x < limit; x += step)
            {
                if (x % 1 == 0)
                    Console.WriteLine($"X = {x}  :\t{Recurrent(x, epsilon)}");
                else
                    Console.WriteLine($"X = {x}:\t{Recurrent(x, epsilon)}");
            }
        }
    }
}