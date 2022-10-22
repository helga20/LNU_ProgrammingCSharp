using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineEvent
{
    class Program
    {
        // приклад взаємодії об'єктів за допомогою подій:
        // Car моделює делегатом і набором методів
        // Automobile використовує інфраструктуру event
        static void Main(string[] args)
        {
            Console.WriteLine("------------- Delegate as event handler -------------\n");
            Car a = new Car();
            a.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            Console.WriteLine("..... Speeding up {0}", a.PetName);
            for (int i = 0; i < 7; ++i)
                a.Accelerate(25);
            Console.ReadLine();

            a = new Car("Ferrari", 360);
            a.RegisterWithCarEngine(OnCarEngineEvent);
            a.RegisterWithCarEngine(CarEngineEventHandler);
            for (int i = 50; i < 71; i += 5) a.Accelerate(i);
            a.Accelerate(30);
            a.UnregisterWithCarEngine(CarEngineEventHandler);
            a.Accelerate(20);
            Console.ReadLine();

            Car b = new Car("SungYong", 100);
            b.CurrentSpeed = 10;
            b.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            Console.WriteLine("..... Speeding up {0}", b.PetName);
            for (int i = 0; i < 6; ++i)
                b.Accelerate(20);
            Console.ReadLine();

            Automobile c = new Automobile("Hummer", 90);
            c.AboutToBlow += OnCarEngineEvent;
            c.Exploded += CarEngineEventHandler;
            for (int i = 0; i < 8; ++i)
                c.Accelerate(15);
            Console.ReadLine();
        }
        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n+++ Message From Car Object +++");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("+++++++++++++++++++++++++++++++\n");
        }
        public static void CarEngineEventHandler(string msg)
        {
            Console.WriteLine("\n== very important car message ==");
            Console.WriteLine(":: {0}", msg.ToUpper());
            Console.WriteLine("================================\n");
        }
    }
}
