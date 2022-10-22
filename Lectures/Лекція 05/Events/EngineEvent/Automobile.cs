using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineEvent
{
    public class Automobile
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; private set; }
        public string PetName { get; private set; }
        private bool carIsDead;

        public Automobile()
        {
            CurrentSpeed = 0;
            MaxSpeed = 160;
            PetName = "SuperCar";
        }
        public Automobile(string name, int maxSpeed)
        {
            CurrentSpeed = 0;
            MaxSpeed = maxSpeed;
            PetName = name;
        }

        // тип делегата для оголошення події
        public delegate void CarEngineHandler(string msgForCaller);

        // у класі оголошено дві події
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;

        // диспетчери подій
        private void OnExploded(string msg)
        {
            if (Exploded != null) Exploded(msg);
        }
        private void OnAboutToBlow(string msg)
        {
            if (AboutToBlow != null) AboutToBlow(msg);
        }

        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                // генерування події
                OnExploded("Sorry, car \"" + PetName + "\" is dead ...");
            }
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed <= MaxSpeed && CurrentSpeed >= MaxSpeed - 10)
                    OnAboutToBlow("Cureful buddy! Gonna blow!");  // генерування події
                if (CurrentSpeed > MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("{0} current speed is {1}", PetName, CurrentSpeed);
            }
        }
    }
}
