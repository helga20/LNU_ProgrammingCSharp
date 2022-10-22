using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10
{
    abstract class Progression
    {
        protected double first_member;
        protected double d_or_q;
        public Progression(double first_member, double d_or_q)
        {
            this.first_member = first_member;
            this.d_or_q = d_or_q;
        }
        public double setFirst_member
        {
            get { return first_member; }
            set { first_member = value; }
        }
        public double setD_or_q
        {
            get { return d_or_q; }
            set { d_or_q = value; }
        }
        public virtual double Sum_of_prog(int n)
        {
            double sum = 0.0;
            return sum;
        }
        public virtual double N_member(int n)
        {
            double a_n = 0.0;
            return a_n;
        }
        public override string ToString()
        {
            return string.Format("Перший член прогресiї: {0}\nd або q: {1}\n", first_member, d_or_q);
        }
        public abstract void Print_info();
    }
    class ArithmeticProgression : Progression
    {
        protected double sum;
        public ArithmeticProgression(double first_member, double d_or_q) : base(first_member, d_or_q)
        {
            this.d_or_q = d_or_q;
            if (d_or_q == 0)
            {
                throw new ArgumentException(String.Format("{0} can not be", d_or_q),
                                          "d");
            }
        }
        public override double N_member(int n)
        {
            return first_member + d_or_q * (n - 1);
        }
        public override double Sum_of_prog(int n)
        {
            sum = 0.5 * d_or_q * Math.Pow(n, 2) + ((first_member - 0.5 * d_or_q) * n);
            return sum;
        }
        public override void Print_info()
        {
            Console.WriteLine("Сума арифметичної прогресiї = " + sum);
        }
        public override string ToString()
        {
            return string.Format("Перший член прогресiї: {0}\nd: {1}", first_member, d_or_q);
        }
        public static bool operator <(ArithmeticProgression a, ArithmeticProgression b)
        {
            return a.sum < b.sum;
        }
        public static bool operator >(ArithmeticProgression a, ArithmeticProgression b)
        {
            return a.sum > b.sum;
        }
        public static ArithmeticProgression operator +(ArithmeticProgression a, ArithmeticProgression b)
            => new ArithmeticProgression(a.first_member + a.first_member, a.d_or_q + b.d_or_q);
    }

    class GeometryProgression : Progression
    {
        protected double sum;
        public GeometryProgression(double first_member, double d_or_q) : base(first_member, d_or_q)
        {
            this.d_or_q = d_or_q;
            if (d_or_q == 0 && Math.Abs(d_or_q) != 1)
            {
                throw new ArgumentException(String.Format("{0} can not be", d_or_q),
                                          "q");
            }
        }
        public override double N_member(int n)
        {
            return first_member + Math.Pow(d_or_q, n - 1);
        }
        public override double Sum_of_prog(int n)
        {
            sum = first_member * (1 - Math.Pow(d_or_q, n)) / (1 - d_or_q);
            return sum;
        }
        public override string ToString()
        {
            return string.Format("Перший член прогресiї: {0}\nq: {1}", first_member, d_or_q);
        }
        public override void Print_info()
        {
            Console.WriteLine("Сума геометричної прогресiї = " + sum);
        }
        public static bool operator <(GeometryProgression a, GeometryProgression b)
        {
            return a.sum < b.sum;
        }
        public static bool operator >(GeometryProgression a, GeometryProgression b)
        {
            return a.sum > b.sum;
        }
        public static GeometryProgression operator +(GeometryProgression a, GeometryProgression b)
           => new GeometryProgression(a.first_member + a.first_member, a.d_or_q + b.d_or_q);
    }

static class Program
    {
        static void Main()
        {
            //GeometryProgression B = new GeometryProgression(1, 3, 2);
            //B.Sum_of_prog(2);
            //Console.WriteLine(B);
            
            
            //ArithmeticProgression C = new ArithmeticProgression(1, 3, 2);
            //C.Sum_of_prog(2);
            //C.Print_info();


            ArithmeticProgression ap1 = new ArithmeticProgression(1, 2);
            GeometryProgression gp2 = new GeometryProgression(3, 7);
            ArithmeticProgression ap3 = new ArithmeticProgression(2, 1);
            ArithmeticProgression ap4 = new ArithmeticProgression(6, 1);
            GeometryProgression gp5 = new GeometryProgression(10, 6);
            ap1.Sum_of_prog(2);
            gp2.Sum_of_prog(2);
            ap3.Sum_of_prog(2);
            ap4.Sum_of_prog(2);
            gp5.Sum_of_prog(2);
            ap1.Print_info();
            gp2.Print_info();
            ap3.Print_info();
            ap4.Print_info();
            gp5.Print_info();

        }
    }
}
