using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            TList L = new TList();
            L.AddLast(2);
            L.AddLast(4.5);
            L.AddLast('F');
            L.AddLast(new Node(129.99M, null));
            L.AddLast("bye!");
            foreach (var i in L)
            {
                Console.WriteLine("{0}: {1}", i.GetType().Name, i);
            }
            Console.ReadLine();
            TList<int> Li = new TList<int>();
            Li.AddLast(2);
            Li.AddLast(4);
            Li.AddLast(8);
            Li.AddLast(16);
            foreach (int i in Li)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
