using System;
using System.Text;
using System.Threading;

namespace Events
{
    class Interaction
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            var sunrise = new Sun("day");
            var day_flower = new Flower("day");
            var bee = new Bee("day");
            var no_night_fly = new NightFly("day");

            /* підписка на подію SunMessageEvent коли день */
            sunrise.SunMessageEvent += day_flower.FlowerMessage;
            sunrise.SunMessageEvent += bee.BeeMessage;
            sunrise.SunMessageEvent += no_night_fly.NightFlyMessage;
            sunrise.SunMessage();

            for (int i = 0; i < 40; i++)
            {
                Console.Write('-');
                Thread.Sleep(50);
            }
            Console.WriteLine();

            /* підписка на подію SunMessageEvent коли ніч */
            var sunset = new Sun("night");
            var night_flower = new Flower("night");
            var no_bee = new Bee("night");
            var night_fly = new NightFly("night");

            sunset.SunMessageEvent += night_flower.FlowerMessage;
            sunset.SunMessageEvent += no_bee.BeeMessage;
            sunset.SunMessageEvent += night_fly.NightFlyMessage;
            sunset.SunMessage();

            Console.Read();
        }
    }
}





