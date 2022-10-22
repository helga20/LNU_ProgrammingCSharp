using System;
using System.IO;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace StoredShapesCS
{
    class Program
    {
        static void Main(string[] args)
        {
            // початкове створення об'єктів і виведення їх на екран
            Console.WriteLine(" *** The shapes are:");
            Shape[] S = {new Square(5), new Rectangle(4.2,6.1), new Square(),
                         new Triangle(6,6,60), new Circle(5.3), new Rectangle()};
            foreach (Shape x in S) Console.WriteLine(x);
            Console.ReadLine();
            
            // "власноручне" виведення до файла
            string fileName = @"..\..\FlatShapes.txt";
            OutputToFile(S, fileName);
            // демонстрація того, що отримали
            DemoTextFile(fileName);

            // "власноручне" завантаження з файла і контроль отриманого
            ReadFromText(out S, @"..\..\ShapesData.txt");
            Console.WriteLine(S.Length);
            foreach (Shape x in S) Console.WriteLine(x);
            Console.ReadLine();

            // "фірмове" зберігання в двійковому форматі
            fileName = @"..\..\Shapes.bin";
            StoreInBinary(S, fileName);
            S = null;
            // завантаження і контроль отриманого
            LoadFromBinary(out S, fileName);
            Console.WriteLine(" Loaded from binary:\n-------------------------\n");
            foreach (Shape x in S) Console.WriteLine(x);
            Console.ReadLine();

            // "фірмове" зберігання у форматі SOAP
            fileName = @"..\..\Shapes.soap";
            StoreInSoap(S, fileName);
            S = null;
            // завантаження і контроль отриманого
            LoadFromSoap(out S, fileName);
            Console.WriteLine(" Loaded from SOAP:\n-------------------------\n");
            foreach (Shape x in S) Console.WriteLine(x);
            Console.ReadLine();
            // демонстрація внутрішнього влаштування SOAP-файла
            DemoTextFile(fileName);

            // "фірмове" зберігання у форматі XML
            fileName = @"..\..\Shapes.xml";
            StoreInXML(S, fileName);
            // демонстрація внутрішнього влаштування XML-файла
            DemoTextFile(fileName);
            S = null;
            // завантаження і контроль отриманого
            LoadFromXML(out S, fileName);
            Console.WriteLine(" Loaded from XML:\n-------------------------\n");
            foreach (Shape x in S) Console.WriteLine(x);
            Console.ReadLine();
        }

        static void OutputToFile(Shape[] S, string fileName)
        {
            // для виведення до текстового файла використано StreamWriter
            // та метод ToString об'єктів
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine("The collection of flat shapes\n");
            foreach (Shape s in S) writer.WriteLine(s);
            // фігури виведено в різних форматах
            writer.WriteLine("\n and formatted output\n");
            foreach (Shape s in S) writer.WriteLine($"{s:wide}");
            writer.Close();
            Console.WriteLine(" *** Output completed!");
            Console.ReadLine();
        }

        static void DemoTextFile(string fileName)
        {
            // "універсальний метод" - виводить у консоль довільний текстовий файл
            FileInfo file = new FileInfo(fileName);
            if (file.Exists)
            {
                /*FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(fileStream);*/
                StreamReader reader = new StreamReader(fileName);

                Console.WriteLine(" *** The file " + fileName + " contains:\n");
                string line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
                reader.Close();

                Console.WriteLine("\n *** Done!");
            }
            else Console.WriteLine("File " + fileName + " does not exist");
            Console.ReadLine();
        }

        static void StoreInBinary(Shape[] S, string fileName)
        {
            // 1 - отримати серіалізатор
            IFormatter serializer = new BinaryFormatter();
            // 2 - відкрити файловий потік
            FileStream saveFile = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            // 3 - попросити серіалізатор виконати роботу (класи помітити відповідним атрибутом)
            serializer.Serialize(saveFile, S);
            // 4 - закрити потік
            saveFile.Close();
            Console.WriteLine("\n *** Stored to binary\n");
        }

        static void LoadFromBinary(out Shape[] S, string fileName)
        {
            // 1 - отримати серіалізатор
            IFormatter serializer = new BinaryFormatter();
            // 2 - відкрити файловий потік
            FileStream loadFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            // 3 - попросити серіалізатор виконати роботу (потрібне приведення типу)
            S = serializer.Deserialize(loadFile) as Shape[];
            // 4 - закрити потік
            loadFile.Close();
            Console.ReadLine();
        }

        //SOAP-серіалізатор потребує підключення своєї dll
        static void StoreInSoap(Shape[] S, string fileName)
        {
            IFormatter serializer = new SoapFormatter();
            using (Stream saveFile = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(saveFile, S);
            }
            Console.WriteLine("\n *** Stored to SOAP\n");
        }

        static void LoadFromSoap(out Shape[] S, string fileName)
        {
            IFormatter serializer = new SoapFormatter();
            using (Stream loadFile = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                S = serializer.Deserialize(loadFile) as Shape[];
            }
            Console.ReadLine();
        }

        // XML-серіалізатор потребує public типів і конструкторів за замовчуванням
        static void StoreInXML(Shape[] S, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Shape[]),
                new Type[] { typeof(Rectangle), typeof(Square), typeof(Circle), typeof(Triangle)});
            using (Stream saveFile = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(saveFile, S);
            }
            Console.WriteLine("\n *** Stored to XML\n");
        }

        static void LoadFromXML(out Shape[] S, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Shape[]),
                new Type[] { typeof(Rectangle), typeof(Square), typeof(Circle), typeof(Triangle) });
            using (Stream loadFile = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                S = serializer.Deserialize(loadFile) as Shape[];
            }
            Console.ReadLine();
        }

        static void ReadFromText(out Shape[] S, string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                int n = int.Parse(reader.ReadLine());
                S = new Shape[n];
                for (int i = 0; i < n; ++i) S[i] = Shape.ReadShape(reader);

                reader.Close();
            }
            else
            {
                Console.WriteLine("File " + fileName + " does not exist");
                S = null;
            }
        }

    }
}
