using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorFormattable
{
    class Program
    {
        static void Main(string[] args)
        {
            // форматоване виведення вектора
            FormatVector();
        }
        static public void FormatVector()
        {
            Vector v1 = new Vector(1, 32, 5);
            Vector v2 = new Vector(845.4, 54.3, -7.8);
            Console.WriteLine("\nIn IJK format,\nv1 is {0,30:IJK}\nv2 is {1,30:IJK}", v1, v2);
            Console.WriteLine("\nIn default format,\nv1 is {0,30}\nv2 is {1,30}", v1, v2);
            Console.WriteLine("\nIn VE format\nv1 is {0,30:VE}\nv2 is {1,30:VE}", v1, v2);
            Console.WriteLine("\nNorms are:\nv1 is {0,20:N}\nv2 is {1,20:N}", v1, v2);
            Console.ReadLine();
        }

    }
}
