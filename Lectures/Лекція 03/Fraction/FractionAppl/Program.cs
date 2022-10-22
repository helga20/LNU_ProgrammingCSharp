using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionAppl
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction A = new Fraction(1, 3);
            Fraction B = new Fraction(6, 36);
            Fraction C = A + B;
            Fraction D = A / B;
            Console.WriteLine("A = " + A);
            Console.WriteLine("B = " + B);
            Console.WriteLine("A + B = " + C);
            Console.WriteLine("A / B = " + D);
            Console.ReadLine();
            Fraction E = C++.Clone();
            Console.WriteLine("C = " + C);
            Console.WriteLine("E = " + E);
            Fraction F = (++C).Clone();
            Console.WriteLine("C = " + C);
            Console.WriteLine("F = " + F);
            Console.ReadLine();

            Fraction[] M = { new Fraction(6, 13), new Fraction(3, 11), new Fraction(4, 10) };
            foreach (Fraction f in M) Console.WriteLine(f);
            Array.Sort(M);
            foreach (Fraction f in M) Console.WriteLine(f);
            Console.ReadLine();
            Console.WriteLine("A + 5 = " + (A + 5).ToString());
            Console.ReadLine();
            Console.WriteLine("C is a Fraction of {0} and {1}", C[0], C[1]);
            C[1] = -5;
            Console.WriteLine("C = " + C);
            Console.ReadLine();
        }
    }
}
