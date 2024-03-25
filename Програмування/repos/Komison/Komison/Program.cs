using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;



namespace ExamTest
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurmane { get; set; }
        public string Group { get; set; }
    }

    public class Task
    {
        public int Task_Id { get; set; }
        public string Theme { get; set; }
        public DateTime TaskStart { get; set; }
        public TimeSpan TimeExecution { get; set; }
    }

    public class Test
    {
        public int TaskID { get; set; }
        public int StudID { get; set; }
        public int Score { get; set; }
        public DateTime TaskFinish { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var xmldict1 = new XmlSerializer(typeof(List<Task>));
            var path = @"tasks.xml";
            var arr_Medserv = new List<Task>
            {
                new Task {Task_Id = 1, Theme = "Theme1", TaskStart = DateTime.Parse("05/05/1951 10:00:00"), TimeExecution = TimeSpan.Parse("00:40:00")},
                new Task {Task_Id = 2, Theme = "Theme2", TaskStart = DateTime.Parse("05/05/1951 11:00:00"), TimeExecution = TimeSpan.Parse("00:30:00")},
                new Task {Task_Id = 3, Theme = "Theme3", TaskStart = DateTime.Parse("05/05/1951 12:00:00"), TimeExecution = TimeSpan.Parse("00:20:00")},
            };

            using (var file = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmldict1.Serialize(file, arr_Medserv);
                file.Close();
            }


            var xmldict2 = new XmlSerializer(typeof(List<Student>));
            var path_p = @"students.xml";
            var arr_Patient = new List<Student>
            {
                new Student {StudentID = 1, StudentName = "Tom", StudentSurmane = "Hanks", Group = "PM1"},
                new Student {StudentID = 2, StudentName = "Ann", StudentSurmane = "Lee", Group = "PM1"},
                new Student {StudentID = 3, StudentName = "Sam", StudentSurmane = "Jenkins", Group = "PM1"},
                new Student {StudentID = 4, StudentName = "Tim", StudentSurmane = "Vanks", Group = "PM1"},
                new Student {StudentID = 5, StudentName = "Arny", StudentSurmane = "Lie", Group = "PM1"},
                new Student {StudentID = 6, StudentName = "Sag", StudentSurmane = "Jankins", Group = "PM1"},

            };
            using (var file = new FileStream(path_p, FileMode.OpenOrCreate))
            {
                xmldict2.Serialize(file, arr_Patient);
                file.Close();
            }


            var xmldict3 = new XmlSerializer(typeof(List<Test>));
            var path_v = @"results.xml";
            var arr_tests = new List<Test>
            {
                new Test {TaskID = 1, StudID = 1, Score = 11, TaskFinish = DateTime.Parse("05/05/1951 12:00:00") },
                new Test {TaskID = 1, StudID = 3, Score = 20, TaskFinish = DateTime.Parse("05/05/1951 13:00:00") },
                new Test {TaskID = 1, StudID = 2, Score = 30, TaskFinish = DateTime.Parse("05/05/1951 11:00:00") },
                new Test {TaskID = 2, StudID = 1, Score = 11, TaskFinish = DateTime.Parse("05/05/1951 12:00:00") },
                new Test {TaskID = 2, StudID = 3, Score = 21, TaskFinish = DateTime.Parse("05/05/1951 13:00:00") },
                new Test {TaskID = 2, StudID = 4, Score = 35, TaskFinish = DateTime.Parse("05/05/1951 12:00:00") },
                new Test {TaskID = 2, StudID = 5, Score = 35, TaskFinish = DateTime.Parse("05/05/1951 11:00:00") },
                new Test {TaskID = 2, StudID = 6, Score = 45, TaskFinish = DateTime.Parse("05/05/1951 12:00:00") }
            };
            using (var file = new FileStream(path_v, FileMode.OpenOrCreate))
            {
                xmldict3.Serialize(file, arr_tests);
                file.Close();
            }

            var serializedTask = @"tasks.xml";

            var xmlservdict = new XmlSerializer(typeof(List<Task>));
            var tasks = new List<Task>();
            using (var file = new FileStream(serializedTask, FileMode.OpenOrCreate))
            {
                var newdict = xmlservdict.Deserialize(file) as List<Task>;
                if (newdict != null)
                {
                    foreach (var item in newdict)
                    {
                       tasks.Add(item);
                    }
                }
            }

            var serializedStud = @"students.xml";

            var students = new List<Student>();
            var xmlPatdict = new XmlSerializer(typeof(List<Student>));
            using (var file = new FileStream(serializedStud, FileMode.OpenOrCreate))
            {
                var newdict = xmlPatdict.Deserialize(file) as List<Student>;
                if (newdict != null)
                {
                foreach (var item in newdict)
                            students.Add(item);
                }
            }

           var serializedTest = @"results.xml";

           var results = new List<Test>();
           var xmlresdict = new XmlSerializer(typeof(List<Test>));
           using (var file = new FileStream(serializedTest, FileMode.OpenOrCreate))
           {
                var newdict = xmlresdict.Deserialize(file) as List<Test>;
                    if (newdict != null)
                    {
                        foreach (var item in newdict)
                        {
                            results.Add(item);
                        }
                    }
                }

                var task1 = from rsl in results // результати
                            join stu in students on rsl.StudID equals stu.StudentID
                            join tsk in tasks on rsl.TaskID equals tsk.Task_Id // завдання
                            select new
                            {
                                stu.Group,
                                StudentName = stu.StudentSurmane + " " + stu.StudentName[0],
                                tsk.Task_Id,
                                tsk.Theme,
                                Score = (tsk.TaskStart.Add(tsk.TimeExecution) < rsl.TaskFinish) ? rsl.Score : rsl.Score / 2
                            };

                var task1Sort = task1.OrderBy(o => o.Group).
                    ThenBy(o => o.StudentName).
                    ThenBy(o => o.Score).GroupBy(o => new { o.Group, o.StudentName });

                XDocument Doc = new XDocument();
                XElement root = new XElement("Results");
                Doc.Add(root);
                foreach (var i in task1Sort)
                {
                    XElement student = new XElement("Student");
                    XAttribute name = new XAttribute("Name", $"{i.Key.StudentName}");
                    XAttribute group = new XAttribute("Group", $"{i.Key.Group}");
                    student.Add(name, group);
                    XElement marks = new XElement("Marks");
                    foreach (var j in i)
                    {
                        XElement mark = new XElement("Mark");
                        XAttribute taskId = new XAttribute("TaskID", j.Task_Id);
                        XAttribute theme = new XAttribute("Theme", j.Theme);
                        XAttribute score = new XAttribute("Score", j.Score);


                        mark.Add(taskId, theme, score);
                        marks.Add(mark);

                    }
                    student.Add(marks);
                    root.Add(student);

                }
                Doc.Save(@"task1.xml");

                XDocument xdoc = XDocument.Load(@"task1.xml");

                var read =
                                from data in xdoc.Descendants("Results")
                                from student in data.Descendants("Student")
                                from marks in student.Descendants("Marks")
                                from mark in marks.Descendants("Mark")
                                select new
                                {
                                    Group = student.Attribute("Group").Value,
                                    Name = student.Attribute("Name").Value,
                                    Score = int.Parse(mark.Attribute("Score").Value)
                                };

                HashSet<string> groups = read.ToList().Select(o => o.Group).ToHashSet();



                var task3 = new XElement("Task3", from info in read

                                                  group info by new { info.Name, info.Group }
                                                  into Students
                                                  let Sum = Students.Sum(o => o.Score)
                                                  orderby Students.Key.Group ascending

                                                  select new XElement("Student", new XAttribute("Name", Students.Key.Name),
                                                      new XAttribute("Sum", Sum)));

                task3.Save("thirdtask.xml");
            }
        }
}