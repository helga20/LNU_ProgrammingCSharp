using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10
{
    abstract class Progression
    {
        protected string type;
        protected double first_member;
        protected double d_or_q;
        public Progression()
        {
            type = "";
            first_member = 0.0;
            d_or_q = 0.0;
        }
        public Progression(string type, double first_member, double d_or_q)
        {
            this.type = type;
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
        public string setType
        {
            get { return type; }
            set { type = value; }
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
            return string.Format("Вид прогресії: {0}\nПерший член прогресiї: {1}\nd або q: {2}\n", type, first_member, d_or_q);
        }
        public abstract void Print_info();
    }
    class ArithmeticProgression : Progression
    {
        protected double sum;
        public ArithmeticProgression()
        {
            sum = 0.0;
        }
        public ArithmeticProgression(string type, double first_member, double d_or_q) : base(type, first_member, d_or_q)
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
            => new ArithmeticProgression(a.type + b.type, a.first_member + a.first_member, a.d_or_q + b.d_or_q);
    }

    class GeometryProgression : Progression
    {
        protected double sum;
        public GeometryProgression()
        {
            sum = 0.0;
        }
        public GeometryProgression(string type, double first_member, double d_or_q) : base(type, first_member, d_or_q)
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
           => new GeometryProgression(a.type + b.type, a.first_member + a.first_member, a.d_or_q + b.d_or_q);
    }
}
