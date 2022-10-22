using System;

namespace PointyImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" *** Shapes section");
            Shape[] S = new Shape[4] { new Triangle(), new Circle(), new Hexagon(), new RegularTriangle() };
            for (int i = 0; i < 4; ++i)
            {
                S[i].Draw();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ReadLine();
            Console.WriteLine(" *** Try IPointy section");
            IPointy iPty = null;
            for (int i = 0; i < 4; ++i)
            {
                S[i].Draw();
                try
                {
                    iPty = (IPointy)S[i];
                    Console.WriteLine(iPty.Points);
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine();
            Console.ReadLine();
            Console.WriteLine(" *** IPointy recognition section");
            for (int i = 0; i < 4; ++i)
            {
                S[i].Draw();
                if (S[i] is IPointy)
                    Console.WriteLine(" has {0} points", ((IPointy)S[i]).Points);
                else
                    Console.WriteLine(" is not an IPointy");
            }
            Console.WriteLine();
            Console.ReadLine();
            Console.WriteLine(" *** Type fusion section");
            Knife K = new Knife();
            IPointy[] P = new IPointy[4] { S[0] as IPointy, K, S[2] as IPointy, S[3] as IPointy };
            for (int i = 0; i < 4; ++i)
            {
                Console.WriteLine("{0} has {1} points", P[i], P[i].Points);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
    public interface IPointy
    {
        byte Points { get; }
    }
}
