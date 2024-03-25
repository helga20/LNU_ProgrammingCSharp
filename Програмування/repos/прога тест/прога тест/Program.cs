using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace прога_тест
{
    [Serializable]
    public class Auto
    {
        public Auto() { }

        public int Engine { get; set; }
        public string Mark { get; set; }
        public DateTime ReleaseYear { get; set; }

        public override string ToString() => $"Car {Mark}, it's engine number {Engine}, released {ReleaseYear.ToShortDateString()}";
    }

    [Serializable]
    public class Owner
    {
        public Owner() { }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString() => $"Owner {FirstName} {LastName} his ID {ID}";
    }

    [Serializable]
    public class Ownership
    {
        public Ownership() { }

        public string CarLicense { get; set; }
        public int OwnerID { get; set; }
        public int CarEngine { get; set; }
        public DateTime RegistrationDate { get; set; }

        public override string ToString() => $"Car license {CarLicense}, registered {RegistrationDate.ToShortDateString()} - Owner ID {OwnerID}, Car Engine {CarEngine}";
    }

    class Program
    {
        public static List<T> ReadXML<T>(List<T> container, string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                container = (List<T>)formatter.Deserialize(fs);

            foreach (var c in container)
                Console.WriteLine(c);

            Console.WriteLine("\n");

            return container;
        }

        public static void Main()
        {
            List<Auto> autos = new List<Auto>();
            List<Owner> owners = new List<Owner>();
            List<Ownership> ownerships = new List<Ownership>();

            autos = ReadXML(autos, "autos.xml");
            owners = ReadXML(owners, "owners.xml");
            ownerships = ReadXML(ownerships, "ownerships.xml");

            var joined =
                from ownership in ownerships
                join owner in owners on ownership.OwnerID equals owner.ID
                join auto in autos on ownership.CarEngine equals auto.Engine
                orderby $"{owner.LastName} {owner.FirstName[0]}"
                select new
                {
                    OwnerID = owner.ID,
                    OwnerFullName = owner.FirstName + " " + owner.LastName[0],
                    AutoMark = auto.Mark,
                    ownership.RegistrationDate,
                    auto.ReleaseYear,
                    ownership.CarLicense,
                    InUse = DateTime.Today.Year - auto.ReleaseYear.Year
                };

            foreach (var j in joined)
                Console.WriteLine($"{j.OwnerFullName} - {j.AutoMark} - {j.InUse}");

            // Task 2
            var ownerNames = from j in joined
                      select new { j.OwnerFullName } into h
                      group h.OwnerFullName by h.OwnerFullName;

            var task2 = from j in joined
                        orderby j.OwnerFullName, j.AutoMark
                        where j.InUse < 2
                        select new { j.OwnerFullName, j.AutoMark, j.ReleaseYear };

            XmlWriter xml = XmlWriter.Create("Task2.xml", new XmlWriterSettings { Indent = true });

            xml.WriteStartDocument();
            xml.WriteStartElement("Owners");

            foreach (var o in ownerNames)
            {
                bool nameWritten = false;
                foreach (var t2 in task2)
                {
                    if (t2.OwnerFullName == o.Key)
                    {
                        if (!nameWritten)
                        {
                            xml.WriteStartElement("Owner");
                            xml.WriteStartElement("FullName");
                            xml.WriteString($"{t2.OwnerFullName}");
                            xml.WriteEndElement();

                            nameWritten = true;
                        }

                        xml.WriteStartElement("Auto");

                        xml.WriteStartElement("Mark");
                        xml.WriteString($"{t2.AutoMark}");
                        xml.WriteEndElement();

                        xml.WriteStartElement("ReleaseDate");
                        xml.WriteString($"{t2.ReleaseYear}");
                        xml.WriteEndElement();

                        xml.WriteEndElement();
                    }
                }
                xml.WriteEndElement();
            }

            xml.WriteEndElement();
            xml.WriteEndDocument();
            xml.Close();
        }
    }
}
