using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartExamples
{
    class StartPrg
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            First(); // запит + методи
            Second();// відкладене виконання
            Third(); // тип результату
            Fourth();// containers
        }

        private static void First()
        {
            Console.WriteLine(" *** LINQ on array\n");
            string[] names = { "Alonso", "Zheng", "Smith", "Jones", "Smythe", "Small", "Ruiz",
                                 "Hsieh", "Jorgenson", "Ilyich", "Singh", "Samba", "Fatimah" };
            var queryResults =    // тип результату вибирає компілятор
                from n in names   // джерело даних
                where n.StartsWith("S")  // операція обмеження
                select n;         // форма елементів результату
            Console.WriteLine("Iмена, що починаються з S:");
            foreach (var item in queryResults)  // виконання запиту
            {
                Console.WriteLine(item);
            }
            Console.Write("Натиснiть Enter ...");
            Console.ReadLine();

            // запит доповнено впорядкуванням
            queryResults =
                from n in names
                where n.StartsWith("S")
                orderby n         // спосіб впорядкування
                select n;
            Console.WriteLine("Впорядкованi iмена, що починаються з S:");
            foreach (var item in queryResults)  // виконання запиту
            {
                Console.WriteLine(item);
            }
            Console.Write("Натиснiть Enter ...");
            Console.ReadLine();

            // те саме за допомогою методів розширення і лямбда
            var qRes = names.Where(n => n.StartsWith("S")).OrderBy(n => n);
            foreach (var item in qRes)  // виконання запиту
            {
                Console.WriteLine(item);
            }
            Console.Write("Натиснiть Enter ...");
            Console.ReadLine();
        }

        // приклад демонструє "ліниву" природу запитів
        private static void Second()
        {
            Console.WriteLine(" *** Вiдкладене виконання\n");
            Console.WriteLine(" - з масивом цілих чисел");
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 4, 50, 5 };

            // запит вибрати з масиву всі числа, менші за 10
            // subset - об'єкт-запит, а не множина чисел
            var subset = from i in numbers where i < 10 select i;
            // Оператор LINQ буде виконано нижче
            foreach (var i in subset)
                Console.WriteLine("{0} < 10", i);
            Console.WriteLine("\n   ще раз");

            // змінюємо масив, щоб переконатися, що запит видасть інший результат
            numbers[0] = 0; numbers[9] = 60;
            // Оператор LINQ знову буде виконано
            foreach (var j in subset)
                Console.WriteLine("{0} < 10", j);

            // повторимо експеримент з іншим масивом
            Console.WriteLine("\n - з контейнером рядків");
            List<string> names = new List<string> { "Nino", "Alberto", "Juan", "Mike", "Phil" };

            // запит на вибір впорядкованого переліку імен, що починаються на J
            var namesWithJ = from n in names
                             where n.StartsWith("J")
                             orderby n
                             select n;
            Console.WriteLine(" - First iteration");
            // перебір змушує запит виконуватися
            foreach (string name in namesWithJ)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            // змінимо джерело даних
            names.Add("John");
            names.Add("Jim");
            names.Add("Jack");
            names.Add("Denny");
            Console.WriteLine(" - Second iteration");
            // і знову змусимо перебір виконуватися
            foreach (string name in namesWithJ)
            {
                Console.WriteLine(name);
            }
            Console.ReadLine();

            // Такий самий за змістом запит отримує наказ повернути список
            // значень. Це змушує його викоатися відразу. Тип namesWithJList
            // відрізняється від типу namesWithJ
            var namesWithJList = (from n in names
                                  where n.StartsWith("J")
                                  orderby n
                                  select n).ToList(); // Force execution
            Console.WriteLine(" - Second iteration");
            foreach (string name in namesWithJList)
            {
                Console.WriteLine(name);
            }

            // тепер змінимо джерело даних
            names.Remove("Jack");
            names.Remove("John");
            // і переконаємося, що це не вплинуло на результати запиту
            Console.WriteLine(" - Third iteration");
            foreach (string name in namesWithJList)
            {
                Console.WriteLine(name);
            }
            Console.ReadLine();
        }
        static void ReflectOverQueryResults(object resultSet)
        {
            Console.WriteLine("***** Info about your query *****");
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name); // тип
            Console.WriteLine("resultSet location: {0}",
            resultSet.GetType().Assembly.GetName().Name); // розташування
        }

        // приклад засобами рефлксії досліджує тип сконструйованих запитів
        private static void Third()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            // конкретний тип результату використовують також для оголошення полів і повернення результату з методу
            IEnumerable<string> subset = from g in currentVideoGames
                                         where g.Contains(" ")
                                         //orderby g descending
                                         select g;
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
            ReflectOverQueryResults(subset);
            Console.ReadLine();
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            // Вивести тільки менші за 10 елементи.
            IEnumerable<int> subSet = from i in numbers where i < 10 orderby i select i;
            foreach (int i in subSet)
                Console.WriteLine("Item: {0}", i);
            ReflectOverQueryResults(subSet);
            Console.ReadLine();
        }


        private static void Fourth()
        {
            List<Car> myCars = new List<Car>() {
                new Car{PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{PetName = "Mary", Color = "Black", Speed = 60, Make = "VW"},
                new Car{PetName = "Clunker", Color = "Rust", Speed=5, Make = "Yugo"},
                new Car{PetName = "Melvin", Color = "White", Speed=43, Make = "Ford"}
            };

            // запит будує проекцію: в результат потрапить не весь елемент початкової колекції, а лише частина його властивостей
            // для конструйованих об'єктів компілятор згенерує анонімний клас
            var fastCars = from c in myCars where c.Speed > 55 /*&& c.Make == "VW"*/ select new { c.PetName, c.Speed };
            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast {1} mph!", car.PetName, car.Speed);
            }
            ReflectOverQueryResults(fastCars);
            Console.ReadLine();

            // Перетворення звичайного контейнера на узагальнений
            Console.WriteLine("***** LINQ по ArrayList *****");
            ArrayList myCarsArr = new ArrayList() {
                new Car{PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{PetName = "Daisy", Color = "Tan", Speed = 90,   Make = "BMW"},
                new Car{PetName = "Mary", Color = "Black", Speed = 60, Make = "VW"},
                new Car{PetName = "Clunker", Color= "Rust", Speed = 5, Make = "Yugo"},
                new Car{PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };
            // Трансформувати ArrayList в тип, сумісний з IEnumerable<T>.
            var myCarsEnum = myCarsArr.OfType<Car>();
            // from c in myCarsArr.Cast<Car>() ...
            var fastCarsArr = from c in myCarsEnum where c.Speed > 55 select c;
            foreach (var car in fastCarsArr)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
            ReflectOverQueryResults(fastCars);
            Console.ReadLine();
        }
    }
    class Car
    {
        public string PetName { get; set; }
        public string Color { get; set; }
        public int Speed { get; set; }
        public string Make { get; set; }
    }
}
