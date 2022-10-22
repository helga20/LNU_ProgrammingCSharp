using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            Country Ukraine = new Country("Україна", 603548, 44130000, 155000000000);
            Country UK = new Country("Велика Британія", 242495, 66273000, 2914000000000);
            Country CzechRepublic = new Country("Чехія", 78866, 10637540, 332000000000);
            Country Poland = new Country("Польща", 312685, 38265000, 1210000000000);
            Country Lithuania = new Country("Литва", 65300, 2784279, 55890000000);

            //List
            Console.WriteLine("*List*\n");
            List<Country> list_countries = new List<Country>(10) { Ukraine, UK, CzechRepublic, Poland, Lithuania };

            foreach (Country c in list_countries)
            {
                Console.WriteLine(c);
                c.printOn();
                Console.WriteLine();
            }

            Console.WriteLine("\n----\n");

            Console.WriteLine("*Впорядкові країни на назвою*\n");
            list_countries.Sort((Country a, Country b) => a.setName.CompareTo(b.setName));
            Console.WriteLine(string.Join("\n\n", list_countries));
            Console.WriteLine("\n----\n");

            Console.WriteLine("*Впорядкові країни на ВВП*\n");
            list_countries.Sort((Country a, Country b) => a.setVVP.CompareTo(b.setVVP));
            Console.WriteLine(string.Join("\n\n", list_countries));
            Console.WriteLine("\n----\n");

            double list_max_population = list_countries.Max(c => c.setPopulation);
            Console.WriteLine("*Найбільш густонаселена країна*");
            foreach (Country con in list_countries)
            {
                if (con.setPopulation == list_max_population)
                {
                    Console.WriteLine(con);
                    con.printOn();
                }
            }
            Console.WriteLine("\n----\n");

            double list_max_vvp = list_countries.Max(c => c.populationDensity());
            Console.WriteLine("*Найбільше ВВП на одну людину*");
            foreach (Country con in list_countries)
            {
                if (con.populationDensity() == list_max_vvp)
                {
                    Console.WriteLine(con);
                    con.printOn();
                }
            }

            Console.WriteLine("\n*****************************************************************");
            Console.ReadLine();

            //LinkedList
            Console.WriteLine("*LinkedList*\n");
            LinkedList<Country> linkedList_countries = new LinkedList<Country>();
            linkedList_countries.AddLast(Ukraine);
            linkedList_countries.AddLast(UK);
            linkedList_countries.AddLast(CzechRepublic);
            linkedList_countries.AddLast(Poland);
            linkedList_countries.AddLast(Lithuania);
            foreach (var c in linkedList_countries)
            {
                Console.Write("{0}", c);
                Console.WriteLine('\n');
            }
            Console.WriteLine("\n----\n");

            Console.WriteLine("*Впорядкові країни на назвою*\n");
            Console.WriteLine(string.Join("\n\n", linkedList_countries.OrderBy(x => x.setName)));
            Console.WriteLine("\n----\n");

            Console.WriteLine("*Впорядкові країни на ВВП*\n");
            Console.WriteLine(string.Join("\n\n", linkedList_countries.OrderBy(x => x.setVVP)));
            Console.WriteLine("\n----\n");

            var linkedList_max_population = linkedList_countries.Max(x => x.setPopulation);
            Console.WriteLine("*Найбільш густонаселена країна*");
            foreach (Country c in linkedList_countries)
            {
                if (c.setPopulation == linkedList_max_population)
                {
                    Console.WriteLine(c);
                    c.printOn();
                }
            }
            Console.WriteLine("\n----\n");

            var linkedList_max_vvp = linkedList_countries.Max(x => x.populationDensity());
            Console.WriteLine("*Найбільше ВВП на одну людину*");
            foreach (Country c in linkedList_countries)
            {
                if (c.populationDensity() == linkedList_max_vvp)
                {
                    Console.WriteLine(c);
                    c.printOn();
                }
            }

            Console.WriteLine("\n*****************************************************************");
            Console.ReadLine();

            //Queue
            Console.WriteLine("*Queue*\n");
            Queue<Country> queue_countries = new Queue<Country>();
            queue_countries.Enqueue(Ukraine);
            queue_countries.Enqueue(UK);
            queue_countries.Enqueue(CzechRepublic);
            queue_countries.Enqueue(Poland);
            queue_countries.Enqueue(Lithuania);
            foreach (var c in queue_countries)
            {
                Console.Write("{0}", c);
                Console.WriteLine('\n');
            }
            Console.WriteLine("\n----\n");

            Console.WriteLine("*Впорядкові країни на назвою*\n");
            Queue<Country> queue_orderedByName = new Queue<Country>(queue_countries.OrderBy(z => z.setName));
            Console.WriteLine(string.Join("\n\n", queue_orderedByName));
            Console.WriteLine("\n----\n");

            Console.WriteLine("*Впорядкові країни на ВВП*\n");
            Queue<Country> queue_orderedByVVP = new Queue<Country>(queue_countries.OrderBy(z => z.setVVP));
            Console.WriteLine(string.Join("\n\n", queue_orderedByVVP));
            Console.WriteLine("\n----\n");

            var queue_max_population = queue_countries.Max(x => x.setPopulation);
            Console.WriteLine("*Найбільш густонаселена країна*");
            foreach (Country c in queue_countries)
            {
                if (c.setPopulation == queue_max_population)
                {
                    Console.WriteLine(c);
                    c.printOn();
                }
            }
            Console.WriteLine("\n----\n");

            var queue_max_vvp = queue_countries.Max(x => x.populationDensity());
            Console.WriteLine("*Найбільше ВВП на одну людину*");
            foreach (Country c in queue_countries)
            {
                if (c.populationDensity() == queue_max_vvp)
                {
                    Console.WriteLine(c);
                    c.printOn();
                }
            }

            Console.WriteLine("\n*****************************************************************");
            Console.ReadLine();

            //Stack   
            Console.WriteLine("*Stack*\n");
            Stack<Country> stack_countries = new Stack<Country>();
            stack_countries.Push(Ukraine);
            stack_countries.Push(UK);
            stack_countries.Push(CzechRepublic);
            stack_countries.Push(Poland);
            stack_countries.Push(Lithuania);
            foreach (var c in stack_countries)
            {
                Console.Write("{0}", c);
                Console.WriteLine('\n');
            }
            Console.WriteLine("\n----\n");

            Console.WriteLine("*Впорядкові країни на назвою*\n");
            Console.WriteLine(string.Join("\n\n", stack_countries.OrderBy(x => x.setName)));
            Console.WriteLine("\n----\n");

            Console.WriteLine("*Впорядкові країни на ВВП*\n");
            Console.WriteLine(string.Join("\n\n", stack_countries.OrderBy(x => x.setVVP)));
            Console.WriteLine("\n----\n");

            var stack_max_population = stack_countries.Max(x => x.setPopulation);
            Console.WriteLine("*Найбільш густонаселена країна*");
            foreach (Country c in stack_countries)
            {
                if (c.setPopulation == stack_max_population)
                {
                    Console.WriteLine(c);
                    c.printOn();
                }
            }
            Console.WriteLine("\n----\n");

            var stack_max_vvp = stack_countries.Max(x => x.populationDensity());
            Console.WriteLine("*Найбільше ВВП на одну людину*");
            foreach (Country c in stack_countries)
            {
                if (c.populationDensity() == stack_max_vvp)
                {
                    Console.WriteLine(c);
                    c.printOn();
                }
            }

            Console.ReadLine();
        
        }
    }
}


