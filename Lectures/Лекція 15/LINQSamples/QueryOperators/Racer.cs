using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.LINQ
{
   [Serializable]
   public class Racer : IComparable<Racer>, IFormattable, IEquatable<Racer>
   {
      public string FirstName {get; set;}
      public string LastName {get; set;}
      public int Wins {get; set;}
      public string Country {get; set;}
      public int Starts {get; set;}
      public string[] Cars { get; set; }
      public int[] Years { get; set; }

      public override string ToString()
      {
         return String.Format("{0} {1}", FirstName, LastName);
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
            case "C":
               return Country;
            case "S":
               return Starts.ToString();
            case "W":
               return Wins.ToString();
            case "A":
               return String.Format("{0} {1}, {2}; starts: {3}, wins: {4}",
                  FirstName, LastName, Country, Starts, Wins);
            default:
               throw new FormatException(String.Format(
                  "Format {0} not supported", format));
         }
      }

      public override bool Equals(object obj)
      {
          return this.Equals(obj);
      }

      #region IEquatable<Racer> Members

      public bool Equals(Racer other)
      {
          return this.FirstName == other.FirstName && this.LastName == other.LastName;
      }

      public override int GetHashCode()
      {
          return LastName.GetHashCode();
      }

      #endregion
   }

}
