using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateUse
{
    class Program
    {
        // Integral - функція вищого порядку, яка першим параметром приймає делегат, підінтегральну функцію
        delegate double UnFunction(double x);
        delegate void BinaryAction(int a, int b);
        static void Main(string[] args)
        {
            // "чемне" створення делегата
            double a = Integral(new UnFunction(UserFunc.F1), 0.0, 1.0, 100);
            Console.Write("Integral(x^2,0,1)=" + a);
            Console.ReadLine();

            // створення делегата "на льоту"
            a = Integral(UserFunc.F1, 0.0, 1.0, 200);
            Console.Write("Integral(x^2,0,1)=" + a);
            Console.ReadLine();

            // делегат на основі стандартної функції
            a = Integral(Math.Sin, 0.0, Math.PI, 150);
            Console.Write("Integral(sin(x),0,Pi)=" + a);
            Console.ReadLine();

            // лямбда вираз - "одноразовий" делегат
            a = Integral((x) => {return Math.Sqrt(1.0 - x * x); }, -1.0, 1.0, 250);
            Console.Write("Integral(sqrt(1-x^2),-1,1)=" + a);
            Console.ReadLine();

            // масив делегатів
            MyClass inst = new MyClass();
            BinaryAction[] Act = { inst.InstanceMethod, MyClass.ClassMethod };
            for (int i = 0; i < Act.Length; ++i) Act[i](3, 4);
            Console.ReadLine();

            // груповий делегат
            BinaryAction Actions = inst.InstanceMethod;
            Actions += MyClass.ClassMethod;
            Actions(3, 4);
            Console.ReadLine();

            // перебір методів групового делегата
            foreach (Delegate d in Actions.GetInvocationList())
                Console.WriteLine("{0} {1}", d.Method, d.Target ?? "<No target>");
            Console.ReadLine();
        }
        static double Integral(UnFunction f, double a, double b, int n)
        {
            double h = (b - a) / n;
            double s = (f(a) + f(b)) / 2.0;
            for (int i = 1; i < n; ++i)
                s += f(a + i * h);
            return s * h;
        }
    }

    class UserFunc
    {
        public static double F1(double x)
        {
            return x * x;
        }
    }

    class MyClass
    {
        public static void ClassMethod(int a, int b)
        {
            Console.WriteLine("----------------");
            Console.WriteLine("   {0} + {1} = {2}", a, b, a + b);
            Console.WriteLine("----------------");
        }
        public void InstanceMethod(int a, int b)
        {
            Console.WriteLine(" ..............");
            Console.WriteLine("   {0} = {1} * {2}", a * b, a, b);
            Console.WriteLine(" ..............");
        }
    }
}
