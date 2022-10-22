using System;

namespace Events
{
    /* Бджілка - клас, який реагує на повідомлення від Сонця: 
     * вилітає зранку і відвідує всі відкриті квітки до вечора */
    public class Bee
    {
        private string b;
       
        public Bee(string b) { this.b = b; } /* конструктор класу Bee */
       
        public void BeeMessage(object x, InteractionArgs ev)
        {
            if (b == "day")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Я бджілка і я вилітаю по нектар");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.WriteLine();
            }
            else if (b == "night")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("*Бджілка попрацювала і йде спати*");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.WriteLine();

            }
        }
    }
}
