using System;
using System.Collections.Generic;
using System.Linq;

namespace Wrox.ProCSharp.LINQ
{
    class SamplesPrg
    {
        static void Main(string[] args)
        {
            TraditionalQuery();
            Console.ReadLine();
            LinqQuery();
            Console.ReadLine();
            ExtensionMethods();
            Console.ReadLine();
            LambdaExpressions();
            Console.ReadLine();
            Final();
            Console.ReadLine();
        }

        // Запити за допомогою виклику методів. Знаходить чемпіонів з Бразилії,
        // впорядковує їх за спаданням кількості перемог.
        private static void TraditionalQuery()
        {
            Console.WriteLine("\n --- Traditional Query ---\n");
            List<Racer> champions = Formula1.GetChampions() as List<Racer>;
            List<Racer> brazilChampions = champions.FindAll(
               delegate(Racer r)
               {
                   return r.Country == "Brazil";
               });

            brazilChampions.Sort(
               delegate(Racer r1, Racer r2)
               {
                   return r2.Wins.CompareTo(r1.Wins);
               });

            foreach (Racer r in brazilChampions)
            {
                Console.WriteLine("{0:A}", r);
            }
        }
        // Та сама робота з використанням LINQ програмується компактніше
        // і зрозуміліше
        private static void LinqQuery()
        {
            Console.WriteLine("\n --- Language Integrated Query ---\n");
            var query = from r in Formula1.GetChampions()
                        where r.Country == "Brazil"
                        orderby r.Wins descending
                        select r;
            foreach (Racer r in query)
            {
                Console.WriteLine("{0:A}", r);
            }
        }
        // методи розширення + анонімні делегати
        private static void ExtensionMethods()
        {
            Console.WriteLine("\n --- Extension Methods Query ---\n");
            IList<Racer> champions = Formula1.GetChampions();
            IEnumerable<Racer> brazilChampions = champions.Where(
               delegate(Racer r)
               {
                   return r.Country == "Brazil";
               }).OrderByDescending(
               delegate(Racer r)
               {
                   return r.Wins;
               }).Select(
               delegate(Racer r)
               {
                   return r;
               });
            foreach (Racer r in brazilChampions)
            {
                Console.WriteLine("{0:A}", r);
            }
        }
        // методи розширення + лямбда-вирази
        private static void LambdaExpressions()
        {
            Console.WriteLine("\n --- Extension Methods with lambdas Query ---\n");
            IList<Racer> champions = Formula1.GetChampions();
            IEnumerable<Racer> brazilChampions = champions.
               Where(r => r.Country == "Brazil").
               OrderByDescending(r => r.Wins).
               Select(r => r);

            foreach (Racer r in brazilChampions)
            {
                Console.WriteLine("{0:A}", r);
            }
        }
        // ускладнений приклад знаходить чемпіонів двох країн, використовує
        // двохрівневий критерій сортування
        private static void Final()
        {
            Console.WriteLine("\n --- Query about UK & Germany ---\n");
            var query = from r in Formula1.GetChampions()
                        where r.Country == "UK" || r.Country == "Germany"
                        orderby r.Wins descending, r.FirstName
                        select r;
            foreach (Racer r in query)
            {
                Console.WriteLine("{0:A}", r);
            }
        }
    }
}
