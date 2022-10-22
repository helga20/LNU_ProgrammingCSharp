using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.Delegates
{
    // тип події "виготовлено автомобіль"
    public delegate void CarInfoHandler(object sender, CarInfoEventArgs e);

    public class CarInfoEventArgs : EventArgs
    {
        public CarInfoEventArgs(string car)
        {
            this.car = car;
        }
        private string car;
        public string Car
        {
            get
            {
                return car;
            }
        }
    }
    // Виробник автомобілів повідомляє зацікавлених дилерів
    // про вихід нової моделі за допомогою події CarCreated
    // потрібно: 1)делегат, 2)подія, 3)метод-диспетчер
    // бажано: спеціальний тип аргументів події
    public class CarFactory
    {
        /* ПОДІЯ "виготовлено автомобіль"
         * нижче закоментовано один з варіантів оголошення події,
         * який використовує "довгу нротацію". Довга нотація потрібна,
         * якщо крім присвоєння методу потрібно виконати додаткові дії.
         */
        //private CarInfoHandler carCreated;

        public event CarInfoHandler CarCreated;
        //{
        //    add
        //    {
        //        carCreated += value;
        //    }
        //    remove
        //    {
        //        carCreated -= value;
        //    }
        //}

        /* Можна було б не оголошувати власний тип делегата, а використати
         * стандартний узагальнений тип.
         */
        //public event EventHandler<CarInfoEventArgs> CarCreated;
        
        public void CreateACar(string car)
        {
            Console.WriteLine("\nFactory - car {0} created", car);
            // сигнал про настання події
            OnCarCreated(car);
        }

        public void CreateNCars(string car, int n)
        {
            Console.WriteLine("\nFactory - {0} cars {1} created", n, car);
            // сигнал про настання події
            OnCarCreated(String.Format("{0} {1}s", n, car));
        }

        // метод-диспетчер події
        protected void OnCarCreated(string car)
        {
            if (CarCreated != null) // carCreated
            {
                CarInfoEventArgs e = new CarInfoEventArgs(car);
                CarCreated(this, e);
            }
        }
    }
}
