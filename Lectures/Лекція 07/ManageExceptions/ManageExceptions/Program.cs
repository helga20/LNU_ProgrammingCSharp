using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введiть iм'я файла, зi списком осiб > "); 
            string fileName = Console.ReadLine();
            Console.WriteLine("Ви ввели \"{0}\"", fileName);
            Console.ReadLine();
            ColdCallFileReader peopleToRing = new ColdCallFileReader();
            try
            {
                peopleToRing.Open(@"..\..\" + fileName);
                for (int i = 0; i < peopleToRing.NPeopleToRing; i++)
                {
                    peopleToRing.ProcessNextPerson();
                }
                Console.WriteLine("Усi абоненти коректно опрацьованi.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Файл {0} не iснує", fileName);
            }
            catch (ColdCallFileFormatException ex)
            {
                Console.WriteLine("Здається, файл {0} пошкоджено", fileName);
                Console.WriteLine("Подробицi проблеми: {0}", ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Вкладений виняток: {О}", ex.InnerException.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Стався виняток:\n" + ex.Message);
            }
            finally
            {
                peopleToRing.Dispose();
            }
            Console.ReadLine(); 
        }
    }
}
