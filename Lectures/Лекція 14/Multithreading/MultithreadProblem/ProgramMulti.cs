using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadProblem
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
        public void PrintNumbers(object obj)
        {
            Console.WriteLine("* PrintNumbers cover *");
            PrintNumbers();
        }

        // Маркер блокування.
        private object threadLock = new object();
        public void PrintNumbersWithLock()
        {
            // Захоплення маркера блокування
            lock (threadLock)
            {
                // друкуємо ім'я потоку виконання
                Console.WriteLine("\n-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);
                // власне робота
                Console.Write("Your numbers: ");
                for (int i = 1; i < 10; i++)
                {
                    Console.Write("{0}, ", i);
                    Thread.Sleep(500);
                }
                Console.WriteLine("10");
            }
        }
    }
    class ProgramMulti
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Synchronizing Threads *****\n");
            Printer p = new Printer();
            // Створити 10 потоків, які вказувют на один
            // і той самий метод єдиного об'єкта.
            Thread[] threads = new Thread[10];

            Console.WriteLine(" --- without locking");
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbers));
                threads[i].Name = string.Format("Worker thread #{0}", i);
            }
            // Тепер запустити їх усіх.
            foreach (Thread t in threads) t.Start();
            Console.ReadLine();

            Console.WriteLine(" --- by lock object");
            for (int i = 1; i < 6; i++)
            {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbersWithLock));
                threads[i].Name = string.Format("Locking worker thread #{0}", i);
            }
            // Тепер запустити їх усіх.
            for (int i = 1; i < 6; ++i) threads[i].Start();
            Console.ReadLine();

            // ВИКОРИСТАННЯ ПУЛУ ПОТОКІВ
            Console.WriteLine("***** Fun with the CLR Thread Pool *****\n");
            Console.WriteLine("Main thread started. ThreadID = {0}", Thread.CurrentThread.ManagedThreadId);
            // делегат WaitCallback приймає один параметр object. Для виклику в потоці методів з іншою сигнатурою потрібна обгортка
            WaitCallback workItem = new WaitCallback(PrintTheNumbers);
            // Поставити в чергу метод десять разів.
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(workItem, p);
            }
            ThreadPool.QueueUserWorkItem(p.PrintNumbers);
            Console.WriteLine("All tasks queued");
            Console.ReadLine();
       }
        static void PrintTheNumbers(object state)
        {
            Printer task = (Printer)state;
            task.PrintNumbers();
        }
    }
}
