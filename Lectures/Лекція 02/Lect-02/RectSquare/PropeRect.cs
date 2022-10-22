using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectSquare
{
    class PropeRect
    {
        private double a; // висота прямокутника
        private double b; // ширина прямокутника
        private double s; // площа
        public PropeRect() // конструктор за промовчанням
        {
            a = 3.0;
            b = 4.0;
            calcS();
        }
        public PropeRect(double x, double y) // конструктор з параметрами
        {
            a = (x > 0.1) ? x : 0.1;
            b = (y > 0.1) ? y : 0.1;
            calcS();
        }
        private void calcS()
        {
            s = a * b;
        }
        public virtual double A
        {
            get
            {
                return a;
            }
            set
            {
                a = (value > 0.1) ? value : 0.1;
                calcS();
            }
        }
        public virtual double B
        {
            get
            {
                return b;
            }
            set
            {
                b = (value > 0.1) ? value : 0.1;
                calcS();
            }
        }

        public override string ToString()
        {
            return string.Format("Rectangle [ {0} x {1} ]", a, b);
        }
        public double area()
        {
            return s;
        }
        public double perim()
        {
            return 2.0 * (a + b);
        }
    }
    class NoisyRect :PropeRect
    {
        public NoisyRect(double x, double y) : base(x, y) { }
        public override double A
        {
            get
            {
                Console.WriteLine("Somebody just read A property!");
                return base.A;
            }
            set
            {
                base.A = value;
            }
        }
        public override double B
        {
            get
            {
                Console.WriteLine("Somebody just read B property!");
                return base.B;
            }
            set
            {
                base.B = value;
            }
        }
    }
}
