using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace UnmanagedMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Memory usage before unmanaged allocation: {0:N0}", GC.GetTotalMemory(false));
            MyDataClass obj = new MyDataClass(10000000);
            
            //unmanaged memory is not counted!
            Console.WriteLine("Memory usage after unmanaged allocation: {0:N0}", GC.GetTotalMemory(false));

            //we should tell the runtime that we really have more memory so it can schedule
            //garbage collection better (note--it still doesn't change the amount that 
            //GC.GetTotalMemory returns)
            GC.AddMemoryPressure(obj.MemorySize);

            Console.ReadKey();
        }
    }
}
