using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchFileAppl
{
    class Program
    {
        /* Приклад спостереження за файловою системою.
         * У презентації до лекції не відображено.
         * Якщо у Вас нема папки "C:\Users\Admin\source\repos",
         * вкажіть у програмі наявну і після запуску програми спробуйте
         * створити/змінити/перейменувати/видалити в ній файл
         */
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            DealWithFileStream();
            Console.ReadLine();

            WatchFilesInPath(@"C:\Users\Admin\source\repos");
        }
        static void DealWithFileStream()
        {
            Console.WriteLine("***** Fun with FileStreams *****\n");
            // Отримати об'єкт FileStream.
            using (FileStream fStream = File.Open(@"..\myMessage.dat", FileMode.Create))
            {	
                // Закодувати рядок у вигляді масиву байтів.
                string msg = "Hello, University!";
                byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);
                // Записати byte[] до файлу.
                fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);
                // Скинути внутрішній вказівник потоку.
                fStream.Position = 0;
                // Прочитати дані з файла і вивести їх на консоль.
                Console.Write("Your message as an array of bytes: ");
                byte[] bytesFromFile = new byte[msgAsByteArray.Length];
                for (int i = 0; i < msgAsByteArray.Length; i++)
                {
                    bytesFromFile[i] = (byte)fStream.ReadByte();
                    Console.Write(bytesFromFile[i]);
                }
                // Вивести декодоване повідомлення.
                Console.Write("\nDecoded Message: ");
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
            }
        }
        static void WatchFilesInPath(string pathName)
        {
            // Встановити шлях до каталога, за яким потрібно спостерігати.
            FileSystemWatcher watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = pathName;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                return;
            }
            // Вказати цілі спостереження.
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Слідкувати тільки за текстовими файлами.
            watcher.Filter = "*.txt";
            // Додати опрацювання подій.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            // Розпочати спостереження за каталогом.
            watcher.EnableRaisingEvents = true;
            // Очікувати команди користувача на завершення програми.
            Console.WriteLine(@"Press 'q' to quit app...");
            while (Console.Read() != 'q') ;
        }
        static void OnChanged(object source, FileSystemEventArgs e)
        {	// Показати, що зроблено, якщо файл змінено, створено чи видалено.
            Console.WriteLine("File \"{0}\" {1}.", e.FullPath, e.ChangeType);
        }
        static void OnRenamed(object source, RenamedEventArgs e)
        {	// Показати, що файл було перейменовано.
            Console.WriteLine("File {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
    }
}
