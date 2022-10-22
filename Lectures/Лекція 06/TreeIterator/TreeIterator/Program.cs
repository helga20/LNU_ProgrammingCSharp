using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Part1\n-----------------------------------------------------------------");
            int[] A = { 5, 2, 1, 9, 3, 4, 2, 1, 7, 8, 6, 6, 7, 7, 7, 9, 1, 10, 12 };
            for (int i = 0; i < A.Length; ++i) Console.Write(" {0}", A[i]);
            Console.WriteLine();
            BinaryTree B = new BinaryTree();
            B.Add(A);
            B.WriteOut();
            Console.ReadLine();
            foreach (int x in B) Console.Write(" {0}", x);
            Console.ReadLine();
            B.WriteStruct();
            Console.ReadLine();
            int[] C = { 0, 9, 9, 10, 12, 6, 5, 4, 0, 7, 8, 10 };
            for (int i = 0; i < C.Length; ++i)
            {
                Console.WriteLine("The tree contains {0} element {1} times", C[i], B.OccurencesOf(C[i]));
                Console.WriteLine("Result of trying to remove {0} is {1}", C[i], B.Delete(C[i]));
                B.WriteStruct(); Console.ReadLine();
            }
            BinaryTree<int> D = new BinaryTree<int>();
            D.Add(A); D.WriteStruct();
            Console.WriteLine("The tree contains 5 - {0}", D.Contains(5));
            for (int i = 0; i < C.Length; ++i)
            {
                Console.WriteLine("Result of trying to remove {0} is {1}", C[i], D.Remove(C[i]));
                D.WriteStruct(); Console.ReadLine();
            }

            // тестуємо швидкість перебирання елементів масиву: рекурсивне та "послідовне" за допомогою ітератора
            Console.WriteLine("*** Part2\n-----------------------------------------------------------------");
            Random rand = new Random();
            BinaryTree T = new BinaryTree();
            for (int i = 0; i < 50000; ++i) T.Add(rand.Next(5000) - 2500);
            DateTime start = DateTime.Now;
            long S1 = T.SumRec();
            DateTime middle1 = DateTime.Now;
            DateTime middle2 = DateTime.Now;
            long S2 = T.SumIter();
            DateTime stop = DateTime.Now;
            Console.WriteLine("Sum by recursion: {0} took {1} ms", S1, middle1.Subtract(start));
            Console.WriteLine("Sum by iterator : {0} took {1} ms", S2, stop.Subtract(middle2));
            /*
                *** Part2
                -----------------------------------------------------------------
                Sum by recursion: 293601 took 00:00:00.0312500 ms
                Sum by iterator : 293601 took 00:00:00.1250000 ms

                *** Part2
                -----------------------------------------------------------------
                Sum by recursion: 19965 took 00:00:00.0156250 ms
                Sum by iterator : 19965 took 00:00:00.1406250 ms
                *** Part2
                -----------------------------------------------------------------
                Sum by recursion: -230608 took 00:00:00.0625000 ms
                Sum by iterator : -230608 took 00:00:00.1250000 ms
            */
            Console.ReadLine();
/*
            Console.WriteLine("*** Part3\n-----------------------------------------------------------------");
            // тестуємо швидкість вилучення з дерева: власне і "Ватсонівське"
            BinaryTree R = new BinaryTree();
            BinaryTree E = new BinaryTree();
            for (int i = 0; i < 50000; ++i)
            {
                int x = rand.Next(5000) - 2500;
                E.Add(x); R.Add(x);
            }
            int k = 50000;
            int[] V = new int[k];
            for (int i = 0; i < k; ++i) V[i] = rand.Next(5000) - 2500;
            start = DateTime.Now;
            for (int i = 0; i < k; ++i) { E.Rem(V[i]); E.Rem(V[k - i - 1]); }
            middle1 = DateTime.Now;
            middle2 = DateTime.Now;
            for (int i = 0; i < k; ++i) { R.Delete(V[i]); R.Delete(V[k - i - 1]); }
            stop = DateTime.Now;
            Console.WriteLine(" Watson's Rem took {0} ms", middle1.Subtract(start));
            Console.WriteLine("My own Remove took {0} ms", stop.Subtract(middle2));
            
                //*** Part3
                //-----------------------------------------------------------------
                // Watson's Rem took 00:00:00.1562500 ms
                //My own Remove took 00:00:00.0781250 ms

                //*** Part3
                //-----------------------------------------------------------------
                // Watson's Rem took 00:00:00.1093750 ms
                //My own Remove took 00:00:00.0937500 ms

                //*** Part3
                //-----------------------------------------------------------------
                // Watson's Rem took 00:00:00.0937500 ms
                //My own Remove took 00:00:00.0937500 ms
            
            Console.ReadLine();*/
        }
    }
}

