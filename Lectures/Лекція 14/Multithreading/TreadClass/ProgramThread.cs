using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreadClass
{
    public class Printer
    {
        public void PrintNumbers()
        {
            // друкуємо ім'я потоку виконання
            Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);
            // власне робота
            Console.Write("Your numbers: ");
            for (int i = 1; i < 10; i++)
            {
                Console.Write("{0}, ", i);
                Thread.Sleep(1000);
            }
            Console.WriteLine("10");
        }
        public static void AddNumbers(int a, int b)
        {
            // Вивести ідентифікатор запущеного потоку.
            Console.WriteLine(" + AddNumbers() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            // Організувати паузу для моделювання тривалої операції.
            Thread.Sleep(3000);
            Console.WriteLine(" + The result of adding {0} to {1} is {2}", a, b, a + b);
        }
        public static void PrintTime(object state)
        {
            Console.WriteLine("Time is: {0}, Param is: {1}", DateTime.Now.ToLongTimeString(), state.ToString());
        }

    }
    public class Cover
    {
        Action<int, int> func;
        public Cover(Action<int, int> f)
        {
            func = f;
        }
        public void Add(object obj)
        {
            Tuple<int, int> t = (Tuple<int, int>)obj;
            func(t.Item1, t.Item2);
        }
    }
    class ProgramThread
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Amazing Thread App *****\n");
            Console.Write("Do you want [1] or [2] threads? ");
            string threadCount = Console.ReadLine();

            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";
            Console.WriteLine("-> {0} is executing Main()", Thread.CurrentThread.Name);
            Printer p = new Printer();
            switch(threadCount)
            {
                case "2":
                    // тривала робота в породженому потоці за допомогою делегата
                    Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumbers));
                    backgroundThread.Name = "Secondary";
                    backgroundThread.Start();
                    break;
                case "1":
                    // робота в тому самому потоці
                    p.PrintNumbers();
                    break;
                default: Console.WriteLine("I don't know what you want...you get 1 thread.");
                    goto case "1";
            }
            MessageBox.Show("HELLO! I'm doing something interesting!", "Work on main thread...");
            Console.ReadLine();

            // Передавання параметрів у метод
            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine("ID of thread in Main(): {0}", Thread.CurrentThread.ManagedThreadId);
            // Об'єкт-адаптер інкапсулює необхідну функціональність
            // його метод "розпаковує" вхідні дані, які передає інкапсульованому
            Cover methodCover = new Cover(Printer.AddNumbers);
            Thread t = new Thread(new ParameterizedThreadStart(methodCover.Add));
            t.Start(new Tuple<int, int>(10, 15));
            MessageBox.Show("HELLO! I'm doing something interesting again!", "Work on main thread...");
            Console.ReadLine();

            // Використання таймера для зворотнього виклику методів
            Console.WriteLine("***** Working with Timer type *****\n");
            // Створити делегат для типу Timer.
            TimerCallback timeCB = new TimerCallback(Printer.PrintTime);
            // Встановити параметри таймера.
            System.Threading.Timer timer = new System.Threading.Timer(timeCB, "Hello from Main!", 0, 1000);
            Console.WriteLine("Hit key to terminate...");
            Console.ReadLine();
        }
    }
}
