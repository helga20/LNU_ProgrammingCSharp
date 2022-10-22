using System;

namespace VolShapesWindowsForms
{
    /* Плоскі геометричні фігури вміють повідомляти свої площі та периметр,
     * будувати рядок-зображення. Кожен конкретний клас фігури визначає відкриті
     * ластивості для читання вимірів фігури.
     */
    [Serializable]
    public abstract class Shape : IComparable
    {
        public abstract double square();
        public abstract double perim();
        public int CompareTo(object obj)
        {
            return this.square().CompareTo(((Shape)obj).square());
        }
        public static bool operator>(Shape a, Shape b)
        {
            return a.CompareTo(b) > 0;
        }
        public static bool operator<(Shape a, Shape b)
        {
            return a.CompareTo(b) < 0;
        }
    }
    [Serializable]
    public class Rectangle : Shape
    {
        protected double a;
        protected double b;
        public Rectangle(double sideA, double sideB)
        { a = sideA; b = sideB; }
        public Rectangle() : this(1.0, 1.0) { }
        public override double square()
        {
            return a * b;
        }
        public double A
        {
            get { return a; }
        }
        public double B
        {
            get { return b; }
        }
        public override double perim()
        {
            return 2.0 * (a + b);
        }
        public override string ToString()
        {
            return String.Format("Rectangle[{0}x{1}]", a, b);
        }
    }
    [Serializable]
    public class Square : Rectangle
    {
        public Square(double side = 1.0) : base(side, side) { }
        public override string ToString()
        {
            return String.Format("Square[{0}]", a);
        }
    }
    [Serializable]
    public class Circle : Shape
    {
        private double r;
        public Circle(double radius) { r = radius; }
        public Circle() : this(1.0) { }
        public override double square()
        {
            return Math.PI * r * r;
        }
        public override double perim()
        {
            return 2.0 * Math.PI * r;
        }
        public override string ToString()
        {
            return String.Format("Circle({0})", r);
        }
        public double R
        {
            get { return r; }
        }
    }
    [Serializable]
    public class Triangle : Shape
    {
        private double a;
        private double b;
        private double gamma;
        public Triangle(double sideA, double sideB, double andle)
        { a = sideA; b = sideB; gamma = andle; }
        public Triangle() : this(1.0, 1.0, 60) { }
        public double A
        { get { return a; } }
        public double B
        { get { return b; } }
        public double C
        { get { return Math.Sqrt(a * a + b * b - 2.0 * a * b * Math.Cos(Math.PI * gamma / 180)); } }
        public double Gamma
        { get { return gamma; } }
        public override double square()
        {
            return 0.5 * a * b * Math.Sin(Math.PI * gamma / 180);
        }
        public override double perim()
        {
            return A + B + C;
        }
        public override string ToString()
        {
            return String.Format("Triangle<{0};{1};{2}\x00B0>", a, b, gamma);
        }
    }
}
