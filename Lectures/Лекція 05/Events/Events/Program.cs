using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.Delegates
{
   class Program
   {
      static void Main(string[] args)
      {
         CarFactory factory = new CarFactory();
         Consumer nick = new Consumer("Nick");
         factory.CarCreated += nick.NewCarArrived;

         factory.CreateACar("Ferrari");
         Consumer kimi = new Consumer("Kimi");
         factory.CarCreated += kimi.NewCarArrived;
         Consumer jill = new Consumer("Jill");
         factory.CarCreated += jill.NewCarArrived;

         factory.CreateACar("BMW");
         factory.CreateNCars("Fiat", 5);

         factory.CarCreated -= nick.NewCarArrived;

         factory.CreateACar("Mercedes");
         Console.ReadLine();
      }
   }
}
