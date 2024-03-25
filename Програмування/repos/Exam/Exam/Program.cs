using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Exam
{
    [Serializable]
    public class Product
    {
        public Product() { }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }

        public override string ToString() => $"Prod ID - {ID} | {Name} | {Category} | Price per one of {Type}/{Price}";
    }

    [Serializable]
    public class Client
    {
        public Client() { }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }

        public override string ToString() => $"Client ID - {ID} | {FirstName} {LastName} | Location {Location}";
    }

    [Serializable]
    public class Order
    {
        public Order() { }

        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public double Amount { get; set; }

        public override string ToString() => $"Client ID - {ClientID} | Order ID - {ProductID} | Amount {Amount}";
    }

    [Serializable]
    public class TaskInfo
    {
        public TaskInfo() { }

        public string FullName { get; set; }
        public string Location { get; set; }

        public List<ProdInfo> Orders { get; set; }

        public override int GetHashCode()
        {
            int hash = 296083 * FullName.Length;
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is TaskInfo)
            {
                TaskInfo other = (TaskInfo)obj;
                if (other.FullName != this.FullName)
                {   
                    return false;
                }
                return true;
            }
            return false;
        }
    }

    [Serializable]
    public class ProdInfo
    {
        public ProdInfo() { }

        public string ProductName { get; set; }
        public double Amount { get; set; }
        public double FullPrice { get; set; }
    }


    class Program
    {
        static public List<T> ReadXML<T>(List<T> container, string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                container = (List<T>)formatter.Deserialize(fs);

            foreach (var c in container)
                Console.WriteLine(c);

            Console.WriteLine("\n");

            return container;
        }

        static void Main()
        {
            List<Product> products = new List<Product>();
            List<Client>  clients  = new List<Client> ();
            List<Order>   orders   = new List<Order>  ();

            products = ReadXML(products, "products.xml");
            clients  = ReadXML(clients,  "clients.xml" );
            orders   = ReadXML(orders,   "orders.xml"  );

            var allData =
                from order   in orders
                join product in products on order.ProductID equals product.ID
                join client  in clients  on order.ClientID  equals client.ID
                orderby $"{client.LastName} {client.FirstName[0]}"
                select new
                {
                    order.ClientID,
                    ClientNameSurname = client.FirstName + " " + client.LastName,
                    ClientFullName = client.FirstName + " " + client.LastName[0],
                    ProductName = product.Name,
                    product.Category,
                    product.Type,
                    order.Amount,
                    FullPrice = order.Amount * product.Price,
                    client.Location
                };

            var clientNames = from a in allData
                              select a.ClientFullName into x
                              group x by x;
            
            // TASK 1
            var task1 = from row in allData
                        orderby row.ClientFullName, row.FullPrice
                        select new { row.ClientFullName, row.ProductName, row.Amount, row.FullPrice };

            string PathTask1 = "task1.txt";

            if (File.Exists(PathTask1))
                File.Delete(PathTask1);

            using StreamWriter writer = new StreamWriter(PathTask1);
            foreach(var cN in clientNames)
            {
                writer.WriteLine(cN.Key);
                foreach (var t1 in task1)
                    if (cN.Key == t1.ClientFullName)
                        writer.WriteLine($"\t{t1.ProductName} with amount {t1.Amount}. It's full price - {t1.FullPrice}");
            }

            // TASK 2
            var task2 = from row in allData
                        orderby row.ClientFullName, row.Category
                        select new TaskInfo
                        {
                            FullName = row.ClientNameSurname,
                            Orders = new List<ProdInfo>(from dat in allData
                                                        orderby dat.ClientFullName, dat.Category
                                                        where row.ClientID == dat.ClientID
                                                        select new ProdInfo { ProductName = dat.ProductName,
                                                            Amount = dat.Amount,
                                                            FullPrice = dat.FullPrice }),
                            Location = row.Location
                        }; 
            
            XmlSerializer formatter = new XmlSerializer(typeof(List<TaskInfo>));
            using (FileStream fs = new FileStream("task2.xml", FileMode.OpenOrCreate))
                formatter.Serialize(fs, (task2.Distinct()).ToList());

            List<TaskInfo> joined = new List<TaskInfo>();
            joined = ReadXML(joined, "task2.xml");


            // TASK 3
            var task3 = from row in joined
                        group row by row.Location into h
                        select new
                        {
                            h.Key,
                            Clients = new List<string>(h.Select(h => h.FullName)),
                            TotalPrice = h.SelectMany(o => o.Orders.Select(o => o.FullPrice)).Sum()
                        };

            string PathTask3 = "task3.txt";

            if (File.Exists(PathTask3))
                File.Delete(PathTask3);

            using StreamWriter writer3 = new StreamWriter(PathTask3);
            foreach (var t3 in task3)
            {
                writer3.WriteLine($"City {t3.Key} - total price {t3.TotalPrice}");
                foreach (var cl in t3.Clients)
                    writer3.WriteLine($"\t{cl}");
            }
        }
    }
}