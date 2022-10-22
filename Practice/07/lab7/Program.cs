using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    interface IShape
    {
        double perimeter();
        double area();
        void printPerimeter();
        void printArea();
    }
    class Rectangle : IShape
    {
        private double length;
        private double width;
        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }
        public double perimeter()
        {
            return 2 * length + 2 * width;
        }
        public double area()
        {
            return length * width;
        }
        public void printPerimeter()
        {
            Console.WriteLine("Rectangel Perimeter: {0}", perimeter());
        }
        public void printArea()
        {
            Console.WriteLine("Rectangel Area: {0}", area());
        }
    }
    class Circle : IShape
    {
        const double PI = 3.14;
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public double perimeter()
        {
            return 2 * PI * radius;
        }
        public double area()
        {
            return radius * radius * PI;
        }
        public void printPerimeter()
        {
            Console.WriteLine("Circle Perimeter: {0}", perimeter());
        }
        public void printArea()
        {
            Console.WriteLine("Circle Area: {0}", area());
        }
    }
    class Trapeze : IShape
    {
        private double a;
        private double b;
        private double c;
        private double d;
        private double height;
        public Trapeze(double a, double b, double c, double d, double height)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.height = height;
        }
        public double perimeter()
        {
            return a + b + c + d;
        }
        public double area()
        {
            return height *( (a + b) / 2.0);
        }
        public void printPerimeter()
        {
            Console.WriteLine("Trapeze Perimeter: {0}", perimeter());
        }
        public void printArea()
        {
            Console.WriteLine("Trapeze Area: {0}", area());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapes =
            {
                new Rectangle(10, 10),
                new Circle (10),
                new Trapeze (10, 10, 10, 10, 10)
            };
            System.Console.WriteLine("Shapes Collection\n");
            foreach (IShape s in shapes)
            {
                s.perimeter();
                s.area();
                s.printPerimeter();
                s.printArea();
                Console.WriteLine("\n--------------------------------------");
            }
        }
    }
}
