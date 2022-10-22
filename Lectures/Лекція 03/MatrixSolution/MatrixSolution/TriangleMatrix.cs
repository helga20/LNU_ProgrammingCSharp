using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSolution
{
    class TriangleMatrix
    {
        private int[][] mem;
        private uint size;
        public TriangleMatrix()
        {
            size = 2;
            mem = new int[2][];
            mem[0] = new int[2];
            mem[1] = new int[1];
        }
        public TriangleMatrix(uint n)
        {
            size = n > 1 ? n : 2;
            mem = new int[size][];
            for (uint i = 0; i < size; ++i) mem[i] = new int[size - i];
        }
        public TriangleMatrix(int[] v)
        {
            size = ((uint)Math.Sqrt(8 * v.Length + 1) - 1) / 2;
            mem = new int[size][];
            for (uint i = 0; i < size; ++i) mem[i] = new int[size - i];
            int k = 0;
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < mem[i].Length; ++j) mem[i][j] = v[k++];
        }
        public uint Size
        {
            get { return size; }
        }
        public void Output()
        {
            for (uint i = 0; i < size; ++i)
            {
                foreach (int item in mem[i]) Console.Write("{0,8}", item);
                int j = mem[i].Length;
                while (j < size)
                {
                    Console.Write("       0"); ++j;
                }
                Console.WriteLine();
            }
        }
        public static TriangleMatrix operator+(TriangleMatrix A, TriangleMatrix B)
        {
            if (A.Size != B.Size) throw new ArgumentException("Different size of arguments");
            TriangleMatrix C = new TriangleMatrix(A.Size);
            for (int i = 0; i < C.mem.Length; ++i)
                for (int j = 0; j < C.mem[i].Length; ++j)
                    C.mem[i][j] = A.mem[i][j] + B.mem[i][j];
            return C;
        }
        public int this[uint i, uint j]
        {
            get
            {
                if (i >= size || j >= size) throw new IndexOutOfRangeException();
                return j < mem[i].Length ? mem[i][j] : 0;
            }
            set
            {
                if (i >= size || j >= size) throw new IndexOutOfRangeException();
                if (j >= mem[i].Length)
                {
                    if (value != 0) throw new ArgumentOutOfRangeException();
                }
                else mem[i][j] = value;
            }
        }
    }
}
