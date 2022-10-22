using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Point section\n----------------");
            Point S;
            S.x = 5;
            S.y = 7;
            Point P = new Point();
            Point Q = new Point(-1, 1);
            Console.WriteLine("Our points are: {0}, {1}, {2}.", S, P, Q);
            Console.ReadLine();
            P.addToX(Q.x * 2);
            P.addToY(Q.y * (-3));
            Console.WriteLine("New points are: {0}, {1}, {2}.", S, P, Q);
            Console.ReadLine();

            Console.WriteLine(" Rectangle section\n---------------------");
            Rectangle A = new Rectangle();
            Rectangle B = new Rectangle(7, 2);
            Console.WriteLine("{0} has area {1}", A, A.area());
            Console.WriteLine("{0} has area {1}", B, B.area());
            Console.ReadLine();
            Rectangle[] R = { new Rectangle(), new Square(), new Square(5), new Rectangle(4, 6) };
            for (int i=0; i<R.Length; ++i)
            {
                Console.WriteLine(R[i]);
            }
            foreach (var f in R)
            {
                Console.WriteLine("{0} has area {1}", f, f.area());
            }
            Console.ReadLine();

            Console.WriteLine(" Property section\n--------------------");
            PropeRect T = new PropeRect();
            Console.WriteLine("Old state of T: {0}, area = {1}", T, T.area());
            ++T.A; T.B += 2;
            Console.WriteLine("New state of T: {0}, area = {1}", T, T.area());
            NoisyRect N = new NoisyRect(7, 8);
            Console.WriteLine("Noisy: {0}, area = {1}", N, N.area());
            Console.WriteLine("Sides of rectangle are: {0}, {1}", N.A, N.B);
            Console.ReadLine();
        }
    }
}
