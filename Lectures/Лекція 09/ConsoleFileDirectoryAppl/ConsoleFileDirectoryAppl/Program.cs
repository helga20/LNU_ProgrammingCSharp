using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFileDirectoryAppl
{
    /*Приклади з лекції - взаємодія з файловою системою
     та прості приклади створення файлів*/
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Отримати посилання на поточний робочий каталог.
            DirectoryInfo currentDir = new DirectoryInfo(".");
            PrintDirectoryInfo(currentDir);
            Console.ReadLine();
            // Посилання на конкретний каталог C:\Windows, використано рядок "як є".
            DirectoryInfo windowsDir = new DirectoryInfo(@"C:\Windows");
            PrintDirectoryInfo(windowsDir);
            Console.ReadLine();
            // Посилання на каталог, якого ще нема. Створення.
            DirectoryInfo newDir = new DirectoryInfo(@"C:\Docs\Testing\NewDir");
            PrintDirectoryInfo(newDir);
            Console.ReadLine();
            newDir.Create(); newDir.Refresh();
            newDir.CreateSubdirectory("SubDir");
            PrintDirectoryInfo(newDir);
            Console.ReadLine();
            //newDir.Delete();

            DisplayImageFiles();
            Console.ReadLine();

            FunWithDirectoryType();
            Console.ReadLine();

            FunWithDriveInfo();
            Console.ReadLine();

            FileStreamCreation();
            Console.ReadLine();

            TextFileCreation();
        }
        static void PrintDirectoryInfo(DirectoryInfo dir)
        {
            Console.WriteLine("Name of the directory: \"{0}\"", dir.Name);
            Console.WriteLine("Extension of the name: \"{0}\"", dir.Extension);
            Console.WriteLine("The full name: \"{0}\"", dir.FullName);
            Console.WriteLine("This directory exists: \"{0}\"", dir.Exists);
            Console.WriteLine("This directory attributes: \"{0}\"", dir.Attributes);
            Console.WriteLine("Root of the directory is \"{0}\" named \"{1}\"", dir.Root.GetType().Name, dir.Root.Name);
            Console.WriteLine("Parent of the directory: \"{0}\"", dir.Parent.Name);
            Console.WriteLine("The directory times:\n creation {0}, access {1}, write {2}",
                dir.CreationTime, dir.LastAccessTime, dir.LastWriteTime);
        }
        static void DisplayImageFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");
            // Отримати всі файли з расширенням *.jpg.
            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            // Скільки файлів знайдено?
            Console.WriteLine("Found {0} *.jpg files\n", imageFiles.Length);
            // Вивести інформацію про кожен файл.
            foreach (FileInfo f in imageFiles)
            {
                Console.WriteLine("File name: {0}", f.Name);	  // ім'я файла
                Console.WriteLine("Full path: {0}", f.FullName);  // шлях до файла
                Console.WriteLine("File size: {0} = {1:F2} K", f.Length, (double)f.Length/1024.0);	  // розмір
                Console.WriteLine("Creation: {0}", f.CreationTime); // час створення
                Console.WriteLine("Attributes: {0}\n", f.Attributes); // атрибути
            }
        }
        static void FunWithDirectoryType()
        {
            // Вивести список усіх дискових пристроїв комп'ютера.
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Here are your drives:");
            foreach (string s in drives)
                Console.WriteLine("—> {0} ", s);
            // Вилучити створені раніше папки.
            Console.WriteLine("Press Enter to delete directories (false)");
            Console.ReadLine();
            try
            {
                // Другий параметр вказує, чи вилучати підкаталоги.
                Directory.Delete(@"C:\Docs\Testing", false);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("  once more (true) ...");
            try
            {
                // Другий параметр вказує, чи вилучати підкаталоги (і файли).
                Directory.Delete(@"C:\Docs\Testing", true);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void FunWithDriveInfo()
        {
            Console.WriteLine("***** Fun with DriveInfo *****\n");
            // Отримати інформацію про всі пристрої.
            DriveInfo[] myDrives = DriveInfo.GetDrives();
            // Вивести відомости про пристрої.
            foreach (DriveInfo d in myDrives)
            {
                Console.WriteLine("Name: {0}", d.Name);	      // ім'я
                Console.WriteLine("Type: {0}", d.DriveType);  // тип
                // Перевірити, чи змонтовано пристрій.
                if (d.IsReady)
                {	// Вільний простір
                    Console.WriteLine("Free space: {0}", d.TotalFreeSpace);
                    Console.WriteLine("Format: {0}", d.DriveFormat); // формат
                    Console.WriteLine("Label: {0}", d.VolumeLabel);  // мітка
                }
                Console.WriteLine();
            }
        }
        static void FileStreamCreation()
        {
            // Створити новий файл в робочому каталозі.
            FileInfo f = new FileInfo(@".\Test.dat");
            FileStream fs = f.Create();
            // Дослідимо його можливості
            Console.WriteLine("CanRead = {0}", fs.CanRead);
            Console.WriteLine("CanWrite = {0}", fs.CanWrite);
            Console.WriteLine("CanSeek = {0}", fs.CanSeek);
            string hello = "Hello, World!";

            // Використати об'єкт FileStream...
            foreach (var c in hello) fs.WriteByte((byte)c);
            Console.WriteLine("fs.Position = {0}", fs.Position);
            byte[] end = { 13, 10 };
            fs.Write(end, 0, end.Length);
            // Закрити файловий потік.
            fs.Close();
            Console.ReadLine();

            string we = "We are going!!!";
            // Відкрити файл для дописування через FileInfo.Open() - точніше налаштування.
            FileInfo f2 = new FileInfo(@".\Test.dat");
            // Використаємо контекст using
            using (FileStream fs2 = f2.Open(FileMode.Append, FileAccess.Write, FileShare.None))
            {
                foreach (var c in we) fs2.WriteByte((byte)c);
                Console.WriteLine("fs2.Position = {0}", fs2.Position);
            }
        }

        static void TextFileCreation()
        {
            Console.WriteLine("***** Simple I/O with the File Type *****\n");
            string[] myTasks = { "Fix bathroom sink", "Call Dave", "Call Mom and Dad", "Play Xbox 360"};
            // Записати всі дані до файла в робочому каталозі.
            File.WriteAllLines(@".\tasks.txt", myTasks);
            // Прочитати всі дані та вивести їх на консоль.
            foreach (string task in File.ReadAllLines(@".\tasks.txt"))
            {
                Console.WriteLine("TODO: {0}", task);
            }
            Console.ReadLine();
        }
    }
}
