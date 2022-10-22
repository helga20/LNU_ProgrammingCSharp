using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serialize
{
    /*Різноманітні приклади серіалізації. Зверніть увагу на коментарі
     щодо зберігання поліморфних колекцій. Важливо!!!*/
    class Program
    {
        static void Main(string[] args)
        {
            // Використання двійкового серіалізатора для зберігання простих об'єктів
            UserPrefs boyData = new UserPrefs("Brown", 13);
            UserPrefs girlData = new UserPrefs("Pink", 17);
            Console.WriteLine(boyData);
            Console.WriteLine(girlData);
            Console.ReadLine();
            Save(boyData, girlData);
            Console.WriteLine("Saved");
            Console.ReadLine();
            UserPrefs loadedData1, loadedData2;
            Load(out loadedData1, out loadedData2);
            Console.WriteLine("Loaded");
            Console.ReadLine();
            Console.WriteLine(loadedData1);
            Console.WriteLine(loadedData2);
            Console.ReadLine();

            // Використання двійкового серіалізатора для зберігання композитів
            // Створити JamesBondCar і задати стан.
            JamesBondCar jbc = new JamesBondCar();
            jbc.canFly = true;
            jbc.canSubmerge = false;
            jbc.isHatchBack = true;
            jbc.theRadio.stationPresets = new double[] { 89.3, 105.1, 97.1 };
            jbc.theRadio.hasTweeters = true;
            jbc.theRadio.hasSubWoofers = true;
            Console.WriteLine(jbc);
            //Зберегти об'єкт у вказаному файлі в двійковому форматі.
            SaveAsBinaryFormat(jbc, "CarData.dat");
            LoadFromBinaryFile("CarData.dat");
            Console.ReadLine();

            JamesBondCar jbc1 = new JamesBondCar();
            jbc1.canFly = true;
            jbc1.canSubmerge = true;
            jbc1.isHatchBack = false;
            jbc1.theRadio.stationPresets = new double[] { 100.8, 97.1, 104.7 };
            jbc1.theRadio.hasTweeters = false;
            jbc1.theRadio.hasSubWoofers = true;
            Console.WriteLine(jbc1);
            Car simpleCar = new Car();
            simpleCar.isHatchBack = false;
            simpleCar.theRadio.stationPresets = new double[] { 88.4, 92.6 };
            Console.WriteLine(simpleCar);
            Console.ReadLine();

            // Двійковий серіалізатор може більше: зберігання поліморфного списку
            List<Car> list = new List<Car>();
            list.Add(jbc); list.Add(jbc1);
            list.Add(simpleCar);
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream("AllMyCars.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, list);
            }
            list.Clear();
            using (Stream fStream = new FileStream("AllMyCars.bin", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                list = (List<Car>)binFormat.Deserialize(fStream);
            }
            Console.WriteLine("\n --- Cars loaded from bin:\n");
            foreach (var car in list) Console.WriteLine(car);
            Console.ReadLine();

            // Зберігання-відновлення у форматі SOAP
            //   Не забути using System.Runtime.Serialization.Formatters.Soap;
            //   і встановити посилання на System.Runtime.Serialization.Formatters.Soap.dll!
            // Код зберігання одного об'єкта такий самий, як і для двійкової серіалізації
            // SOAP-форматер не підтримує стандартний тип List
            SoapFormatter soapFormat = new SoapFormatter();
            using (Stream fStream = new FileStream("CarsData.soap", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, jbc);
                soapFormat.Serialize(fStream, jbc1);
            }
            JamesBondCar carFromDisk;
            JamesBondCar carFromDisk1;
            using (Stream fStream = new FileStream("CarsData.soap", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                carFromDisk = (JamesBondCar)soapFormat.Deserialize(fStream);
                carFromDisk1 = (JamesBondCar)soapFormat.Deserialize(fStream);
            }
            Console.WriteLine("\n --- Cars loaded from soap:\n");
            Console.WriteLine(carFromDisk);
            Console.WriteLine(carFromDisk1);
            Console.ReadLine();

            // Зберігання-відновлення у форматі XML
            //   Імпортувати System.Xml.Serialization
            // Вказувати тип серіалізованого об'єкта - обов'язково!

            // Зберігання-завантаження одного об'єкта
            XmlSerializer xmlFormat = new XmlSerializer(typeof(JamesBondCar));
            using (Stream fStream = new FileStream("CarData.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, jbc);
            }
            using (Stream fStream = new FileStream("CarData.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                carFromDisk = (JamesBondCar)xmlFormat.Deserialize(fStream);
            }
            Console.WriteLine("\n --- Car loaded from XML:\n");
            Console.WriteLine(carFromDisk);
            Console.ReadLine();
            // Зберігання-завантаження колекції однотипних елементів
            List<JamesBondCar> jbList = new List<JamesBondCar>() { jbc, jbc1 };
            xmlFormat = new XmlSerializer(typeof(List<JamesBondCar>));
            using (Stream fStream = new FileStream("CarsData.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, jbList);
            }
            jbList.Clear();
            using (Stream fStream = new FileStream("CarsData.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                jbList = (List<JamesBondCar>)xmlFormat.Deserialize(fStream);
            }
            Console.WriteLine("\n --- Cars loaded from XML:\n");
            foreach (var car in jbList) Console.WriteLine(car);
            Console.ReadLine();
            // Зберігання-завантаження поліморфної колекції вимагає атрибуту XmlInclude
            // для базового типу елементів з вказанням типу підкласу
            xmlFormat = new XmlSerializer(typeof(List<Car>));
            using (Stream fStream = new FileStream("CarsPoly.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, list);
            }
            list.Clear();
            using (Stream fStream = new FileStream("CarsPoly.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                list = (List<Car>)xmlFormat.Deserialize(fStream);
            }
            Console.WriteLine("\n --- Polimorphic Cars loaded from XML:\n");
            foreach (var car in list) Console.WriteLine(car);
            Console.ReadLine();
        }

        static void Save(UserPrefs a, UserPrefs b)
        {
            // BinaryFormatter зберігає дані в двійковому форматі.
            // Щоб отримати доступ до BinaryFormatter, доведеться
            // імпортувати System.Runtime.Serialization.Formatters.Binary.
            BinaryFormatter binFormat = new BinaryFormatter();
            // Зберегти об'єкт в локальному файлі.
            using (Stream fStream = new FileStream("user.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, a);
                binFormat.Serialize(fStream, b);
            }
        }
        static void Load(out UserPrefs a, out UserPrefs b)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream("user.dat", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                a = (UserPrefs)binFormat.Deserialize(fStream);
                b = (UserPrefs)binFormat.Deserialize(fStream);
            } 
        }
        static void SaveAsBinaryFormat(JamesBondCar objGraph, string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in binary format!\n");
        }
        static void LoadFromBinaryFile(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = File.OpenRead(fileName))
            {
                JamesBondCar carFromDisk = (JamesBondCar)binFormat.Deserialize(fStream);
                Console.WriteLine("Loaded car is ==>\n" + carFromDisk);
            }
        }
    }
}
