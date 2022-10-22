using System;

namespace StoredShapesCS
{
    [Serializable]
    public abstract class Shape : IComparable
    {
        public abstract double Square();
        public abstract double Perim();

        // реалізація інтерфейсу порівняння
        public int CompareTo(object shape)
        {
            // повертає -1, якщо this < shape
            // повертає  0, якщо this == shape
            // повертає  1, якщо this > shape

            return this.Square().CompareTo((shape as Shape).Square());

            //if (this.Square() < (shape as Shape).Square()) return -1;
            //if (this.Square() > (shape as Shape).Square()) return 1;
            //return 0;
        }

        static public bool operator >(Shape Left, Shape Right)
        {
            //return Left.Square() > Right.Square();
            return Left.CompareTo(Right) > 0;
        }
        static public bool operator <(Shape Left, Shape Right)
        {
            //return Left.Square() < Right.Square();
            return Left.CompareTo(Right) < 0;
        }

        public static Shape ReadShape(System.IO.StreamReader stream)
        {
            string[] data = stream.ReadLine().Split();
            switch (data[0].ToLower())
            {
                case "rectangle": return new Rectangle(double.Parse(data[1]), double.Parse(data[2]));
                case "square": return new Square(double.Parse(data[1]));
                case "circle": return new Circle(double.Parse(data[1]));
                case "triangle": return new Triangle(double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]));
                default: return new Circle();
            }
        }
    }

    [Serializable]
    public class Rectangle : Shape, IFormattable
    {
        // сторони прямокутника
        protected double a;
        protected double b;
        // конструктори
        public Rectangle()
        {
            a = 3;
            b = 4;
        }
        public Rectangle(double x, double y)
        {
            a = x > 0.1 ? x : 0.1;
            b = y > 0.1 ? y : 0.1;
        }
        // методи
        public override string ToString()
        {
            return $"Rectangle[{this.a}x{this.b}]";
        }

        // реалізація інтерфейсу
        public string ToString(string format, IFormatProvider provider)
        {
            if (format == null) return this.ToString();
            switch (format.ToUpper())
            {
                case "DRAFT": return $"[{this.a}x{this.b}]";
                case "USUAL": return this.ToString();
                case "WIDE": return $"Rectangle [ {this.a:E} x {this.b:E} ]";
                default: return this.ToString();
            }
        }

        public override double Square()
        {
            return this.a * this.b;
        }
        public override double Perim()
        {
            return 2.0 * (this.a + this.b);
        }
        public void setA(double x)
        {
            a = x > 0.1 ? x : 0.1;
        }
        // властивості (property)
        public virtual double A
        {
            get // double get()
            {
                Console.WriteLine("Somebody reads A");
                return this.a;
            }
            set // void set(double value)
            {
                Console.WriteLine($"Somebody sets A with value {value}");
                this.a = value > 0.1 ? value : 0.1;
            }
        }
        public virtual double B
        {
            get // double get()
            {
                Console.WriteLine("Somebody reads B");
                return this.b;
            }
            set // void set(double value)
            {
                Console.WriteLine($"Somebody sets B with value {value}");
                this.b = value > 0.1 ? value : 0.1;
            }
        }
    }

    [Serializable]
    public class Circle : Shape
    {
        // радіус круга
        private double r;
        // конструктори
        public Circle()
        {
            r = 1;
        }
        public Circle(double x)
        {
            r = x > 0.1 ? x : 0.1;
        }
        // методи
        public override string ToString()
        {
            return $"Circle({this.r})";
        }
        public override double Square()
        {
            return Math.PI * this.r * this.r;
        }
        public override double Perim()
        {
            return 2.0 * Math.PI * this.r;
        }
        public void setR(double x)
        {
            r = x > 0.1 ? x : 0.1;
        }
        // властивості (property)
        public double R
        {
            get // double get()
            {
                return this.r;
            }
            set // void set(double value)
            {
                this.r = value > 0.1 ? value : 0.1;
            }
        }
    }
    /* Квадрат - це прямокутник, у якого всі сторони рівні.
     * Цю обставину зображають наслідуванням класів:
     *      class Square: Rectangle                       */

    [Serializable]
    public class Square : Rectangle
    {
        public Square(double x) : base(x, x) // усю роботу робить конструктор базового класу
        {
            //this.a = x; this.b = x;
        }
        public Square() : base(1, 1)
        { }
        public override string ToString()
        {
            return $"Square[{this.a}]";
        }
        public override double A
        {
            get // double get()
            {
                return this.a;
            }
            set // void set(double value)
            {
                this.a = value > 0.1 ? value : 0.1;
                this.b = this.a;
            }
        }
    }

    [Serializable]
    public class Triangle : Shape
    {
        // сторони трикутника
        private double a;
        private double b;
        private double gamma;
        // конструктори
        public Triangle()
        {
            a = 3;
            b = 4;
            gamma = 90;
        }
        public Triangle(double x, double y, double g)
        {
            a = x > 0.1 ? x : 0.1;
            b = y > 0.1 ? y : 0.1;
            gamma = g < 1 ? 1 : g > 179 ? 179 : g;
        }
        // методи
        public override string ToString()
        {
            return $"Triangle<{this.a}-{this.gamma}-{this.b}>";
        }
        public override double Square()
        {
            return 0.5 * this.a * this.b * Math.Sin(this.gamma / 180.0 * Math.PI);
        }
        public override double Perim()
        {
            return this.a + this.b + this.C;
        }
        // властивості (property)
        public double A
        {
            get // double get()
            {
                return this.a;
            }
            set // void set(double value)
            {
                this.a = value > 0.1 ? value : 0.1;
            }
        }
        public double B
        {
            get // double get()
            {
                return this.b;
            }
            set // void set(double value)
            {
                this.b = value > 0.1 ? value : 0.1;
            }
        }
        public double C
        {
            get
            {
                return Math.Sqrt(a*a+b*b-2.0*a*b*Math.Cos(this.gamma/180.0*Math.PI));
            }
        }
    }
}
