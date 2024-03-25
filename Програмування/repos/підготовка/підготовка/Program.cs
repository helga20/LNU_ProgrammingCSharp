using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace підготовка
{
    [Serializable]
    public class Service
    {
        public Service() { }

        public string Name { get; set; }
        public int ID { get; set; }
        public double Price { get; set; }

        public override string ToString() => $"Service ID = {ID} | Name = {Name} | Price = {Price}";
    }

    [Serializable]
    public class Client
    {
        public Client() { }

        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public double Discount { get; set; }

        public override string ToString() => $"Client ID = {ID} | Name = {FirstName} | Surname = {LastName} | Discount = {Discount}";
    }

    [Serializable]
    public class Training
    {
        public Training() { }

        public DateTime Date { get; set; }
        public int ClientID { get; set; }
        public int ServiceID { get; set; }
        public int Hours { get; set; }

        public override string ToString() => $"Date = {this.Date.ToShortDateString()} | Client ID = {ClientID} | Service ID = {ServiceID} | Time Spent = {Hours}";
    }

    class Program
    {
        static public List<T> ReadXML<T>(List<T> container, string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                container = (List<T>)formatter.Deserialize(fs);

            foreach(var c in container)
                Console.WriteLine(c);

            Console.WriteLine("\n");

            return container;
        }

        static void Main()
        {
            List<Client>   clients   = new List<Client>  ();
            List<Service>  services  = new List<Service> ();
            List<Training> trainings = new List<Training>();

            clients   = ReadXML(clients,   "clients.xml");
            services  = ReadXML(services,  "services.xml");
            trainings = ReadXML(trainings, "trainings.xml");

            var query = from t in trainings
                        join c in clients on t.ClientID equals c.ID
                        join s in services on t.ServiceID equals s.ID
                        select new { t.Date.Month, t.Hours, c.Discount, c.FirstName, c.LastName, s.Name, s.Price };

            foreach (var q in query)
                Console.WriteLine($"{q.FirstName} - {q.LastName} - {q.Month} - {q.Hours} - {q.Discount} - {q.Price} - {q.Name}");

            var task1 = from q in query
                        select new { q.FirstName, q.LastName, Total = q.Hours * q.Price * (1 - q.Discount) } into g
                        group g by new { g.FirstName, g.LastName } into h
                        select new { Name = h.Key.FirstName, Surname = h.Key.LastName, Total = h.Sum(x => x.Total) };

            XmlWriter xml = XmlWriter.Create("Task1.xml", new XmlWriterSettings { Indent = true });

            xml.WriteStartDocument();
            xml.WriteStartElement("Clients");

            foreach (var t1 in task1)
            {
                xml.WriteStartElement("Client");
                xml.WriteStartElement("FullName");
                xml.WriteString($"{t1.Name} {t1.Surname}");
                xml.WriteEndElement();
                xml.WriteStartElement("Total");
                xml.WriteString($"{t1.Total}");
                xml.WriteEndElement();
                xml.WriteEndElement();
            }

            xml.WriteEndElement();
            xml.WriteEndDocument();
            xml.Close();

            var task2 = from q in query
                        select new { q.Name, q.Hours, q.Month, Total = q.Hours * q.Price * (1 - q.Discount) } into g
                        group g by new { g.Name, g.Month }  into h
                        select new { Name = h.Key.Name, Month = h.Key.Month, Hours = h.Sum(x => x.Hours), Total = h.Sum(x => x.Total) };

            XmlWriter xml2 = XmlWriter.Create("Task2.xml", new XmlWriterSettings { Indent = true });

            xml2.WriteStartDocument();
            xml2.WriteStartElement("Services");

            foreach (var t2 in task2.OrderBy(x => x.Name))
            {
                xml2.WriteStartElement("Service");

                xml2.WriteStartElement("Name");
                xml2.WriteString($"{t2.Name}");
                xml2.WriteEndElement();

                xml2.WriteStartElement("Month");
                xml2.WriteString($"{t2.Month}");
                xml2.WriteEndElement();

                xml2.WriteStartElement("Payment");      
                xml2.WriteAttributeString("Hours", $"{t2.Hours}");
                xml2.WriteString($"{t2.Total}");
                xml2.WriteEndElement();

                
                xml2.WriteEndElement();
            }

            xml2.WriteEndElement();
            xml2.WriteEndDocument();
            xml2.Close();

            foreach (var t2 in task2)
                Console.WriteLine($"Month: {t2.Month}; {t2.Name} - {t2.Hours} - {t2.Total}");
        }
    }
}

/*          Створення xml файлів для подальшого зчитування
            
            List<Client> clients = new List<Client>();
            List<Service> services = new List<Service>();
            List<Training> trainings = new List<Training>();

            for (int i = 1; i < 5; ++i)
            {
                Service serv = new Service()
                {
                    ID = i,
                    Name = $"Service{i}",
                    Price = 50 * i
                };

                services.Add(serv);
            }

            XmlSerializer formatter = new XmlSerializer(typeof(List<Service>));
            using (FileStream fs = new FileStream("services.xml", FileMode.OpenOrCreate))
                formatter.Serialize(fs, services);
*/