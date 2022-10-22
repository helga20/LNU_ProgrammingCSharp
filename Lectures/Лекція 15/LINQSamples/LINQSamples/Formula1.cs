using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.LINQ
{
   public static class Formula1
   {
      public static IList<Racer> GetChampions()
      {
         List<Racer> racers = new List<Racer>(40);
         racers.Add(new Racer("Nino", "Farina", "Italy", 33, 5));
         racers.Add(new Racer("Alberto", "Ascari", "Italy", 32, 10));
         racers.Add(new Racer("Juan Manuel", "Fangio", "Argentina", 51, 24));
         racers.Add(new Racer("Mike", "Hawthorn", "UK", 45, 3));
         racers.Add(new Racer("Phil", "Hill", "USA", 48, 3));
         racers.Add(new Racer("John", "Surtees", "UK", 111, 6));
         racers.Add(new Racer("Jim", "Clark", "UK", 72, 25));
         racers.Add(new Racer("Jack", "Brabham", "Australia", 125, 14));
         racers.Add(new Racer("Denny", "Hulme", "New Zealand", 112, 8));
         racers.Add(new Racer("Graham", "Hill", "UK", 176, 14));
         racers.Add(new Racer("Jochen", "Rindt", "Austria", 60, 6));
         racers.Add(new Racer("Jackie", "Stewart", "UK", 99, 27));
         racers.Add(new Racer("Emerson", "Fittipaldi", "Brazil", 143, 14));
         racers.Add(new Racer("James", "Hunt", "UK", 91, 10));
         racers.Add(new Racer("Mario", "Andretti", "USA", 128, 12));
         racers.Add(new Racer("Jody", "Scheckter", "South Africa", 112, 10));
         racers.Add(new Racer("Alan", "Jones", "Australia", 115, 12));
         racers.Add(new Racer("Keke", "Rosberg", "Finland", 114, 5));
         racers.Add(new Racer("Niki", "Lauda", "Austria", 170, 25));
         racers.Add(new Racer("Nelson", "Piquet", "Brazil", 204, 23));
         racers.Add(new Racer("Ayrton", "Senna", "Brazil", 161, 41));
         racers.Add(new Racer("Nigel", "Mansell", "UK", 187, 31));
         racers.Add(new Racer("Alain", "Prost", "France", 197, 51));
         racers.Add(new Racer("Damon", "Hill", "UK", 114, 22));
         racers.Add(new Racer("Jacques", "Villeneuve", "Canada", 165, 11));
         racers.Add(new Racer("Mika", "Hakkinen", "Finland", 160, 20));
         racers.Add(new Racer("Michael", "Schumacher", "Germany", 250, 91));
         racers.Add(new Racer("Fernando", "Alonso", "Spain", 88, 15));
         racers.Add(new Racer("Kimi", "Räikkönen", "Finland", 122, 15));
         racers.Add(new Racer("Lewis", "Hamilton", "UK", 232, 41));
         racers.Add(new Racer("Jenson", "Button", "UK", 306, 6));
         racers.Add(new Racer("Sebastian", "Vettel", "Germany", 222, 34));
         racers.Add(new Racer("Nico", "Rosberg", "Germany", 206, 9));

         return racers;
      }
   }
}
