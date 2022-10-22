using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentManager
{
    class Program
    {
        static void Main(string[] args)
        {
            DocumentManager<Document> dm = new DocumentManager<Document>();
            dm.AddDocument(new Document("Title A", "List<T> Class Represents a strongly typed list of objects that can be accessed by index"));
            dm.AddDocument(new Document("Title B", "Provides methods to search, sort, and manipulate lists"));
            dm.AddDocument(new Document("Title C", "The List<T> class is the generic equivalent of the ArrayList class"));
            dm.AddDocument(new Document("Title D", "It implements the IList<T> generic interface by using an array whose size is dynamically increased as required"));
            dm.AddDocument(new Document("Title E", "The List<T> class uses both an equality comparer and an ordering comparer"));

            dm.DisplayAllDocuments();
            Console.ReadLine();

            ProcessDocuments<Document, DocumentManager<Document>>.Start(dm);

            System.Threading.Thread.Sleep(200);
            if (dm.IsDocumentAvailable)
            {
                Document d = dm.GetDocument();
                Console.WriteLine(d.Title);
                Console.WriteLine("   " +d.Content);
            }
            Console.ReadLine();
        }
    }
}