/*
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            //SortedList
            Console.WriteLine("*SortedList*\n");
            Country Ukraine = new Country("Україна", 603548, 44130000, 155000000000);
            Country UK = new Country("Велика Британія", 242495, 66273000, 2914000000000);
            Country CzechRepublic = new Country("Чехія", 78866, 10637540, 332000000000);
            Country Poland = new Country("Польща", 312685, 38265000, 1210000000000);
            Country Lithuania = new Country("Литва", 65300, 2784279, 55890000000);

            SortedList sortedlist_countries = new SortedList();
            sortedlist_countries.Add(1, Ukraine);
            sortedlist_countries.Add(2, UK);
            sortedlist_countries.Add(3, CzechRepublic);
            sortedlist_countries.Add(4, Poland);
            sortedlist_countries.Add(5, Lithuania);
            foreach (var c in sortedlist_countries.GetValueList())
            {
                Console.Write("{0}", c);
                Console.WriteLine('\n');
            }
            Console.WriteLine("\n----\n");

            SortedList list_name = new SortedList();
            list_name.Add(Ukraine.setName, Ukraine);
            list_name.Add(UK.setName, UK);
            list_name.Add(CzechRepublic.setName, CzechRepublic);
            list_name.Add(Poland.setName, Poland);
            list_name.Add(Lithuania.setName, Lithuania);
            Console.WriteLine("*Впорядкові країни на назвою*\n");
            foreach (var c in list_name.GetValueList())
            {
                Console.Write("{0}", c);
                Console.WriteLine('\n');
            }
            Console.WriteLine("\n----\n");

            SortedList list_VVP = new SortedList();
            list_VVP.Add(Ukraine.setVVP, Ukraine);
            list_VVP.Add(UK.setVVP, UK);
            list_VVP.Add(CzechRepublic.setVVP, CzechRepublic);
            list_VVP.Add(Poland.setVVP, Poland);
            list_VVP.Add(Lithuania.setVVP, Lithuania);
            Console.WriteLine("*Впорядкові країни на ВВП*\n");
            foreach (var c in list_VVP.GetValueList())
            {
                Console.Write("{0}", c);
                Console.WriteLine('\n');
            }
            Console.WriteLine("\n----\n");
        }
    }
}
*/