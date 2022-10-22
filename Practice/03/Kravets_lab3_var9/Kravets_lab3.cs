using System;

namespace MyApp
{
    class Program
    {
        protected double a;
        protected int n;

        private int m;

        protected double x;
        protected double eps;
        public Program()
        {
            a = 0.0;
            n = 0;

            m = 12345;

            x = 0.0;
            eps = 0.0;
        }

        public double solution1(double a, int n)
        {
            double mul = 1;
            for (int i = 0; i < n; ++i)
            {
                mul *= Math.Pow((a + i), 2);
            }
            return mul;
        }

        public int solution2()
        {
            int rn = 0;
            while (m > 0)
            {
                rn = rn * 10 + m % 10;
                m = m / 10;
            }
            return rn;
        }

        public double solution3(double x, double eps)
        { 
            int n1 = 2;
            double s = -x;
            double s1 = 10.0;
            while (Math.Abs(s - s1) > eps)
            {
                s1 = s;
                s += -(Math.Pow(x, n1) / n1);
                n1 += 2;
            }
            return s;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("- 1 program -");
            Console.WriteLine("Enter a and n: ");
            double a = Convert.ToDouble(Console.ReadLine());
            int n = Convert.ToInt32(Console.ReadLine());
            Program S1 = new Program();
            Console.WriteLine(S1.solution1(a, n));
            Console.WriteLine("__________________________");


            Console.WriteLine("- 2 program -");
            Program S2 = new Program();
            Console.WriteLine(S2.solution2());
            Console.WriteLine("__________________________");


            Console.WriteLine("- 3 program -");
            Console.WriteLine("Enter x and eps: ");
            double x = Convert.ToDouble(Console.ReadLine());
            double eps = Convert.ToDouble(Console.ReadLine());
            Program S3 = new Program();

            Console.WriteLine(S3.solution3(x, eps));
            Console.ReadLine();

        }
    }
}
