using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace LazyEvaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            Lazy<ICollection<string>> processes = new Lazy<ICollection<string>>(
            //anonymous delegate to do the creation of the value, when needed
                () =>
            {
                List<string> processNames = new List<string>();
                foreach (var p in Process.GetProcesses())
                {
                    processNames.Add(p.ProcessName);
                }
                return processNames;
            });

            PrintSystemInfo(processes, true);
            Console.ReadKey();
        }

        static void PrintSystemInfo(Lazy<ICollection<string>> processNames, bool showProcesses)
        {
            Console.WriteLine("MachineName: {0}", Environment.MachineName);
            Console.WriteLine("OS version: {0}", Environment.OSVersion);
            Console.WriteLine("DBG: Is process list created? {0}", processNames.IsValueCreated);
            if (showProcesses)
            {
                Console.WriteLine("Processes:");
                foreach (string p in processNames.Value)
                {
                    Console.WriteLine(p);
                }
            }
            Console.WriteLine("DBG: Is process list created? {0}", processNames.IsValueCreated);
        }
    }
}
