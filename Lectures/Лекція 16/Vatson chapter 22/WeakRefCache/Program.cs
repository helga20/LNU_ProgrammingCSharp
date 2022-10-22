using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WeakRefCache
{
    class Program
    {
        class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
        };

        static void Main(string[] args)
        {
            Cache<int, Book> bookCache = new Cache<int, Book>();
            Random rand = new Random();
            int numBooks = 100;

            //add books to cache
            for (int i=0;i<numBooks;++i)
            {
                bookCache.Add(i, GetBookFromDB(i));                
            }

            //lookup random books and track cache misses
            Console.WriteLine("Looking up books...hit any key to stop");
            long lookups = 0, misses = 0;
            while (!Console.KeyAvailable)
            {
                ++lookups;
                int id = rand.Next(0, numBooks);
                Book book = bookCache.GetObject(id);
                if (book == null)
                {
                    ++misses;
                    book = GetBookFromDB(id);
                }
                else
                {
                    //add a little memory pressure to increase the chances of a GC
                    GC.AddMemoryPressure(100);
                }
                bookCache.Add(id, book);
            }
            Console.ReadKey();
            Console.WriteLine("{0:N0} lookups, {1:N0} misses", lookups, misses);
            Console.ReadLine();
        }

        static Book GetBookFromDB(int id)
        {
            //simulate some database access
            
            return new Book { Id = id, Title = "Book" + id, Author = "Author" + id };
        }
    }
}
