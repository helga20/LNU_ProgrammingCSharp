using System;
using System.Diagnostics;

namespace MemoryUse
{
    class Program
    {
        static void Main(string[] args)
        {
            long available = GC.GetTotalMemory(false);
            Console.WriteLine("Before allocations: {0:N0}", available);

            int allocSize = 40000000;
            byte[] bigArray = new byte[allocSize];
            
            available = GC.GetTotalMemory(false);
            Console.WriteLine("After allocations: {0:N0}", available);

            Process proc = Process.GetCurrentProcess();
            Console.WriteLine("Process Info: "+Environment.NewLine+
                "Private Memory Size: {0:N0}"+Environment.NewLine +
                "Virtual Memory Size: {1:N0}" + Environment.NewLine +
                "Working Set Size: {2:N0}" + Environment.NewLine +
                "Paged Memory Size: {3:N0}" + Environment.NewLine +
                "Paged System Memory Size: {4:N0}" + Environment.NewLine +
                "Non-paged System Memory Size: {5:N0}" + Environment.NewLine,
                proc.PrivateMemorySize64, 
                proc.VirtualMemorySize64, 
                proc.WorkingSet64,
                proc.PagedMemorySize64, 
                proc.PagedSystemMemorySize64,
                proc.NonpagedSystemMemorySize64 );

            Console.ReadKey();
        }
    }
}
