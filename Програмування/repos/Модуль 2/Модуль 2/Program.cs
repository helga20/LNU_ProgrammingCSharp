using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Модуль_2
{
    public class Program
    {
        [Serializable]
        public class Worker 
        { 
            public Worker() { }

            public int ID { get; set; }
            public string Surname { get; set; }
            public int Payment { get; set; }

            public override string ToString()
            {
                return $"{Surname} ID - {ID}, gets {Payment} per hour";
            }
        }

        public class WorkerComparer : IComparer<Worker>
        {
            public int Compare(Worker x, Worker y)
            {
                int comp = x.Payment.CompareTo(y.Payment);
                if (comp == 0)
                    return x.Surname.CompareTo(y.Surname);
                return comp;
            }
        }

        public delegate void ProjectHandler(string name, string boss);
        public class Project
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Boss { get; set; }

            public event ProjectHandler LimitHours;

            public void Check(int n) => LimitHours?.Invoke(Name, Boss);

            public override string ToString()
            {
                return $"{Name} ID - {ID}, {Boss} it's boss";
            }
        }

        public class Table
        {
            public int Month { get; set; }
            public int ID { get; set; }
            public int ID_p { get; set; }
            public int Hours { get; set; }

            public override string ToString()
            {
                return $"Worker with ID {ID_p} worked {Hours} hours in month {Month} on a project {ID}";
            }
        }

        static void Main()
        {
            List<Worker> workers = new();
            List<Project> projects = new();
            List<Table> tables = new();

            string path1 = "C:\\Users\\ulyan\\source\\repos\\Модуль 2\\Модуль 2\\Workers.txt";
            string path3 = "C:\\Users\\ulyan\\source\\repos\\Модуль 2\\Модуль 2\\Tables.txt";
            string path2 = "C:\\Users\\ulyan\\source\\repos\\Модуль 2\\Модуль 2\\Projects.txt";

            if(File.Exists(path1) && File.Exists(path2) && File.Exists(path3))
            {
                string[] lines;
                // Зчитування працівників
                try
                {
                    lines = File.ReadAllLines(path1);
                }
                catch
                {
                    Console.WriteLine("Exception reading file occured\n");
                    return;
                }

                foreach (string line in lines)
                {
                    string[] info = line.Split();
                    workers.Add(new Worker() { ID = Int32.Parse(info[0]), Surname = info[1], Payment = Int32.Parse(info[2]) });
                }

                // 1. Посортовано спершу за зарплатою, тоді за іменем
                Console.WriteLine("Завдання 1.");
                workers.Sort(new WorkerComparer());
                foreach (Worker w in workers) Console.WriteLine(w);

                // Зчитування проектів
                lines = File.ReadAllLines(path2);
                for (int i = 0; i < lines.Length; ++i)
                {
                    string[] info = lines[i].Split();
                    projects.Add(new Project() { ID = Int32.Parse(info[0]), Name = info[1], Boss = info[2] });
                    projects[i].LimitHours += Respond;
                }

                // Зчитування табелів
                lines = File.ReadAllLines(path3);
                foreach (string line in lines)
                {
                    string[] info = line.Split();
                    tables.Add(new Table() { ID = Int32.Parse(info[0]), Month = Int32.Parse(info[1]), ID_p = Int32.Parse(info[2]), Hours = Int32.Parse(info[3]) });
                }

                Console.WriteLine("\nЗавдання 2.");
                // 2.Використовуючи LINQ, знайти загальну кількість відпрацьованих годин по кожному проекту за кожен місяць
                // і вивести у вигляді назва проекту, місяць, кількість годин.
                var query1 = from table in tables
                            join proj in projects on table.ID equals proj.ID
                            group table.Hours by new
                            {
                                proj.Name,
                                table.Month
                            } into t
                            select new { t.Key.Name, t.Key.Month, Amount = t.Sum()};

                foreach (var q in query1)
                    Console.WriteLine($"Project {q.Name} in month {q.Month} had {q.Amount} hours");

                Console.WriteLine("\nЗавдання 3.");
                // 3. Для кожного працівника обчислити його сумарну зарплату.
                var query2 = from table in tables
                             join workr in workers on table.ID_p equals workr.ID
                             group table.Hours by new
                             {
                                 workr.ID,
                                 workr.Payment,
                             } into t
                             select new { t.Key.ID, Payment = t.Sum() * t.Key.Payment };

                foreach (var q in query2)
                    Console.WriteLine($"Worker with ID {q.ID} earned {q.Payment}");

                Console.WriteLine("\nЗавдання 4.");
                // 4. Якщо кількість відпрацьованих годин для проекту перевищила заданий рівень,
                // генерується подія, в обробнику якої на консоль виводиться повідомлення з назвою проекту та прізвищем керівника.
                var query3 = from table in tables
                             join proj in projects on table.ID equals proj.ID
                             group table.Hours by new
                             { proj.Name, proj.Boss } into t
                             select new { t.Key.Name, t.Key.Boss, Amount = t.Sum() };

                foreach (var q in query3)
                    if (q.Amount > 30)
                        foreach (Project proj in projects)
                            if (proj.Name == q.Name)
                                proj.Check(q.Amount);
                        
            }
            else
            {
                Console.WriteLine("One of the files was not found");
            }
        }
        static void Respond(string name, string boss) =>
           Console.WriteLine($"Project {name} was done. Congrats {boss}!");
    }
}
