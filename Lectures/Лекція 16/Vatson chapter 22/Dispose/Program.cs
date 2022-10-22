using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dispose
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyWrappedResource res = new MyWrappedResource("TestFile.txt"))
            {
                Console.WriteLine("Using resource...");
            }

            MyWrappedResource res2 = new MyWrappedResource("TestFile.txt");
            Console.WriteLine("Created a new resource, exiting");
            //don't cleanup--let finalizer get it!
        }
    }
}
