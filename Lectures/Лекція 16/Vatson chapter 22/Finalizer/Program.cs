using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finalizer
{
    class Program
    {
        static void Main(string[] args)
        {
            MyWrappedResource res = new MyWrappedResource("TestFile.txt");
            
            //eh, don't bother closing...
            //

        }
    }
}
