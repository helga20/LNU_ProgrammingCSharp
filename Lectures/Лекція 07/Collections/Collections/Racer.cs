using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Racer : IComparable<Racer>, IFormattable 
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public int Wins { get; set; } 
        public Racer(int id, string firstName, string lastName, string country = null, int wins = 0) 
        { 
            this.Id = id; 
            this.FirstName = firstName; 
            this.LastName = lastName; 
            this.Country = country; 
            this.Wins = wins; 
        } 
        public override string ToString() 
        { 
            return String.Format("{0} {1}", FirstName, LastName); 
        } 
        public string ToString(string format, IFormatProvider formatProvider) 
        { 
            if (format == null) format = "N"; 
            switch (format.ToUpper ()) 
            { 
            case "N" : // ім'я та прізвище 
                    return ToString();
            case "F": // ім'я 
                    return FirstName; 
            case "L": // прізвище 
                    return LastName; 
            case "W": // кількість перемог 
                    return String.Format("{0}, Перемог: {1}", ToString(), Wins);
            case "C": // країна 
                    return String.Format(" {0}, Країна: {1}", ToString(), Country);
            case "A": // все разом 
                    return String.Format("{0}, {1} Перемог: {2}", ToString(), Country, Wins); 
            default:
                    throw new FormatException(String.Format(formatProvider, "Формат {0} не підтримується", format));
            } 
        } 
        public string ToString(string format) 
        { 
            return ToString(format, null); 
        } 
        public int CompareTo(Racer other) 
        { 
            int compare = this.LastName.CompareTo(other.LastName); 
            if (compare == 0)
                return this.FirstName.CompareTo(other.FirstName);
            else
                return compare; 
        } 
    }
    public class RacerComparer : IComparer<Racer>
    {
        public enum CompareType
        {
            Firstname, Lastname, Country, Wins
        }
        private CompareType compareType;
        public RacerComparer(CompareType compareType)
        {
            this.compareType = compareType;
        }
        public int Compare(Racer x, Racer y)
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            int result;
            switch (compareType)
            {
                case CompareType.Firstname:
                    return x.FirstName.CompareTo(y.FirstName);
                case CompareType.Lastname:
                    return x.LastName.CompareTo(y.LastName);
                case CompareType.Country:
                    if ((result = x.Country.CompareTo(y.Country)) == 0)
                        return x.LastName.CompareTo(y.LastName);
                    else return result;
                case CompareType.Wins:
                    return -x.Wins.CompareTo(y.Wins);
                default:
                    throw new ArgumentException("Недопустимий тип для порівняння");
            }
        }
    }
}
