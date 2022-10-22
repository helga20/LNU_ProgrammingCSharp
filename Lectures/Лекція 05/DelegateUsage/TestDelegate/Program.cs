using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDelegate
{
    class MathOperations
    {
        public static double MultiplyByTwo(double value)
        {
            return value * 2;
        }
        public static double Square(double value)
        {
            return value * value;
        }
        public double Inc(double value)
        {
            return value + 1.0;
        }
        public override string ToString()
        {
            return "Lecture";
        }
    }

    delegate double DoubleOp(double x);
    
    class Program
    {
        static void Main(string[] args)
        {
            DoubleOp[] operations = 
            {
               MathOperations.MultiplyByTwo,
               MathOperations.Square
               ,new DoubleOp(MathOperations.MultiplyByTwo)
               //,new DoubleOp(MathOperations.Square)
            };

            for (int i = 0; i < operations.Length; i++)
            {
                Console.WriteLine("Using operations[{0}]:", i);
                ProcessAndDisplayNumber(operations[i], 2.0);
                ProcessAndDisplayNumber(operations[i], 7.94);
                ProcessAndDisplayNumber(operations[i], 1.414);
                Console.WriteLine();
            }
            Console.ReadLine();

            MathOperations obj = new MathOperations();
            MathOperations obj1 = new MathOperations();

            DoubleOp testDelegate = MathOperations.MultiplyByTwo;
            testDelegate += obj1.Inc;
            testDelegate += MathOperations.Square;
            testDelegate += obj.Inc;

            //foreach (Delegate d in testDelegate.GetInvocationList())
            //    Console.WriteLine("{0} {1}", d.Method, d.Target);
            //Console.ReadLine();

            //foreach (Delegate d in testDelegate.GetInvocationList())
            //    Console.WriteLine("{0} {1} {2}", d.Method, d.Target, d(13));
            //Console.ReadLine();

            //foreach (Delegate d in testDelegate.GetInvocationList())
            //    Console.WriteLine("{0} {1} {2}", d.Method, d.Target, d.Invoke());
            //Console.ReadLine();

            foreach (Delegate d in testDelegate.GetInvocationList())
                Console.WriteLine("{0} {1} {3}", d.Method, d.Target, d.DynamicInvoke(13));
            Console.ReadLine();
        }
        static void ProcessAndDisplayNumber(DoubleOp action, double value)
        {
            double result = action(value);
            Console.WriteLine(
               "Value is {0}, result of operation is {1}", value, result);
        }
    }
}
