using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Pointers
{
    class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                int x = 0;
                int* pX = &x;
                *pX = 13;

                Console.WriteLine("x = {0}", x);

                Point pt;
                Point* pPt = &pt;
                pPt->X = 13;
                pPt->Y = 14;
                pPt->Offset(1,2);

                Console.WriteLine("pt = {0}", pt);

                List<object> list = new List<object>();
                //List<object>* pList = &list;//won't compile!

                int size = 10;
                int[] vals = new int[size];
                try
                {
                    for (int i = 0; i < size+1; i++)
                    {
                        vals[i] = i;
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Caught exception: " + ex.Message);
                }

                //pointer math
                Console.WriteLine("Pointer arithmetic");
                fixed (int* pI = &vals[0])
                {
                    int* pA = pI;
                    while (*pA < 8)
                    {
                        //increment 2 * sizeof(element)
                        pA += 2;

                        Console.WriteLine("*pA = {0}", *pA);
                    }
                }

                Console.WriteLine("Going out of bounds");
                //prevent vals from moving in memory
                fixed (int* pI = &vals[0])
                {
                    //oops, going to far--overwriting memory we don't own!
                    for (int i = 0; i < size+1; i++)
                    {
                        pI[i] = i;
                    }
                    Console.WriteLine("No exception thrown! We just overwrote memory we shouldn't have!");
                }

                
            }

            Console.ReadKey();
        }
    }
}
