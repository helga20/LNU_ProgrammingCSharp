using System;

namespace interfaces
{
    public interface ISwimmable
    {
        void Swim()
        {
            Console.WriteLine("I can swim!");
        }
    }

    public interface IFlyable
    {
        public int MaxHeight { get { return 0; } }

        void Fly()
        {
            Console.WriteLine($"I can fly at {MaxHeight} meters high!");
        }
    }

    public interface IRunnable
    {
        public int MaxSpeed { get { return 0; } }

        void Run()
        {
            Console.WriteLine($"I can run up to {MaxSpeed} kilometers per hour!");
        }
    }

    public interface IAnimal
    {
        public int LifeDuration { get { return 0; } }

        void Voice()
        {
            Console.WriteLine("No voice!");
        }

        void ShowInfo()
        {
            Console.WriteLine($"I am {GetType().Name} and I live approximately {LifeDuration} years.");
        }
    }

    class Cat : IRunnable, IAnimal
    {
        public Cat(int speed, int life)
        {
            MaxSpeed = speed;
            LifeDuration = life;
        }

        public int MaxSpeed { get; set; }
        public int LifeDuration { get; set; }

        public void Voice()
        {
            Console.WriteLine("Meow!");
        }
    }

    class Eagle : IFlyable, IAnimal
    {
        public Eagle(int height, int life)
        {
            MaxHeight = height;
            LifeDuration = life;
        }

        public int MaxHeight { get; set; }
        public int LifeDuration { get; set; }
    }

    class Shark : ISwimmable, IAnimal
    {
        public Shark(int life)
        {
            LifeDuration = life;
        }

        public int LifeDuration { get; set; }
    }

    class Program
    {
        static void Main()
        {
            IAnimal kitty = new Cat(15, 10);
            IAnimal sharky = new Shark(25);
            IAnimal eagly = new Eagle(400, 40);

            IAnimal[] arr = new IAnimal[3];
            arr[0] = kitty;
            arr[1] = sharky;
            arr[2] = eagly;

            foreach (var animal in arr)
            {
                animal.ShowInfo();
                animal.Voice();
                if (animal.GetType().Name == "Shark")
                {
                    ((ISwimmable)animal).Swim();
                }
                else if (animal.GetType().Name == "Eagle")
                {
                    ((IFlyable)animal).Fly();
                }
                else
                {
                    ((IRunnable)animal).Run();
                }
                Console.WriteLine("");
            }
        }
    }
}
