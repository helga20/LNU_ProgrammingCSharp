using System;
namespace DelegateAppl
{
    class StringOp
    {
        delegate int DelegateTwo(string a, string b);
        public static string Addition(string a, string b)
        {
            return a + b;
        }
        public static int LenAddition(string a, string b)
        {
            string c = a + b;
            return c.Length;
        }
        public static int MaxLen(string a, string b)
        {
            int[] lengths = { a.Length, b.Length };
            int greatestLength = lengths.Max();
            return greatestLength;
        }
        public static int NumberYinX(string a, string b)
        {
            int count = 0;
            foreach (char i in a)
            {
                foreach (char j in b)
                {
                    if (i == j)
                    {
                        count += 1;
                        break;
                    }
                }
            }
            return count;
        }
        public static int CountM(string a, string b)
        {
            char m = 'м';
            string s = Addition(a, b);
            int k = s.Count(s => s == m);
            return k;
        }
        public static int Intersection(string a, string b)
        {
            int k = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        k++;
                        break;
                    }
                }
            }
            return k;
        }

        static void Main(string[] args)
        {
            string s1 = "математична";
            string s2 = "статистика";

            Console.WriteLine(s1 + " " + s2);

            string s = Addition(s1, s2);

            Console.WriteLine("\nОб'єднання: " + s);

            Console.WriteLine("\nДовжина '" + s1 + "' = " + s1.Length);
            Console.WriteLine("\nДовжина '" + s2 + "' = " + s2.Length);

            DelegateTwo lenadd = LenAddition;
            Console.WriteLine("\nДовжина об'єднання = " + lenadd(s1, s2));

            DelegateTwo maxl = MaxLen;
            Console.WriteLine("\nДовжина найбiльшої змiнної = " + maxl(s1, s2));

            DelegateTwo yinx = NumberYinX;
            Console.WriteLine("\nК-ть симв. y в x = " + yinx(s1, s2));

            DelegateTwo couM = CountM;
            Console.WriteLine("\nКiлькiсть м = " + couM(s1, s2));

            DelegateTwo inters = Intersection;
            Console.WriteLine("\nДовжина перетину = " + inters(s1, s2));
        }
    }
}

