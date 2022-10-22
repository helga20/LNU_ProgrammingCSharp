using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.LINQ
{
   [Serializable]
   public class Racer : IComparable<Racer>, IFormattable
   {
      public Racer(string firstName, string lastName, string country, int starts, 
            int wins)
      {
         this.FirstName = firstName;
         this.LastName = lastName;
         this.Country = country;
         this.Starts = starts;
         this.Wins = wins;
      }

      public Racer(string firstName, string lastName, string country, int starts)
         : this(firstName, lastName, country, starts, 0) { }


      public Racer(string firstName, string lastName, string country)
         : this(firstName, lastName, country, 0) { }

      public Racer(string firstName, string lastName)
         : this(firstName, lastName, "unknown") { }


      public string FirstName {get; set;}
      public string LastName {get; set;}
      public int Wins {get; set;}
      public string Country {get; set;}
      public int Starts {get; set;}

 

      public override string ToString()
      {
         return FirstName + " " + LastName;
      }

      public int CompareTo(Racer other)
      {
         return this.LastName.CompareTo(other.LastName);
      }

      public string ToString(string format)
      {
         return ToString(format, null);
      }

      public string ToString(string format, IFormatProvider formatProvider)
      {
         switch (format)
         {
            case null:
            case "N":
               return ToString();
            case "F":
               return FirstName;
            case "L":
               return LastName;
            case "A":
               return String.Format("{0} {1}, {2}; starts: {3}, wins: {4}",
                  FirstName, LastName, Country, Starts, Wins);
            default:
               throw new FormatException(String.Format(
                  "Format {0} not supported", format));
         }
      }
   }

}
