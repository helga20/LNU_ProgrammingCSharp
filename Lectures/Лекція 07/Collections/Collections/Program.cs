using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Collections
{
    class Program
    {
        static void ObjectCollection()
        {
            ArrayList A = new ArrayList(5);
            A.Add(1);
            A.Add("two");
            A.Add('C');
            A.Add(new Racer(7, "Graham", "Hill", "UK", 14));
            for (int i = 0; i < A.Count; ++i)
            {
                Console.WriteLine("Type {0}, value {1}", A[i].GetType().Name, A[i]);
            }
            Console.ReadLine();
            SortedList L = new SortedList();
            L.Add(50, "going!");
            L.Add(30, "We");
            L.Add(20, "World!");
            L.Add(40, "are");
            L.Add(10, "Hello,");
            //L.Add(30, "We"); // generates an exception
            foreach (var w in L.GetValueList())
                Console.Write(" {0}", w);
            Console.WriteLine();
            for (int k = 50; k >= 10; k -= 10)
                Console.Write(">{0}", L[k]);
            Console.WriteLine();
            Console.ReadLine();
            try
            {
                L[20] = "WORLD!";
                L[25] = "Surprise!";
            }
            catch (Exception e) { Console.WriteLine("An exception occures: {0}", e.Message); }
            foreach (var w in L.GetValueList())
                Console.Write(" {0}", w);
            Console.WriteLine();
            Console.ReadLine();
        }
        static void RacerCollection()
        {
            Racer graham = new Racer(7, "Graham", "Hill", "United Kingdom", 14);
            Racer emerson = new Racer(13, "Emerson", "Fittipaldi", "Brazil", 14);
            Racer mario = new Racer(16, "Mario", "Andretti", "USA", 12);
            List<Racer> racers = new List<Racer>(15) { graham, emerson, mario };
            racers.Add(new Racer(24, "Michael", "Schumacher", "Germany", 91));
            racers.Add(new Racer(27, "Mika", "Hakkinen", "Finland", 20));
            racers.Add(new Racer(15, "Jacques", "Villeneuve", "Canada", 11));
            racers.AddRange(new Racer[] { 
                new Racer(19, "Alan", "Jones", "Australia", 12),
                new Racer(29, "Jackie", "Stewart", "United Kingdom", 27),
                new Racer(30, "James", "Hunt", "United Kingdom", 10),
                new Racer(20, "Jack", "Brabham", "Australia", 14),
                new Racer(30, "Niki", "Lauda", "Austria", 25), 
                new Racer(31, "Alain", "Prost", "France", 51)});
            racers.Insert(3, new Racer(6, "Phil", "Hill", "USA", 3));

            racers.ForEach(г => Console.WriteLine("{0:A} ", г));
            Console.ReadLine();

            int index1 = racers.FindIndex(
                new FindCountry("Finland").FindCountryPredicate);
            int index2 = racers.FindIndex(r => r.Country == "France");
            int index3 = racers.FindIndex(r => r.Country == "Ukraine");
            int index4 = racers.FindIndex(new FindCountry("United Kingdom").FindCountryPredicate);
            Console.WriteLine("Racers found at positions:");
            Console.WriteLine("Finland {0},  France {1},  Ukraine {2},  United Kingdom {3}", index1, index2, index3, index4);
            Console.ReadLine();

            List<Racer> bigWinners = racers.FindAll(r => r.Wins > 20);
            for (int i = 0; i < bigWinners.Count; ++i)
            {
                Console.WriteLine("{0:A}", bigWinners[i]);
            }
            Console.ReadLine();

            List<Racer> newList = new List<Racer>(racers);
            newList.Sort();
            newList.ForEach(Console.WriteLine);
            Console.ReadLine();

            newList.Sort(new RacerComparer(RacerComparer.CompareType.Wins));
            newList.ForEach(Console.WriteLine);
            Console.ReadLine();

            var lookupRacers = racers.ToLookup(r => r.Country);
            Console.WriteLine("--- Racers from Australia:");
            foreach (Racer r in lookupRacers["Australia"])
            {
                Console.WriteLine(r);
            }
            Console.WriteLine("--- Racers from United Kingdom:");
            foreach (Racer r in lookupRacers["United Kingdom"])
            {
                Console.WriteLine(r);
            }
            Console.ReadLine();
        }
        static void SetsCollection()
        {
            Racer[] racers = { new Racer(7, "Graham", "Hill", "UK", 14), new Racer(13, "Emerson", "Fittipaldi", "Brazil", 14),
                             new Racer(16, "Mario", "Andretti", "USA", 12), new Racer(24, "Michael", "Schumacher", "Germany", 91),
                             new Racer(27, "Mika", "Hakkinen", "Finland", 20), new Racer(30, "Niki", "Lauda", "Austria", 25),
                             new Racer(31, "Alain", "Prost", "France", 51), new Racer(6, "Phil", "Hill", "USA", 3)};
            SortedSet<Racer> setOfRacers = new SortedSet<Racer>(new RacerComparer(RacerComparer.CompareType.Wins));
            for (int i = 0; i < racers.Length; ++i ) setOfRacers.Add(racers[i]);
            foreach (Racer r in setOfRacers) Console.WriteLine(r);
            Console.ReadLine();
            Console.WriteLine("Maximal wins has {0:A}", setOfRacers.Min);
            Console.WriteLine("Minimal wins has {0:A}", setOfRacers.Max);
            Console.ReadLine();
            SortedSet<Racer> setOfNames = new SortedSet<Racer>(new RacerComparer(RacerComparer.CompareType.Lastname));
            for (int i = 0; i < racers.Length; ++i) setOfNames.Add(racers[i]);
            foreach (Racer r in setOfNames) Console.WriteLine(r);
            Console.ReadLine();
            setOfRacers.IntersectWith(setOfNames);
            foreach (Racer r in setOfRacers) Console.WriteLine(r);
            Console.ReadLine();
        }
        static void LinkedCollection()
        {
            LinkedList<Racer> LLR = new LinkedList<Racer>();
            LLR.AddFirst(new Racer(1, "Adam", "Smith", "USA", 5));
            LLR.AddLast(new Racer(2, "Boris", "Smith", "USA", 8));
            Console.WriteLine(LLR.First.Next);
            Console.WriteLine("{0:A}", LLR.First.Next.Value);
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("--- Object Collection Section ---");
            ObjectCollection();
            Console.WriteLine("--- Generic Collection Section ---");
            RacerCollection();
            Console.WriteLine("--- Sets Collection Section ---");
            SetsCollection();
            Console.WriteLine("--- Linked Collection Section ---");
            LinkedCollection();
        }
    }
    public class FindCountry
    {
        public FindCountry(string country)
        {
            this.country = country;
        }
        private string country;
        public bool FindCountryPredicate(Racer racer)
        {
            if (racer == null) throw new ArgumentNullException("racer");
            return racer.Country == country;
        }
    } 

}
