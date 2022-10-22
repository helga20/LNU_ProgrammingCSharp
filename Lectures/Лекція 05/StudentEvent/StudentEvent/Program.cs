/*       (С) ЛНУ імені Івана Франка, Ярошко С.А., 2015 - 2021
 *       Навчальна програма демонструє взаємодію об'єктів через реагування на подію
 *      ----------------------------------------------------------------------------
 *  ЛЕГЕНДА: Вчитель екзаменує студента, виставляє йому оцінку залежно від кількості набраних балів.
 *  Зміна оцінки студента - це подія "зміна властивості"; клас Student реалізує інтерфейс 
 *  INotifyPropertyChanged.
 *  Батько може опрацьовувати повідомлення про зміну оцінки Студента.
 *  Вчитель може підписати/відписати Батька на отримання повідомлень про подію Студента.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            // створення учасників 
            Parent P = new Parent("Dad");
            Student S = new Student("Boy");
            Teacher T = new Teacher("Prof");
            Console.WriteLine(P);
            Console.WriteLine(S);
            Console.WriteLine(T);
            // Буде виконано 9 опитувань студента, після третього підпишемо Батька на отримання
            // інформації про соцінки Студента. Чотирьох повідомлень, імовірно, буде достатньо,
            // тому після сьомого опитування інформування припиняється. Остаточну оцінку фіксує
            // Деканат.
            Console.WriteLine("\n****** Let's go! **********************\n");
            for (int i=1; i<10; ++i)
            {
                switch (i)
                {
                    case 4: T.Inform(P, S, true); break;
                    case 8: T.Inform(P, S, false); break;
                    case 9: S.PropertyChanged += Dekanat.SignRecordBook; break;
                }
                Console.WriteLine("{0} attempt {1} point {2}", S, i, T.Examine(S));
                Console.ReadLine();
            }
            Console.WriteLine("\n****** See you! ***********************");
            Console.ReadLine();
        }
    }
}
