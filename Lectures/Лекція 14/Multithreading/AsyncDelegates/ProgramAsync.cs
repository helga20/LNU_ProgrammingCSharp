using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDelegates
{
    public delegate int BinaryOp(int x, int у);
    class ProgramAsync
    {
        private static bool isDone = false;

        static void Main(string[] args)
        {
            // 1. СИНХРОННИЙ ВИКЛИК
            Console.WriteLine("***** Synch Delegate Review *****");
            // Вивести ідентифікатор головного потоку.
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            // Викликати Add() в синхронному режимі.
            BinaryOp b = new BinaryOp(Add);
            // Можна було б також написати b.Invoke(10, 10);
            int answer = b(10, 10);
            // Наступні рядки будуть виконані тільки після завершення методу Add().
            Console.WriteLine("Doing more work in Main()!");
            Console.WriteLine("10 + 10 is {0}.", answer);
            Console.ReadLine();

            // 2. АСИНХРОННИЙ ВИКЛИК
            Console.WriteLine("***** Async Delegate Invocation *****");
            // Вивести ідентифікатор головного потоку.
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            // Викликати Add() в породженому потоці.
            IAsyncResult iftAR = b.BeginInvoke(10, 20, null, null);
            // Виконати іншу роботу в головному потоці...
            for (int i = 0; i < 3; ++i)
            {
                Console.WriteLine("Doing more work in Main()!");
                Thread.Sleep(300);
            }
            Console.WriteLine("Main thread is waiting...");
            // Отримати результат методу Add() після завершення.
            // Очікування блокує головний потік.
            answer = b.EndInvoke(iftAR);
            Console.WriteLine("10 + 20 is {0}.", answer);
            Console.ReadLine();

            // 3. АСИНХРОННИЙ ВИКЛИК - ОЧІКУВАННЯ
            Console.WriteLine("***** Async Delegate Invocation & Waiting *****");
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            iftAR = b.BeginInvoke(10, 30, null, null);
            //Повідомлення виводитиметься аж до завершення методу Add() .
            while (!iftAR.IsCompleted)
            // while (!iftAR.AsyncWaitHandle.WaitOne(5OO, true))
            {
                Console.WriteLine("Waiting: doing work in Main()!");
                Thread.Sleep(500);
            }
            // Тепер точно відомо, що метод Add() завершився.
            answer = b.EndInvoke(iftAR);
            Console.WriteLine("10 + 30 is {0}.", answer);
            Console.ReadLine();

            // 4. АСИНХРОННИЙ ВИКЛИК - МЕТОД ЗВОРОТНЬОГО ВИКЛИКУ
            // + передавання спеціальних даних: з головного потоку в метод
            Console.WriteLine("***** AsyncCallbackDelegate Example *****");
            Console.WriteLine("Main() invoked on thread {0}.",
            Thread.CurrentThread.ManagedThreadId);
            // Інформувати про завершення буде спеціальний метод AddComplete
            // Все влаштовано так, що AddComplete також отримає anAsyncResult
            iftAR = b.BeginInvoke(10, 10, new AsyncCallback(AddComplete),
                "Main() thanks you for adding these numbers.");
            // Тут виконується інша робота...
            while (!isDone)
            {
                Thread.Sleep(500);
                Console.WriteLine("Working....");
            }
            Console.WriteLine("Working ended!");
            Console.ReadLine();

        }
        static int Add(int x, int у)
        {
            // Вивести ідентифікатор запущеного потоку.
            Console.WriteLine(" + Add() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            // Організувати паузу для моделювання тривалої операції.
            Thread.Sleep(3000);
            Console.WriteLine(" + Add() had finished.");
            return x + у;
        }
        static void AddComplete(IAsyncResult itfAR)
        {
            Console.WriteLine("AddComplete() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete");
            // отримати "сеціальні дані" та перетворити їх до string.
            string msg = (string)itfAR.AsyncState;
            Console.WriteLine(msg);
            isDone = true;
            // А тепер доберемося до результатів роботи
            AsyncResult ar = (AsyncResult)itfAR;
            BinaryOp b = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("10 + 10 is {0}.", b.EndInvoke(itfAR));
        }
    }
}
