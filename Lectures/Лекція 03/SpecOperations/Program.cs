using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            byte b = 255;
            ++b;
            Console.WriteLine(" b = " + b);
            Console.ReadLine();
            byte c = 255;
            try
            {
                checked
                {
                    ++c;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Larger then a byte");
                c = 1;
            }
            Console.WriteLine(" c = " + c);
            Console.ReadLine();
            if (c is ValueType) Console.WriteLine("byte is an ValueType");
            else Console.WriteLine("byte is not an int");
            if (c is object) Console.WriteLine("byte is an object");
            else Console.WriteLine("byte is not an object");
            Console.ReadLine();

            object o1 = "Hello, World";
            object o2 = 777;
            string s1 = o1 as string;
            string s2 = o2 as string;
            Console.WriteLine(s1);
            Console.WriteLine(s2 == null ? "Null" : s2);
            Console.ReadLine();
        }
    }
}
