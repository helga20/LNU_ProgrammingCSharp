using System;
namespace ConsoleApp1
{
    class Operations
    {
        protected int A;
        protected int index;
        public Operations(int A, int index)
        {
            this.A = A;
            this.index = index;
            if (A < 0 || A > 64)
            {
                this.A = -1;
                this.index = -1;
            }
        }
        public static Operations operator +(Operations a, Operations b)
        {
            if (a.index == 0 && b.index == 0 && (a.A + b.A) > 64)
            {
                return new Operations(64, 1);
            }
            if (a.index == 1 && b.index == 1 && a.A == 64 && b.A == 64)
            {
                return new Operations(64, 1);
            }
            if (a.index == 1 && b.index == 1 && a.A == 0 && b.A == 64)
            {
                return new Operations(64, 0);
            }
            return new Operations(0, 0);
        }
        public static Operations operator -(Operations a, Operations b)
        {
            if (a.A == 64 && a.index == 1 && b.index == 0)
            {
                return new Operations(64, 1);
            }
            if (a.index == 1 && b.index == 1 && a.A == 64 && b.A == 64)
            {
                return new Operations(64, 0);
            }
            if (a.index == 0 && b.index == 0 && (a.A - b.A) < 0)
            {
                return new Operations(0, 1);
            }
            if (a.index == 0 && b.index == 1 && b.A == 64)
            {
                return new Operations(0, 1);
            }
            if (a.index == 0 && b.index == 0 && a.A == 1 && b.A == 1)
            {
                return new Operations(0, 1);
            }
            return new Operations(0, 0);
        }
        public static Operations operator *(Operations a, Operations b)
        {
            if (a.index == 0 && b.index == 0 && (a.A * b.A) > 64)
            {
                return new Operations(64, 1);
            }
            if (a.index == 1 && b.index == 1 && a.A == 64 && b.A == 64)
            {
                return new Operations(64, 1);
            }
            return new Operations(0, 0);
        }
        public static Operations operator /(Operations a, Operations b)
        {
            if (a.index == 0 && b.index == 0)
            {
                return new Operations(a.A / b.A, 1);
            }
            if (a.index == 1 && b.index == 1 && a.A == 64 && b.A == 64)
            {
                return new Operations(1, 0);
            }
            if (a.index == 1 && b.index == 0 && a.A == 64)
            {
                return new Operations(64, 0);
            }
            return new Operations(0, 0);
        }
        public override string ToString() => $"{A}, {index}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Operations A = new Operations(64, 1);
            Operations B = new Operations(64, 1);
            Console.WriteLine("A - " + A);
            Console.WriteLine("B - " + B);
            Console.WriteLine("A + B - " + (A + B));
            Console.WriteLine("A - B - " + (A - B));
            Console.WriteLine("A * B - " + (A * B));
            Console.WriteLine("A / B - " + (A / B));
        }
    }
}
