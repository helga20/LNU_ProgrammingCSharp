using System;

namespace Events
{
    /* Нічний метелик - клас, який реагує на повідомлення від Сонця: 
    * вилітає ввечері і відвідує всі відкриті квітки до ранку */
    public class NightFly
    {
        private string n;
        
        public NightFly(string n) { this.n = n; } /* конструктор класу NightFly */
        
        public void NightFlyMessage(object x, InteractionArgs ev)
        {
            if (n == "night")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Я Нічний метелик і я вилітаю по нектар");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.WriteLine();
            }
            else if (n == "day")
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("*Нічний метелик попрацював і йде спати*");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }
    }
}
