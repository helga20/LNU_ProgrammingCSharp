using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionAppl
{
    class Fraction : IComparable
    {
        private int num;
        private int den;
        // допоміжний метод для скорочення дробів
        private Fraction simplify()
        {
            int a = Math.Abs(num);
            int b = den;
            while (a != b)
            {
                if (a > b) a -= b;
                else b -= a;
            }
            if (a > 1)
            {
                num /= a;
                den /= a;
            }
            return this;
        }
        // конструктори
        public Fraction()
        {
            num = 0;
            den = 1;
        }
        public Fraction(int a, int b)
        {
            num = a;
            if (b > 0) den = b;
            else if (b < 0)
            {
                num = -num;
                den = -b;
            }
            else den = 1;
            simplify();
        }
        // обов'язкове перевантаження
        public override string ToString()
        {
            return string.Format("{0}/{1}", num, den);
        }
        // бінарні операції
        public static Fraction operator +(Fraction lhs, Fraction rhs)
        {
            Fraction res = new Fraction(lhs.num * rhs.den + rhs.num * lhs.den, lhs.den * rhs.den);
            return res.simplify();
        }
        public static Fraction operator -(Fraction lhs, Fraction rhs)
        {
            Fraction res = new Fraction(lhs.num * rhs.den - rhs.num * lhs.den, lhs.den * rhs.den);
            return res.simplify();
        }
        public static Fraction operator *(Fraction lhs, Fraction rhs)
        {
            Fraction res = new Fraction(lhs.num * rhs.num, lhs.den * rhs.den);
            return res.simplify();
        }
        public static Fraction operator /(Fraction lhs, Fraction rhs)
        {
            Fraction res = new Fraction(lhs.num * rhs.den, lhs.den * rhs.num);
            return res.simplify();
        }
        // унарну потрібно перевантажити один раз
        public static Fraction operator ++ (Fraction theFrac)
        {
            return theFrac + new Fraction(1, 1);
        }
        // копіювання - поки що без інтерфейсів
        public Fraction Clone()
        {
            return (Fraction)this.MemberwiseClone();
        }
        // реалізація IComparable
        public int CompareTo(object obj)
        {
            Fraction frac = obj as Fraction;
            int dyscr = this.num * frac.den - frac.num * this.den;
            if (dyscr > 0) return 1;
            else if (dyscr < 0) return -1;
            else return 0;
        }
        public static bool operator >(Fraction lhs, Fraction rhs)
        {
            return lhs.CompareTo(rhs) > 0;
        }
        public static bool operator <(Fraction lhs, Fraction rhs)
        {
            return lhs.CompareTo(rhs) < 0;
        }
        // перетворення типів
        public static explicit operator double(Fraction theFrac)
        {
            return (double)theFrac.num / (double)theFrac.den;
        }
        public static implicit operator Fraction(int anInt)
        {
            return new Fraction(anInt, 1);
        }
        // метод індексатор
        public int this[int i]
        {
            get
            {
                if (i == 0) return num;
                else if (i == 1) return den;
                else return 0;
            }
            set
            {
                if (i == 0)
                {
                    num = value;
                    this.simplify();
                }
                else if (i == 1)
                {
                    if (value > 0)
                    {
                        den = value;
                        this.simplify();
                    }
                    else if (value < 0)
                    {
                        num = -num;
                        den = -value;
                        this.simplify();
                    }
                }
            }
        }
    }
}
