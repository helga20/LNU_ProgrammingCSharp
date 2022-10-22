using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectSquare
{
    class Rectangle
    {
        protected double a; // висота прямокутника
        protected double b; // ширина прямокутника
        public Rectangle() // конструктор за промовчанням
        {
            a = 3.0;
            b = 4.0;
        }
        public Rectangle(double x, double y) // конструктор з параметрами
        {
            a = (x > 0.1) ? x : 0.1;
            b = (y > 0.1) ? y : 0.1;
        }
        public override string ToString()
        {
            return string.Format("Rectangle ( {0} x {1} )", a, b);
        }
        public double area()
        {
            return a * b;
        }
        public double perim()
        {
            return 2.0 * (a + b);
        }
    }
    class Square : Rectangle
    {
        public Square() : base(1.0, 1.0) { }
        public Square(double x) : base(x, x) { }
        public override string ToString()
        {
            //return "Square - " + base.ToString();
            return String.Format("Square ({0})", a);
        }
    }
}
