using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    class Country
    {
        protected string name;
        protected double square;
        protected double population;
        protected double vvp;
        public Country()
        {
            name = "no name";
            square = 0.0;
            population = 0.0;
            vvp = 0.0;
        }
        public Country(string name, double square, double population, double vvp)
        {
            this.name = name;
            this.square = square;
            this.population = population;
            this.vvp = vvp;
        }
        public string setName
        {
            get { return name; }
            set { name = value; }
        }
        public double setSquare
        {
            get { return square; }
            set { square = value; }
        }
        public double setPopulation
        {
            get { return population; }
            set { population = value; }
        }
        public double setVVP
        {
            get { return vvp; }
            set { vvp = value; }
        }
        public override string ToString()
        {
            return string.Format("Країна : {0}\nПлоща : {1} км^2 \nНаселення : {2} осіб \nВВП : {3} $", name, square, population, vvp);
        }
        public double populationDensity()
        {
            return population / square;
        }
        public double vvvOnOnePeople()
        {
            return vvp / population;
        }
        public void printOn()
        {
            Console.WriteLine("Густота населення: {0} осіб/км^2", populationDensity());
            Console.WriteLine("ВВП на душу населення: {0} $", vvvOnOnePeople());
        }
    }
}




