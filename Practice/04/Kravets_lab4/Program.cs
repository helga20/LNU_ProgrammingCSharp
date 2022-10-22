using System;

namespace MyApp
{
    class Book
    {
        protected string author;
        protected string title;
        protected string edition;
        protected int year;

        public Book()
        {
            author = "no author";
            title = "no title";
            edition = "no edition";
            year = 0;
        }
        public Book(string a, string t, string e, int y)
        {
            author = a;
            title = t;
            edition = e;
            year = y;
        }
        public string setAuthor
        {
            get{ return author; }
            set{ author = value; }
        }
        public string setTitle
        {
            get { return title; }
            set { title = value; }
        }
        public string setEdition
        {
            get { return edition; }
            set { edition = value; }
        }
        public int setYear
        {
            get { return year; }
            set { year = value; }
        }
        public override string ToString()
        {
            return string.Format("Author : {0}\nTitle : {1}\nEdition : {2}\nYear : {3}", author, title, edition, year);

        }

        public class Monograph : Book
        {
            protected int pages;
            protected int illustrations;

            public Monograph()
            {
                pages = 0;
                illustrations = 0;
            }
            public Monograph(string a, string t, string e, int y, int p, int i) : base(a, t, e, y)
            {
                pages = p;
                illustrations = i;
            }
            public int setPages
            {
                get { return pages; }
                set { pages = value; }
            }
            public int setIllustrations
            {
                get { return illustrations; }
                set { illustrations = value; }
            }
            public override string ToString()
            {
                return base.ToString() + "\nNumber of pages : " + pages.ToString() + "\nNumber of illustrations : " + illustrations.ToString();

            }
            public double Number_printed_pages()
            {
                double n = pages / 32;
                return  n;
            }
        }

        static void Main(string[] args)
        {
            Book b1 = new Book();
            Console.WriteLine(b1);
            Console.WriteLine("--------------------------------------");

            Book b2 = new Book("Victor Hugo", "The Hunchback of Notre-Dame", "Gosselin", 1831);
            Console.WriteLine(b2);
            Console.WriteLine("--------------------------------------");

            Book b3 = new Monograph();
            Console.WriteLine(b3);
            Console.WriteLine("--------------------------------------");

            Book b4 = new Monograph("John Green", "The Fault in Our Stars", "Dutton Books", 2012, 313, 1);
            Book b5 = new Monograph("Miguel de Cervantes", "Don Quixote", "Francisco de Robles", 1612, 863, 3);
            Book b6 = new Monograph("Victor Hugo", "The Hunchback of Notre-Dame", "Gosselin", 1831, 940, 2);

            Console.WriteLine(b4);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(b5);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(b6);
            Console.WriteLine("--------------------------------------");


            Monograph[] b = new Monograph[3] { (Monograph)b4, (Monograph)b5, (Monograph)b6 };
            double[] pages = new double[b.Length];
            for (int i = 0; i < b.Length; i++)
            {
                pages[i] = b[i].Number_printed_pages();
            }

            Array.Sort(pages);
            for (int i = 0; i < b.Length; i++)
            {
                Console.WriteLine("\nNumber of printed pages : " + pages[i]);
            }

        }
    }
}