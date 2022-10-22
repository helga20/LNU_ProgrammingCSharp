using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    abstract class Shape
    {
        protected double s;
        public Shape(double s)
        {
            this.s = s;
        }
        public virtual double Volume()
        {
            return s;
        }
        public abstract void Draw();
    }
    class Parallelepiped : Shape
    {
        protected double y;
        protected double z;
        public Parallelepiped(double s, double y, double z) : base(s)
        {
            this.y = y;
            this.z = z;
        }
        public override double Volume() => s * y * z;
        public override void Draw()
        {
            Console.Write("\nParallelepiped");
            Console.Write("\nV = " + Volume());
        }
    }
    class Tetrahedron : Shape
    {
        public Tetrahedron(double s) : base(s)
        { }
        public override double Volume() => (Math.Pow(s, 3) * Math.Sqrt(2)) / 12;
        public override void Draw()
        {
            Console.Write("\nTetrahedron");
            Console.Write("\nV = " + Volume());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes =
            {
                new Parallelepiped(1, 3, 5),
                new Parallelepiped(2, 4, 2),
                new Tetrahedron(5),
                new Tetrahedron(2)
            };

            System.Console.WriteLine("Shapes Collection");

            foreach (Shape s in shapes)
            {
                s.Volume();
                s.Draw();
                Console.WriteLine("\n--------------------------------------");

            }

            //Shape p = new Parallelepiped(1, 3, 5);
            //            p.Volume();
            //            p.Draw();
            //            Console.WriteLine("\n--------------------------------------");

            //            Shape p1 = new Parallelepiped(2, 3, 3);
            //            p1.Draw();
            //            p1.Volume();
            //            Console.WriteLine("\n--------------------------------------");

            //            Shape t = new Tetrahedron(5);
            //            t.Draw();
            //            t.Volume();
            //            Console.WriteLine("\n--------------------------------------");

            //            Shape t1 = new Tetrahedron(2);
            //            t1.Draw();
            //            t1.Volume();
            //            Console.WriteLine("\n--------------------------------------");
        }
    }
}





