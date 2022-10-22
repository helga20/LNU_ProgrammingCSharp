using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            TriangleMatrix A = new TriangleMatrix(3);
            A.Output(); Console.WriteLine();
            A[0, 0] = 10;
            A[0, 1] = 20;
            A.Output(); Console.WriteLine();
            int[] v = { 1, 2, 3, 4, 5, 6 };
            TriangleMatrix B = new TriangleMatrix(v);
            B.Output(); Console.WriteLine();
            TriangleMatrix C = A + B;
            C.Output(); Console.WriteLine();
            uint n = C.Size;
            int[,] D = new int[n, n];
            for (uint i = 0; i < n; ++i)
                for (uint j = 0; j < n; ++j)
                    D[i, j] = C[i, j];
            for (uint i = 0; i < n; ++i)
            {
                for (uint j = 0; j < n; ++j) Console.Write("{0,8}", D[i, j]);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
/* (n+1)n/2=k
 * n^2+n-2k=0;   D=1+8k;   n=(-1+sqrt(D))/2
 */