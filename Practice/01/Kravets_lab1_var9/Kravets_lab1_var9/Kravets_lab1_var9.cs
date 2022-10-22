using System;

namespace Kravets
{
    internal class Kravets_lab1_var9
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please, enter x: ");
            double x = Convert.ToDouble(Console.ReadLine());

            double t;

            if (x < 2)
            {
                t = Math.Cos(x); ;
                if (t < 0)
                {
                    double tempSin1 = Math.Pow(Math.E, t) * Math.Sin(t);
                    Console.WriteLine("y = " + tempSin1);
                }
                else
                {
                    double tempCos1 = Math.Pow(Math.E, t) * Math.Cos(t);
                    Console.WriteLine("y = " + tempCos1);
                }
            }
            else
            {
                t = Math.Log(x);
                if (t < 0)
                {
                    double tempSin2 = Math.Pow(Math.E, t) * Math.Sin(t);
                    Console.WriteLine("y = " + tempSin2);
                }
                else
                {
                    double tempCos2 = Math.Pow(Math.E, t) * Math.Cos(t);
                    Console.WriteLine("y = " + tempCos2);
                }
            }
            Console.ReadLine();
        }
    }
}


//using System;

//namespace Kravets
//{
//    internal class Kravets_lab1_var9
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Please, enter t: ");
//            double t = Convert.ToDouble(Console.ReadLine());

//            Console.WriteLine("Please, enter x: ");
//            double x = Convert.ToDouble(Console.ReadLine());

//            double e = Math.E;
//            double ct = Math.Cos(t);
//            double st = Math.Sin(t);
//            double cx = Math.Cos(x);
//            double lx = Math.Log(x);

//            if (t < 0)
//            {
//                double tempSin = Math.Pow(e, t) * st;
//                Console.WriteLine("y = " + tempSin);
//            }
//            else
//            {
//                double tempCos = Math.Pow(e, t) * ct;
//                Console.WriteLine("y = " + tempCos);
//            }

//            if (x < 2)
//            {
//                Console.WriteLine("t = " + cx);
//            }
//            else
//            {
//                Console.WriteLine("t = " + lx);
//            }

//            Console.ReadLine();
//        }
//    }
//}