using System;

namespace VolShapesWindowsForms
{
    /* Кожна об'ємна фігура містить основу (плоску фігуру) і висоту,
     * вміє повідомляти свої об'єм і площі: основи, бічної поверхні, загальну.
     * Фігури можна порівнювати. Клас вміє читати фігури з потоку, фігури
     * вміють будувати рядок-зображення і рядок-зберігання.
     * Усі підкласи поділено на прямі та конічні фігури.
     */
    [Serializable]
    public abstract class VolShape: IComparable<VolShape>
    {
        protected Shape Base;
        protected double h;
        public VolShape() { Base = null; h = 0.0; }
        public VolShape(Shape s, double x) { Base = s; h = x; }
        public double BaseSquare()
        {
            return Base.square();
        }
        public abstract double Volume();
        public abstract double SideSquare();
        public abstract double WholeSquare();

        public abstract string StoreString();

        public int CompareTo(VolShape other)
        {
            return this.Volume().CompareTo(other.Volume());
        }
        public static bool operator>(VolShape A, VolShape B)
        {
            return A.CompareTo(B) > 0;
        }
        public static bool operator <(VolShape A, VolShape B)
        {
            return A.CompareTo(B) < 0;
        }
        public static VolShape ReadShape(System.IO.StreamReader stream)
        {
            string[] data = stream.ReadLine().Split();
            switch (data[0].ToLower())
            {
                case "cylinder": return new Cylinder(double.Parse(data[1]), double.Parse(data[2]));
                case "parallele": return new Parallele(double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]));
                case "triprism": return new TriPrism(double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]), double.Parse(data[4]));
                case "cone": return new Cone(double.Parse(data[1]), double.Parse(data[2]));
                case "rectpiramid": return new RectPiramid(double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]));
                case "tripiramid": return new TriPiramid(double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]), double.Parse(data[4]));
                default: throw new TypeLoadException($"Невідомий тип фігури '{data[0]}'");
            }
        }
    }
    [Serializable]
    public abstract class DirectShape : VolShape
    {
        public DirectShape() : base() { }
        public DirectShape(Shape s, double x) : base(s, x) { }
        public override double Volume()
        {
            return Base.square() * h;
        }
        public override double SideSquare()
        {
            return Base.perim() * h;
        }
        public override double WholeSquare()
        {
            return 2.0 * BaseSquare() + SideSquare();
        }
    }
    [Serializable]
    public class Cylinder : DirectShape
    {
        public Cylinder() : base(new Circle(), 1.0) { }
        public Cylinder(double r, double h) : base(new Circle(r), h) { }
        public override string ToString()
        {
            return String.Format("Cylinder of high {0} based on {1}", h, Base);
        }
        public override string StoreString()
        {
            return $"cylinder {(Base as Circle).R} {h}";
        }
    }
    [Serializable]
    public class Parallele : DirectShape
    {
        public Parallele() : base(new Rectangle(), 1.0) { }
        public Parallele(double a, double b, double c) : base(new Rectangle(a, b), c) { }
        public override string ToString()
        {
            return String.Format("Paralelepiped of high {0} based on {1}", h, Base);
        }
        public override string StoreString()
        {
            string rect = Base.ToString();
            int leftBr = rect.IndexOf('[') + 1;
            int ex = rect.IndexOf('x', leftBr);
            int rightBr = rect.IndexOf(']', ex) - 1;
            return $"parallele {rect.Substring(leftBr, ex - leftBr)} {rect.Substring(ex + 1, rightBr - ex)} {h}";
        }
    }
    [Serializable]
    public class TriPrism : DirectShape
    {
        public TriPrism() : base(new Triangle(), 1.0) { }
        public TriPrism(double a, double b, double g, double h) : base(new Triangle(a, b, g), h) { }
        public override string ToString()
        {
            return String.Format("TriPrism of high {0} based on {1}", h, Base);
        }
        public override string StoreString()
        {
            Triangle tr = Base as Triangle;
            return $"triprism {tr.A} {tr.B} {tr.Gamma} {h}";
        }
    }
    [Serializable]
    public abstract class PiramidalShape : VolShape
    {
        public PiramidalShape() : base() { }
        public PiramidalShape(Shape s, double h) : base(s, h) { }
        public override double Volume()
        {
            return Base.square() * h / 3.0;
        }
        public override double WholeSquare()
        {
            return BaseSquare() + SideSquare();
        }
    }
    [Serializable]
    public class Cone : PiramidalShape
    {
        public Cone() : base(new Circle(), 1.0) { }
        public Cone(double r, double h) : base(new Circle(r), h) { }
        public double Lateral
        { 
            get 
            { 
                double r = Base.perim() * 0.5 / Math.PI;
                return Math.Sqrt(h * h + r * r);
            }
        }
        public override double SideSquare()
        {
            return Base.perim() * Lateral * 0.5;
        }
        public override string ToString()
        {
            return String.Format("Cone of high {0} based on {1}", h, Base);
        }
        public override string StoreString()
        {
            return $"cone {(Base as Circle).R} {h}";
        }
    }
    [Serializable]
    public class RectPiramid : PiramidalShape
    {
        public RectPiramid() : base(new Rectangle(), 1.0) { }
        public RectPiramid(double a, double b, double h) : base(new Rectangle(a, b), h) { }
        public override double SideSquare()
        {
            double a = (Base as Rectangle).A;
            double b = (Base as Rectangle).B;
            return a * Math.Sqrt(h * h + b * b * 0.25) + b * Math.Sqrt(h * h + a * a * 0.25);
        }
        public override string ToString()
        {
            return String.Format("RectPiramid of high {0} based on {1}", h, Base);
        }
        public override string StoreString()
        {
            return $"rectpiramid {(Base as Rectangle).A} {(Base as Rectangle).B} {h}";
        }
    }
    [Serializable]
    public class TriPiramid : PiramidalShape
    {
        public TriPiramid() : base(new Triangle(), 1.0) { }
        public TriPiramid(double a, double b, double g, double h) : base(new Triangle(a, b, g), h) { }
        public override double SideSquare()
        {
            double r = 2.0 * Base.square() / Base.perim();
            return 0.5 * Base.perim() * Math.Sqrt(h * h + r * r);
        }
        public override string ToString()
        {
            return String.Format("TriPiramid of high {0} based on {1}", h, Base);
        }
        public override string StoreString()
        {
            Triangle tr = Base as Triangle;
            return $"tripiramid {tr.A} {tr.B} {tr.Gamma} {h}";
        }
    }
}
