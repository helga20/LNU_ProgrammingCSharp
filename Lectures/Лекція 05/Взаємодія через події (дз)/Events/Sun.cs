using System;
using System.Threading;

namespace Events
{
    /* Сонце - клас, який сходить і заходить, повідомляє інші об'єкти про зміни свого стану */
    public class Sun
    {
        protected string s;
        public Sun(string s) { this.s = s; } /* конструктор класу Sun */
        
        public delegate void SunEventHandler(object source, InteractionArgs args); // оголошення делегата 
        
        public event SunEventHandler SunMessageEvent; // оголошення події на основі делегата SunEventHandler
        
        public void SunMessage()
        {
            if (s == "day")
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue; /* задається колір тексту при виведені*/
                Console.BackgroundColor = ConsoleColor.Yellow; /* задається колір фону при виведені*/
                Console.WriteLine("Доброго ранку з України!"); 
                Console.ResetColor(); /* повертає до оригінального кольору консолі */
                Thread.Sleep(1000);
                Console.WriteLine();
            }
            else if (s == "night")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("Добрий вечір з України!");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.WriteLine();
            }
            OnSun(s);
        }

        /* "обгортання" події в захищений віртуальний метод, щоб дозволити похідним класам викликати її */
        protected virtual void OnSun(string act)
        {
            if (SunMessageEvent != null) 
            {
                SunMessageEvent(this, new InteractionArgs() { Action = act });
            }
        }

    }
}
