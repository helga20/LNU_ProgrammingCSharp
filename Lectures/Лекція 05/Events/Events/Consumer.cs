using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.Delegates
{
   public class Consumer
   {
      private string name;

      public Consumer(string name)
      {
         this.name = name;
      }

      public void NewCarArrived(object sender, CarInfoEventArgs e)
      {
         Console.WriteLine("Consumer {0}: car ({1}) arrived", name, e.Car);
      }
   }
}
