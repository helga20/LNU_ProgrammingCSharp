using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Schools
{
    class Collection : IEnumerable<Studying_Complex>
    {
        private List<Studying_Complex> coll = new List<Studying_Complex>();

        public void Add(Studying_Complex to_add) =>
            this.coll.Add(to_add);
        public void Delete(int index) =>
            this.coll.RemoveAt(index);

        public void Print()
        {
            foreach (var item in coll)
                Console.WriteLine(item.ToString());
        }

        public void Sort() =>
            coll.Sort();

        public void Sort(IComparer<Studying_Complex> comparer) =>
            coll.Sort(comparer);

        public IEnumerator<Studying_Complex> GetEnumerator() =>
            coll.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            ((IEnumerable)coll).GetEnumerator();
    }

    class NameCompare : IComparer<Studying_Complex>
    {
        public int Compare(Studying_Complex x, Studying_Complex y) =>
            x.Name.CompareTo(y.Name);
    }

    class StudentsCompare : IComparer<Studying_Complex>
    {
        public int Compare(Studying_Complex x, Studying_Complex y) =>
            y.Students.CompareTo(x.Students);
    }

    abstract class Studying_Complex : IComparable
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Students { get; set; }

        public virtual int CompareTo(object obj)
        {
            return Name.CompareTo(((Studying_Complex)obj).Name);
        }

        public abstract override string ToString();
    }

    abstract class Upper : Studying_Complex
    {
        public int Years_of_study { get; set; }

        public override string ToString() =>
            $"{this.GetType().Name}: {Name} in {City} with {Years_of_study} years and {Students} students";
    }

    abstract class Lower : Studying_Complex
    {
        public int Classes { get; set; }

        public override string ToString() =>
            $"{this.GetType().Name}: {Name} in {City} with {Classes} years and {Students} kids studying";
    }

    class University : Upper { }

    class Academy : Upper { }

    class School : Lower { }

    class Lyceum : Lower { }

    class Program
    {
        static void Main()
        {
            string[] data = File.ReadAllLines("C:\\Users\\ulyan\\source\\repos\\Schools\\Schools\\info.txt");

            Console.WriteLine("----OUTPUT----");
            Collection info = read_file(data);
            info.Sort();
            info.Print();

            Console.WriteLine("\n----Upper Students Reverse Sort----");
            Collection only_upper = new Collection();
            foreach (var item in info)
            {
                if (item.GetType() == typeof(Academy) ||
                    item.GetType() == typeof(University))
                    only_upper.Add(item);
            }
            only_upper.Sort(new StudentsCompare());
            foreach (var item in only_upper)
                Console.WriteLine(item);

            Console.WriteLine("\n----Schools in Cities----");
            SortedSet<string> cities = new SortedSet<string>();
            foreach (var item in info)
                cities.Add(item.City);

            foreach (var city in cities)
            {
                Console.WriteLine($"{city}:");
                foreach (var item in info)
                    if (city == item.City && item.GetType() == typeof(School))
                        Console.WriteLine($"\t{item}");
            }
        }

        static Collection read_file(string[] data)
        {
            Collection info = new Collection();
            for (int i = 0; i < data.Length; i++)
            {
                string[] one_el = data[i].Split();

                switch (one_el[0])
                {
                    case "University":
                        info.Add(new University
                        {
                            Name = one_el[1],
                            City = one_el[2],
                            Years_of_study = Int32.Parse(one_el[3]),
                            Students = Int32.Parse(one_el[4])
                        });
                        break;
                    case "Academy":
                        info.Add(new Academy
                        {
                            Name = one_el[1],
                            City = one_el[2],
                            Years_of_study = Int32.Parse(one_el[3]),
                            Students = Int32.Parse(one_el[4])
                        });
                        break;
                    case "School":
                        info.Add(new School
                        {
                            Name = one_el[1],
                            City = one_el[2],
                            Classes = Int32.Parse(one_el[3]),
                            Students = Int32.Parse(one_el[4])
                        });
                        break;
                    case "Lyceum":
                        info.Add(new Lyceum
                        {
                            Name = one_el[1],
                            City = one_el[2],
                            Classes = Int32.Parse(one_el[3]),
                            Students = Int32.Parse(one_el[4])
                        });
                        break;
                }
            }
            return info;
        }
    }
}
