using System;

namespace PointyImplementation
{
    abstract class Shape
    {
        abstract public void Draw();
    }
    class Circle : Shape
    {
        public override void Draw()
        {
            Console.Write("Circle");
        }
    }
    class Triangle : Shape, IPointy
    {
        public override void Draw()
        {
            Console.Write("Triangle");
        }
        public byte Points
        {
            get { return 3; }
        }
    }
    class Hexagon : Shape, IPointy
    {
        public override void Draw()
        {
            Console.Write("Hexagon");
        }
        public byte Points
        {
            get { return 6; }
        }
    }
    class RegularTriangle : Triangle
    {
        public override void Draw()
        {
            Console.Write("Regular Triangle");
        }
    }
}
