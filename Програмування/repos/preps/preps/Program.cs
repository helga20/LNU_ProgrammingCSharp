using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace preps
{
    public class Program
    {
        public delegate void Handler(string store, string book, int price);

        [Serializable]
        public class Store
        {
            public Store() { }

            public string Name { get; set; }
            public List<Book> Books { get; set; }

            public event Handler BookSearch;

            public void Append(Book toAdd) => Books.Add(toAdd);
            public void Find(string n)
            {
                foreach (Book b in Books)
                    if (b.Name == n)
                        BookSearch?.Invoke(Name, b.Name, b.Price);
            }

            public override string ToString()
            {
                string response = $"{Name}:\n";
                foreach (Book book in Books)
                    response += $"\t{book}\n";

                return response;
            }

            public void Sort() => Books.Sort(new BookComparer());
        }

        public class BookComparer : IComparer<Book>
        {
            public int Compare(Book x, Book y) => x.Name.CompareTo(y.Name);
        }

        [XmlInclude(typeof(Technical))]
        [XmlInclude(typeof(Normal))]
        [Serializable]
        public class Book
        {
            public Book() { }

            public string Name { get; set; }
            public int Price { get; set; }
            public int Amount { get; set; }

            public override string ToString()
            {
                return this.GetType().Name + " " + $"{Name} costs {Price}. {Amount} left";
            }
        }

        [Serializable]
        public class Technical : Book 
        {
            public Technical() { }
        }

        [Serializable]
        public class Normal : Book 
        {
            public Normal() { }
        }

        static void Main()
        {
            List<Store> data = new();
            string path = "C:\\Users\\ulyan\\source\\repos\\preps\\preps\\Text.txt";

            if (File.Exists(path))
            {
                string[] lines;
                lines = File.ReadAllLines(path);

                for (int i = 0; i < lines.Length; ++i)
                {
                    string[] info = lines[i].Split();
                    data.Add(new Store() { Name = info[0], Books = new List<Book>() });
                    data[i].BookSearch += Respond;
                    for (int j = 1; j < info.Length; j += 4) 
                    {
                        if (info[j] == "T")
                            data[i].Append(new Technical() { Name = info[j + 1], Price = Int32.Parse(info[j + 2]), Amount = Int32.Parse(info[j + 3]) });
                        else
                            data[i].Append(new Normal() { Name = info[j + 1], Price = Int32.Parse(info[j + 2]), Amount = Int32.Parse(info[j + 3]) });
                    }
                }

                foreach (Store s in data)
                {
                    s.Sort();
                    Console.WriteLine(s);
                }

                Console.Write("Choose a store to Serialize: ");
                string name = Console.ReadLine();

                foreach(Store s in data)
                    if (s.Name == name)
                    {
                        XmlSerializer form = new(typeof(Store));
                        using (FileStream fs = new("output.xml", FileMode.OpenOrCreate))
                            form.Serialize(fs, s);
                    }

                Dictionary<string, int> normalBooks = new();
                Dictionary<string, int> normalBooks2 = new();
                int sum = 0;

                foreach (Store s in data)
                {
                    normalBooks[s.Name] = s.Books.OfType<Normal>().Count();

                    var query = from book in s.Books
                                where book.GetType().Name == "Normal"
                                select book.Amount;

                    normalBooks2[s.Name] = query.Sum();

                    sum += (from book in s.Books
                            select book.Amount * book.Price).Sum();
                }

                foreach (KeyValuePair<string, int> entry in normalBooks)
                    Console.WriteLine($"{entry.Key} has {entry.Value} different normal books");
                Console.WriteLine();
                foreach (KeyValuePair<string, int> entry in normalBooks2)
                    Console.WriteLine($"{entry.Key} has total of {entry.Value} normal books");

                Console.WriteLine($"Total price: {sum}");

                Console.Write("\nBook you want to find: ");
                string book_ = Console.ReadLine();

                foreach(Store s in data)
                    s.Find(book_);
            }
            else
                Console.WriteLine("Such file does not exist");
        }

        static void Respond(string store, string book, int price) =>
            Console.WriteLine($"Store {store} has {book}. It's price - {price}");
    }
}
