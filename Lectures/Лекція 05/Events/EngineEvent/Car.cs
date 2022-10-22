using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineEvent
{
    // Car може повідомляти власника про критичні зміни швидкості
    // Для цього реалізовано патерн Спостерігач "вручну", без використання event
    public class Car
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; private set; }
        public string PetName { get; private set; }
        private bool carIsDead;

        public Car()
        {
            MaxSpeed = 160;
            PetName = "SuperCar";
        }
        public Car(string name, int maxSpeed)
        {
            CurrentSpeed = 0;
            MaxSpeed = maxSpeed;
            PetName = name;
        }
        // тип делегата для методу зворотнього виклику (вкладений тип)
        public delegate void CarEngineHandler(string msgForCaller);
        //Action<string>

        // поле для зберігання вказівника на метод опрацювання
        private CarEngineHandler listOfHandlers;
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            //listOfHandlers = methodToCall;
            listOfHandlers += methodToCall;
        }
        public void UnregisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }

        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                // виклик зареєстрованого методу виглядає кострубато
                if (listOfHandlers != null)
                    listOfHandlers("Sorry, car \"" + PetName + "\" is dead ...");
            }
            else
            {
                CurrentSpeed += delta;
                // тут так само
                if (CurrentSpeed <= MaxSpeed && CurrentSpeed >= MaxSpeed * 9 / 10 && listOfHandlers != null)
                    listOfHandlers("Cureful buddy! Gonna blow!");
                if (CurrentSpeed > MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("{0} current speed is {1}", PetName, CurrentSpeed);
            }
        }
    }
}
