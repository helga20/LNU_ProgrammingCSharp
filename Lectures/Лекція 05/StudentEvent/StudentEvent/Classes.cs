using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace StudentEvent
{
    // Особа - базовий клас для всіх дійових осіб програми. Зберігає ім'я особи
    // та досить дотепно визначає універсальний спосіб перетворення себе і всіх
    // нащадків на рядок
    class Person
    {
        public string Name { get; private set; }
        public Person(string name)
        {
            this.Name = name;
        }
        public override string ToString()
        {
            return this.GetType().Name + ' ' + Name;
        }
    }
    // Батько отримує повідомлення про подію - зміну оцінки студента, вміє опрацювати
    // його методом GetInfo.
    // Батько використовує додаткову можливість - надсилати свою інфу назад, відправникові
    // в аргументі події.
    class Parent : Person
    {
        private static string[] Dictum = { "Та учися, милий сину!", "Добре та багато.",
                                           "Бо ти дурнем зостанешся.", "А я - твоїм татом." };
        private int dictNum;
        public Parent(string name) : base(name) 
        {
            dictNum = 0;
        }
        public void GetInfo(object sender, PropertyChangedEventArgs eArg)
        {
            Student stud = sender as Student;
            Console.WriteLine("     -----------------------------------------------");
            Console.WriteLine("     {0} has changed property {1}", stud, eArg.PropertyName );
            Console.WriteLine("     {0} know, that his point is \"{1}\"", this, stud.Point);
            Console.WriteLine("     -----------------------------------------------");
            // а це вже необов'язкова частина опрацювання події - надсилання відгуку
            if (eArg is PointChangedEventArgs)
                (eArg as PointChangedEventArgs).Msg = Dictum[dictNum];
            dictNum = (dictNum + 1) % 4;
        }
    }
    // Студент накопичує бали в полі total. Відповіді він вгадує (метод Unswer), тому
    // потрібна підтримка генератора випадкових чисел (поле unswer).
    // Оцінку Студент зберігає у властивості Point. Властивість не автоматична, тому є
    // поле і визначені методи доступу, причому set ініціює подію PropertyChanged.
    // Цю подію оголошено з використанням усіх засобів автоматизації (поле, методи add
    // i remove пише компілятор), тип делегата - з простору System.ComponentModel,
    // тип другого аргумента делегата - звідти ж. Руками треба дописати тільки метод
    // ініціації події OnPropertyChanged.
    // Студент може отримати відповідь від Батька, тому після запуску події виконано
    // додаткові перевірки.
    //
    class Student : Person, INotifyPropertyChanged
    {
        private Random unswer;
        private int total;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PointChangedEventArgs eArg = new PointChangedEventArgs(propertyName);
                PropertyChanged(this, eArg); // генерування події
                // опрацювання отриманого відгуку
                if (eArg.Msg != string.Empty)
                    Console.WriteLine("      *** returned message is\n      *** {0}", eArg.Msg);
            }
        }
        private string point;
        public string Point
        {
            get { return point; }
            set
            {
                //if (point != value)
                {
                    point = value;
                    OnPropertyChanged("Point");
                }
            }
        }
        public Student(string name) : base(name)
        {
            unswer = new Random();
            total = 0;
            PropertyChanged = null;
            point = string.Empty;
        }
        public int Unswer()
        {
            total += unswer.Next(17)+1;
            return total;
        }
    }
    // Тип аргумента події. Вистачило б і PropertyChangedEventArgs, але ми трохи удосконалили
    // його (додали Msg), щоб отримувач зміг відповісти відправникові 
    class PointChangedEventArgs : PropertyChangedEventArgs
    {
        public string Msg { get; set; }
        public PointChangedEventArgs(string propName)
            : base(propName)
        { Msg = string.Empty; }
    }

    // Вчитель опитує Студента і перетворює бали на університетську оцінку.
    // Вчитель може також підписати Батька на отримання інформації про зміну оцінки.
    class Teacher : Person
    {
        public Teacher(string name) : base(name) { }
        public int Examine(Student stud)
        {
            int unswer = stud.Unswer();
            if (unswer >= 90) stud.Point = "Excellent";
            else if (unswer >= 71) stud.Point = "Good";
            else if (unswer >= 51) stud.Point = "Satisfactorily";
            else stud.Point = "Poorly";
            return unswer;
        }
        public void Inform(Parent par, Student stud, bool yes)
        {
            if (yes) stud.PropertyChanged += par.GetInfo;
            else stud.PropertyChanged -= par.GetInfo;
        }
    }
    // Деканат також зацікавлений отримувати інформацію про оцінки Студента.
    // Підписується в головній програмі без допомоги Вчителя
    class Dekanat
    {
        public static void SignRecordBook(object sender, PropertyChangedEventArgs eArg)
        {
            Student stud = sender as Student;
            Console.WriteLine("\n===d=e=k=a=n=a=t====================");
            Console.WriteLine("### {0} has point \"{1}\"\n", stud, stud.Point);
        } 
    }
}
