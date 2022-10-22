using System;

namespace Events
{
    /* Квітка - клас, який реагує на повідомлення від Сонця: 
     * денна квітка Тигридія розпускається зранку і закривається ввечері, 
     * вечірня квітка Мірабіліс розпускається ввечері і закривається зранку */
    public class Flower
    {
        private string f;
        
        public Flower (string f) { this.f = f; } /* конструктор класу Flower */
        
        public void FlowerMessage(object x, InteractionArgs arg)
        {
            if (f == "day")
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Я мірабіліс. Мій час дня закінчився(");
                Console.ResetColor();
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Я тигридія. Настав час милуватися мною)");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.WriteLine();
            }
            else if (f == "night")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Я тигридія. Мій час дня закінчився(");
                Console.ResetColor();
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Я мірабіліс. Настав час милуватися мною)");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }
    }
}