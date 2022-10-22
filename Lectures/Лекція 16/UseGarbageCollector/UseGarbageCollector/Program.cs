using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseGarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" --- Create objects ----------------\n");
            Simple A = new Simple("first");
            Simple B = new Simple("second");
            Simple C = new Simple("third");
            Console.WriteLine("{0} of generation {1}", A, GC.GetGeneration(A));
            Console.WriteLine("{0} of generation {1}", C, GC.GetGeneration(B));
            Console.WriteLine("{0} of generation {1}", A, GC.GetGeneration(C));
            Simple[] D = new Simple[]{new Simple(), new Simple(), new Simple(), new Simple()};
            foreach (Simple s in D) Console.WriteLine("{0} of generation {1}", s, GC.GetGeneration(s));
            Console.ReadLine();

            List<Simple> L = new List<Simple>(6);
            L.Add(A); L.Add(D[1]); L.Add(B); L.Add(D[2]); L.Add(new Simple()); L.Add(new Simple("fourth"));
            foreach (Simple s in L) Console.WriteLine("{0} of generation {1}", s, GC.GetGeneration(s));
            Console.ReadLine();
            // --------------------------------------------------------------------------------------------
            Console.WriteLine(" --- Collect garbage first time ----\n");
            D = null;
            GC.Collect();
            GC.WaitForFullGCComplete();
            L.Add(new Simple()); L.Add(C); L.Add(new Simple("fiveth"));
            foreach (Simple s in L) Console.WriteLine("{0} of generation {1}", s, GC.GetGeneration(s));
            Console.ReadLine();
            // --------------------------------------------------------------------------------------------
            Console.WriteLine(" --- Collect garbage second time ---\n");
            L.RemoveAt(0); L.RemoveAt(1);
            GC.Collect();
            GC.WaitForFullGCComplete();
            L.Add(new Simple("newby"));
            foreach (Simple s in L) Console.WriteLine("{0} of generation {1}", s, GC.GetGeneration(s));
            Console.ReadLine();
            // --------------------------------------------------------------------------------------------
            Console.WriteLine(" --- Collect garbage third time ----\n");
            L.RemoveAt(3); L.RemoveAt(4);
            GC.Collect();
            GC.WaitForFullGCComplete();
            L.Add(new Final("Has Destructor")); L.Add(new Final());
            foreach (Simple s in L) Console.WriteLine("{0} of generation {1}", s, GC.GetGeneration(s));
            Console.ReadLine();
            // --------------------------------------------------------------------------------------------
            Console.WriteLine(" --- Add 50 objs & Remove all ------\n");
            for (int i = 0; i < 50; ++i) L.Add(new Final());
            L.Clear();
            Console.ReadLine();
            GC.Collect(0);
            GC.WaitForFullGCComplete();
            Console.ReadLine();
            // --------------------------------------------------------------------------------------------
            Console.WriteLine(" --- Add some old objects ----------\n");
            L.Add(A); L.Add(B); L.Add(C);
            foreach (Simple s in L) Console.WriteLine("{0} of generation {1}", s, GC.GetGeneration(s));
            Console.ReadLine();
            // --------------------------------------------------------------------------------------------
            Console.WriteLine(" --- Use disposed objects ----------\n");
            using (Disp P = new Disp("Has cleanup method"))
            {
                Console.WriteLine("Working with {0}", P);
            }
            Console.WriteLine();
            L.Add(new Disp()); L.Add(new Disp("disposable"));
            foreach (Simple s in L) Console.WriteLine("{0} of generation {1}", s, GC.GetGeneration(s));
            Console.ReadLine();
            L.Clear();
            GC.Collect();
            GC.WaitForFullGCComplete();
            Console.ReadLine();
            // --------------------------------------------------------------------------------------------
            Console.WriteLine(" --- Use dispoFinalized objects ----\n");
            using (Both P = new Both("Has cleanup & finalize method"))
            {
                Console.WriteLine("Working with {0}", P);
            }
            Console.ReadLine();
            Both H = new Both("Problem");
            Console.WriteLine("{0} of generation {1}", H, GC.GetGeneration(H));
            H.Dispose();
            try
            {
                Console.WriteLine("{0} of generation {1}", H, GC.GetGeneration(H));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
            // --------------------------------------------------------------------------------------------
            Both T = new Both("The last Object");

            Console.WriteLine("====================== The End =====");
        }
    }
}
