using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;

namespace Wrox.ProCSharp.LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleFiltering(); Console.ReadLine();
            SimpleFilteringWithIndex(); Console.ReadLine();
            NonGenericCollection(); Console.ReadLine();
            TypeFiltering(); Console.ReadLine();
            Partitioning(); Console.ReadLine();
            CompoundFrom(); Console.ReadLine();
            Ordering(); Console.ReadLine();
            Grouping(); Console.ReadLine();
            GroupingWithNestedObjects(); Console.ReadLine();
            GroupingAndAggregation(); QuantifiersSum(); Console.ReadLine();
            Join(); Console.ReadLine();
            Intersection(); Console.ReadLine();
            Zipping(); Console.ReadLine();
            Conversion(); Console.ReadLine();
            Range(); Console.ReadLine();
            QuantifiersCount(); Console.ReadLine();
            // Expressions();

        }
        // Прості запити можна виконувати і мовою, і методами розширення
        private static void SimpleFiltering()
        {
            Console.WriteLine(" *** Simple filtering\n");
            var racers = from r in Formula1.GetChampions()
                         where r.Wins > 15 && (r.Country == "Brazil" || r.Country == "Austria")
                         select r;

            var racers2 = Formula1.GetChampions().
                Where(r => r.Wins > 15 && (r.Country == "Brazil" || r.Country == "Austria")).
                Select(r => r);

            foreach (var r in racers) Console.WriteLine("{0:A}", r);
            Console.WriteLine();
            foreach (var r in racers2) Console.WriteLine("{0:A}", r);
        }
        // Для складніших випадків - тільки методи розширення
        // У прикладі нижче - перевантажений Where з двома параметрами
        // index постачає інфраструктура - це лічильник результатів, повернутих запитом
        private static void SimpleFilteringWithIndex()
        {
            Console.WriteLine(" *** SimpleFilteringWithIndex\n");
            // знайти гонщиків, чиї імена починаються на А і розташовані вони на парних місцях колекції
            var racers = Formula1.GetChampions().Where((r, index) => r.LastName.StartsWith("A")
                && index % 2 != 0);
            foreach (var r in racers) Console.WriteLine("{0:A}", r);
        }

        // Приведення та фільтрування типу для неузагальнених колекцій
        private static void NonGenericCollection()
        {
            Console.WriteLine(" *** NonGenericCollection\n");
            System.Collections.ArrayList list = new System.Collections.ArrayList(Formula1.GetChampions() as System.Collections.ICollection);


            var query = from r in list.Cast<Racer>() // перетворення
                        where r.Country == "USA"
                        orderby r.Wins descending
                        select r;

            foreach (var racer in query)
            {
                Console.WriteLine("{0:A}", racer);
            }
            Console.ReadLine();
            Console.WriteLine("***** LINQ по ArrayList *****");
            // неузагальнена колекція автомобілів (і не тільки)
            ArrayList myCars = new ArrayList() {
            new Car { PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW" },
            new Car { PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW" },
            new { PetName = "Rudy", Color = "Red" },
            new Car { PetName = "Mary", Color = "Black", Speed = 55, Make = "VW" },
            new Car { PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo" },
            new Car { PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford" }
          };

            // Трансформувати ArrayList в тип, сумісний з IEnumerable<T>.
            var myCarsEnum = myCars.OfType<Car>(); // перетворення
            // Створити запит
            var fastCars = from c in myCarsEnum where c.Speed > 55 select c;
            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
        }
        // Фільтрування типу знову забезпечить строгу типізацію
        private static void TypeFiltering()
        {
            Console.WriteLine(" *** TypeFiltering\n");
            object[] data = { "one", 2, 3, "four", "five", 6 };
            var query = data.OfType<string>();

            foreach (var s in query)
            {
                Console.WriteLine(s);
            }
        }

        // Отримання даних з колекції рівними частинами
        // Завдання: поділити довгий список на "сторінки". Отримані сторінки можна використати для виведення,
        // обчислень перетворень тощо
        private static void Partitioning()
        {
            Console.WriteLine(" *** Partitioning\n");
            int pageSize = 5;
            int numberPages = (int)Math.Ceiling(Formula1.GetChampions().Count() / (double)pageSize);

            for (int page = 0; page < numberPages; page++)
            {
                Console.WriteLine("Page {0}", page);
                var racers = (from r in Formula1.GetChampions()
                              orderby r.LastName
                              select r.FirstName + " " + r.LastName).Skip(page * pageSize).Take(pageSize);
                foreach (var name in racers)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine();
            }
        }

        // Складена конструкція from досліджує властивість члена колекції,
        // яка сама є колекцією. Компілятор перетворює її на метод SelectMany
        private static void CompoundFrom()
        {
            Console.WriteLine(" *** CompoundFrom\n");
            var ferrariDrivers = from r in Formula1.GetChampions()
                                 from c in r.Cars
                                 where c == "Ferrari"
                                 orderby r.LastName
                                 select r.FirstName + " " + r.LastName;
            foreach (var racer in ferrariDrivers) Console.WriteLine(racer);
            Console.WriteLine();

            // те саме методами розширення
            var fd = Formula1.GetChampions().
                SelectMany(
                  r => r.Cars,
                  (r, c) => new { Racer = r, Car = c }).
                  Where(r => r.Car == "Ferrari").
                  OrderBy(r => r.Racer.LastName).
                  Select(r => r.Racer.FirstName + " " + r.Racer.LastName);
            foreach (var racer in fd) Console.WriteLine(racer);
        }

        // Впорядкування за багатьма критеріями. Термінове отримання частини результатів.
        private static void Ordering()
        {
            Console.WriteLine(" *** Ordering\n");
            var racers = (from r in Formula1.GetChampions()
                          orderby r.Country, r.LastName, r.FirstName
                          select r).Take(10);
            foreach (var racer in racers)
            {
                Console.WriteLine("{0:C}: {0:L}, {0:F}", racer);
            }
            Console.WriteLine();
            // те саме методами розширення
            var Racers = Formula1.GetChampions().
               OrderBy(r => r.Country).
               ThenBy(r => r.LastName).
               ThenBy(r => r.FirstName).
               Take(10);
            foreach (var racer in Racers)
            {
                Console.WriteLine("{0:C}: {0:L}, {0:F}", racer);
            }
        }
        // Розбиття на групи визначає новий анонімний тип для зображення групи.
        // Він містить ключ - ознаку віднесення до групи, доступний через властивість Key
        private static void Grouping()
        {
            Console.WriteLine(" *** Grouping\n");
            // Вивести інформацію про країни, які мають не менше двох чемпіонів: назву країни, кількість чемпіонів
            var countries = from r in Formula1.GetChampions()
                            group r by r.Country into g     // згрупувати за країною
                            where g.Count() >= 2
                            orderby g.Count() descending, g.Key // впорядкувати за кількістю результатів
                            select new { Country = g.Key, Count = g.Count() }; // створення анонімного типу
            // g.Key тут - це ключ групування, тобто r.Country
            foreach (var item in countries)
            {
                Console.WriteLine("{0,-10} {1}", item.Country, item.Count);
            }
            Console.WriteLine();

            var query = Formula1.GetChampions().
                GroupBy(r => r.Country).
                OrderByDescending(g => g.Count()).
                ThenBy(g => g.Key).
                Where(g => g.Count() >= 2).Select(g => new { Country = g.Key, Count = g.Count() });
            foreach (var item in query)
            {
                Console.WriteLine("{0,-10} {1}", item.Country, item.Count);
            }
        }

        // Групування зі створенням вкладених колекцій
        // Це розширення попереднього прикладу. Потрібно вибрати не тільки назву країни та кількість чемпіонів, а й їхні імена
        // імена гонщиків міститимуться у вкладених колекціях, які створить вкладений запит from
        private static void GroupingWithNestedObjects()
        {
            Console.WriteLine(" *** GroupingWithNestedObjects\n");
            // у запиті змінено тип об'єкта - результату
            var countries = from r in Formula1.GetChampions()
                            group r by r.Country into g
                            where g.Count() >= 2
                            orderby g.Count() descending, g.Key
                            select new
                            {
                                Country = g.Key,
                                Count = g.Count(),
                                Racers = from r1 in g        // створення колекції імен, вибір з групи
                                         orderby r1.LastName
                                         select r1.FirstName + " " + r1.LastName
                            };
            foreach (var item in countries)
            {
                Console.WriteLine("{0, -10} {1}", item.Country, item.Count);
                foreach (var name in item.Racers)
                {
                    Console.Write("{0}; ", name);
                }
                Console.WriteLine();
            }
        }

        // Приклад застосування агрегуючого методу розширення
        // Скільки перемог отримали разом гонщики кожної країни?
        private static void GroupingAndAggregation()
        {
            Console.WriteLine(" *** GroupingAndAggregation\n");
            // Всього є три запити from. Розбір треба починати з другого
            // from r ... group групує пілотів за країнами
            // третій from, найглибше вкладений, створює колекцію кількостей перемог групи (країни).
            // Агрегуючий метод Sum() додає всі кількості (всі елементи колекції),
            // таким чином отримуємо колекцію об'єктів {Країна, Перемоги}.
            // Зовнішній from впорядковує її за спаданням кількості перемог
            // Приємно, що WriteLine дає собі раду з об'єктами анонімного типу.
            var countries = from c in
                                from r in Formula1.GetChampions()
                                group r by r.Country into g
                                select new
                                {
                                    Country = g.Key,
                                    Wins = (from x in g select x.Wins).Sum()
                                }
                            orderby c.Wins descending
                            select c;
            foreach (var item in countries) Console.WriteLine(item);
        }
        // Те саме завдання, але отримано тільки перші 5 значень
        private static void QuantifiersSum()
        {
            Console.WriteLine("\n *** GroupingAndAggregation Take(5)\n");
            var countries = (from c in
                                 from r in Formula1.GetChampions()
                                 group r by r.Country into c
                                 select new
                                 {
                                     Country = c.Key,
                                     Wins = (from r1 in c select r1.Wins).Sum()
                                 }
                             orderby c.Wins descending, c.Country
                             select c).Take(5);
            foreach (var country in countries)
            {
                Console.WriteLine("{0} {1}", country.Country, country.Wins);
            }
        }
        // Поєднання двох вибірок в одну за критерієм (співпадіння року) двома способами:
        // поступово та в "багатоповерховому" запиті
        // У Формулі 1 є два чемпіонати: пілотів і конструкторів. Потрібно отримати перелік
        // переможців - пілотів і конструкторів - по кожному року. Для цього доведеться
        // поєднати дві колекції.
        private static void Join()
        {
            // поступово
            Console.WriteLine(" *** Join\n");
            var racers = from r in Formula1.GetChampions()  // перебираємо пілотів
                         from y in r.Years      // перебираємо роки перемог пілота
                         where y > 2003
                         select new { Year = y, Name = r.FirstName + " " + r.LastName };
            // отримали "плоску" колекцію об'єктів {Рік, Ім'я}, ім'я пілота повториться стільки раз, скільки він був чемпіоном
            var teams = from t in Formula1.GetContructorChampions() // перебираємо команди
                        from y in t.Years    // перебираємо роки перемог команди, все так само, як для пілотів
                        where y > 2003
                        select new { Year = y, Name = t.Name };

            var RacersAndTeams = from r in racers   // колекція РікПілот поєднується з колекцією РікКоманда
                                 join t in teams on r.Year equals t.Year   // на підставі співпадіння років
                                 select new { Year = r.Year, Racer = r.Name, Team = t.Name }; // новий об'єкт
            Console.WriteLine("Year  Champion             Constructor Title");
            foreach (var item in RacersAndTeams)
            {
                Console.WriteLine("{0}: {1,-20} {2}", item.Year, item.Racer, item.Team);
            }

            // те саме можна зробити одним запитом
            int year = 2003;
            var racersAndTeams = from r in   // замість racers пишемо запит створення колекції
                                     from r1 in Formula1.GetChampions()
                                     from yr in r1.Years
                                     where yr > year
                                     select new { Year = yr, Name = r1.FirstName + " " + r1.LastName }
                                 join t in   // замість teams також запит
                                     from t1 in Formula1.GetContructorChampions()
                                     from yt in t1.Years
                                     where yt > year
                                     select new { Year = yt, Name = t1.Name }
                                 on r.Year equals t.Year // критерій поєднання
                                 select new { Year = r.Year, Racer = r.Name, Team = t.Name }; // створення відповіді
            Console.WriteLine("\nYear  Champion             Constructor Title");
            foreach (var item in racersAndTeams)
            {
                Console.WriteLine("{0}: {1,-20} {2}", item.Year, item.Racer, item.Team);
            }
        }
        
        // Знайти пілота, який виступав за дві команди: Ferrari та McLaren
        // Для цього утворимо множини пілотів обох команд і обчислимо перетин множин
        // Запити однакові для всіх команд, тому їх можна винести в окремий метод
        // Ще кращий підхід - ізолювати запит всередині лямбда всередині методу
        private static IEnumerable<Racer> DriversByCar(string car)
        {
            return from r in Formula1.GetChampions() from c in r.Cars
                   where c == car orderby r.LastName
                   select r;
        }
        private static void Intersection()
        {
            Console.WriteLine(" *** Intersection\n");
            Console.WriteLine("champion with Ferrari and McLaren using the method");
            // два виклики функції повернуть різні колекції, а метод Intersect - їхню спільну частину
            foreach (var racer in DriversByCar("Ferrari").Intersect(DriversByCar("McLaren")))
            {
                Console.WriteLine(racer);
            }
            // за допомогою узагальненого типу делегата і лямбда оголосили функцію, яка за рядком - назвою команди
            // формує колекцію пілотів
            Func<string, IEnumerable<Racer>> racersByCar =
               car => from r in Formula1.GetChampions()
                      from c in r.Cars
                      where c == car
                      orderby r.LastName
                      select r;
            Console.WriteLine("champion with Ferrari and McLaren using a lambda");
            // два виклики функції повернуть різні колекції, а метод Intersect - їхню спільну частину
            foreach (var racer in racersByCar("Ferrari").Intersect(racersByCar("McLaren")))
            {
                Console.WriteLine(racer);
            }
        }

        // Сполучення послідовностей в одну заданим перетворенням
        // Один запит надав імена гонщиків Об'єднаного Королівства, інший - імена і перемоги
        // Завдання: сполучити дві послідовності в одну, взявши з першої імена, з другої - перемоги
        private static void Zipping()
        {
            Console.WriteLine(" *** Zipping\n");
            var racerNames = from r in Formula1.GetChampions()
                             where r.Country == "UK"
                             orderby r.Wins descending
                             select new { Name = r.FirstName + " " + r.LastName };
            var racerNamesAndStarts = from r in Formula1.GetChampions()
                                        where r.Country == "UK"
                                        orderby r.Wins descending
                                        select new
                                        {
                                            LastName = r.LastName,
                                            Starts = r.Starts
                                        };
            var racers = racerNames.Zip(racerNamesAndStarts, (first, second) => first.Name + ", wins: " + second.Starts);
            foreach (var r in racers)
            {
                Console.WriteLine(r);
            } 
        }

        private static void Conversion()
        {
            Console.WriteLine(" *** Query executed immediately\n");
            // Виклик методу перетворення заставляє запит виконатися одразу
            List<Racer> racers = (from r in Formula1.GetChampions()
                                  where r.Starts > 150
                                  orderby r.Starts descending
                                  select r).ToList();
            foreach (var racer in racers)
            {
                Console.WriteLine("{0} {0:S}", racer);
            }

            Console.WriteLine("\n *** Lookup using\n");
            // Утворити відображення, яке за назвою команди (автомобіля) знаходить імена пілотів
            // "Словник", що допускає однакові ключі - відображення Lookup (альтернатива групуванню)
            // ключ - рядок, значення - пілот
            ILookup<string, Racer> racersLookup = (
                from r in Formula1.GetChampions()  // вкладений запит будує "плоску" колекцію
                from c in r.Cars                   // об'єктів { Авто, Гонщик }
                select new { Car = c, Racer = r }
                ).ToLookup(cr => cr.Car, cr => cr.Racer); // методові передають дві лямбди

            if (racersLookup.Contains("Williams")) // тепер можна використовувати індексатор
            {
                foreach (var williamsRacer in racersLookup["Williams"])
                {
                    Console.WriteLine(williamsRacer);
                }
            }
        }

        // Генерування діапазонів і послідовностей значень
        private static void Range()
        {
            Console.WriteLine(" *** Generate\n");
            var values = Enumerable.Range(1, 20).Select(n => n * 3);
            foreach (var item in values)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            var succ = Enumerable.Repeat(5, 10).Select((x, i) => x + 2 * i);
            foreach (var item in succ)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }

        // Фільтрування + проекція
        private static void QuantifiersCount()
        {
            Console.WriteLine(" *** QuantifiersCount\n");
            var racers = from r in Formula1.GetChampions()
                         where r.Years.Count() >= 3
                         orderby r.Years.Count() descending
                         select new
                         {
                             Name = r.FirstName + " " + r.LastName,
                             TimesChampion = r.Years.Count()
                         };
            foreach (var r in racers)
            {
                Console.WriteLine("{0} {1}", r.Name, r.TimesChampion);
            }
        }

        //-----------------------------------------------------------
        private static void DisplayTree(int indent, string message, Expression expression)
        {
            string output = String.Format("{0} {1}! NodeType: {2}; Expr: {3} ", "".PadLeft(indent, '>'), message, expression.NodeType, expression);

            indent++;
            switch (expression.NodeType)
            {
                case ExpressionType.Lambda:
                    Console.WriteLine(output);
                    LambdaExpression lambdaExpr = (LambdaExpression)expression;
                    foreach (var parameter in lambdaExpr.Parameters)
                    {
                        DisplayTree(indent, "Parameter", parameter);
                    }
                    DisplayTree(indent, "Body", lambdaExpr.Body);
                    break;
                case ExpressionType.Constant:
                    ConstantExpression constExpr = (ConstantExpression)expression;
                    Console.WriteLine("{0} Const Value: {1}", output, constExpr.Value);
                    break;
                case ExpressionType.Parameter:
                    ParameterExpression paramExpr = (ParameterExpression)expression;
                    Console.WriteLine("{0} Param Type: {1}", output, paramExpr.Type.Name);
                    break;
                case ExpressionType.Equal:
                case ExpressionType.AndAlso:
                case ExpressionType.GreaterThan:
                    BinaryExpression binExpr = (BinaryExpression)expression;
                    if (binExpr.Method != null)
                        Console.WriteLine("{0} Method: {1}", output, binExpr.Method.Name);
                    else
                        Console.WriteLine(output);
                    DisplayTree(indent, "Left", binExpr.Left);
                    DisplayTree(indent, "Right", binExpr.Right);
                    break;
                case ExpressionType.MemberAccess:
                    MemberExpression memberExpr = (MemberExpression)expression;
                    Console.WriteLine("{0} Member Name: {1}, Type: {2}", output, memberExpr.Member.Name, memberExpr.Type.Name);
                    DisplayTree(indent, "Member Expr", memberExpr.Expression);
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("....{0} {1}", expression.NodeType, expression.Type.Name);
                    break;
            }
        }
        private static void Expressions()
        {
            Expression<Func<Racer, bool>> expression = r => r.Country == "Brazil" && r.Wins > 6;
            DisplayTree(0, "Lambda", expression);
        }
    }
}
