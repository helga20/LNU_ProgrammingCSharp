using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace VolShapesWindowsForms
{
    public static class Procedures
    {
        // набір даних, з якими працює програма
        public static List<VolShape> Shapes = new List<VolShape>();

        // для початку орботи можна використати "набір за замовчуванням"
        // корисно для швидкої перевірки можливостей програми
        public static void CreateDefaultShapes()
        {
            Shapes = new List<VolShape>() { new Cone(), new Cylinder(2, 3),
                new Parallele(3, 4, 2.5), new TriPiramid(3, 3, 60, 5),
                new RectPiramid(6, 6, 4), new TriPrism()};
        }

        // Акумуляція: сумарний об'єм усіх фігур. Обчислення може виконати
        // метод розширення контейнера List, достатньо вказати правильний
        // лямбда-вираз
        public static double CalculateSumOfVolumes()
        {
            return Shapes.Sum(shape => shape.Volume());
        }

        // методи завантаження колекції з файлів різних форматів
        public static void LoadFromTextFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                int n = int.Parse(reader.ReadLine());
                Shapes = new List<VolShape>(n);
                for (int i = 0; i < n; ++i)
                    Shapes.Add(VolShape.ReadShape(reader));
            }
        }
        public static void LoadFromSoapFile(string fileName)
        {
            SoapFormatter serializer = new SoapFormatter();
            using (FileStream loadFile = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                Shapes = new List<VolShape>(serializer.Deserialize(loadFile) as VolShape[]);
            }
        }
        public static void LoadFromBinaryFile(string fileName)
        {
            IFormatter serializer = new BinaryFormatter();
            using (FileStream loadFile = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                Shapes = serializer.Deserialize(loadFile) as List<VolShape>;
            }
        }

        //методи зберігання колекції до файлів різних форматів
        internal static void StoreToTextFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(Shapes.Count);
                foreach (VolShape shape in Shapes)
                    writer.WriteLine(shape.StoreString());
            }
        }
        internal static void StoreToBinaryFile(string fileName)
        {
            IFormatter serializer = new BinaryFormatter();
            using (FileStream saveFile = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(saveFile, Shapes);
            }
        }
        internal static void StoreToSoapFile(string fileName)
        {
            SoapFormatter serializer = new SoapFormatter();
            using (FileStream saveFile = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(saveFile, Shapes.ToArray());
            }
        }
    }
}
