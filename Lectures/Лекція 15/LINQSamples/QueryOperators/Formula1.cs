﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QueryOperators;

namespace Wrox.ProCSharp.LINQ
{
    public class Formula1
    {
        public static IList<Racer> GetChampions()
        {
            List<Racer> racers = new List<Racer>(40);
            racers.Add(new Racer() { FirstName = "Nino", LastName = "Farina", Country = "Italy", Starts = 33, Wins = 5, Years = new int[] { 1950 }, Cars = new string[] { "Alfa Romeo" } });
            racers.Add(new Racer() { FirstName = "Alberto", LastName = "Ascari", Country = "Italy", Starts = 32, Wins = 10, Years = new int[] { 1952, 1953 }, Cars = new string[] { "Ferrari" } });
            racers.Add(new Racer() { FirstName = "Juan Manuel", LastName = "Fangio", Country = "Argentina", Starts = 51, Wins = 24, Years = new int[] { 1951, 1954, 1955, 1956, 1957 }, Cars = new string[] { "Alfa Romeo", "Maserati", "Mercedes", "Ferrari" } });
            racers.Add(new Racer() { FirstName = "Mike", LastName = "Hawthorn", Country = "UK", Starts = 45, Wins = 3, Years = new int[] { 1958 }, Cars = new string[] { "Ferrari" } });
            racers.Add(new Racer() { FirstName = "Phil", LastName = "Hill", Country = "USA", Starts = 48, Wins = 3, Years = new int[] { 1961 }, Cars = new string[] { "Ferrari" } });
            racers.Add(new Racer() { FirstName = "John", LastName = "Surtees", Country = "UK", Starts = 111, Wins = 6, Years = new int[] { 1964 }, Cars = new string[] { "Ferrari" } });
            racers.Add(new Racer() { FirstName = "Jim", LastName = "Clark", Country = "UK", Starts = 72, Wins = 25, Years = new int[] { 1963, 1965 }, Cars = new string[] { "Lotus" } });
            racers.Add(new Racer() { FirstName = "Jack", LastName = "Brabham", Country = "Australia", Starts = 125, Wins = 14, Years = new int[] { 1959, 1960, 1966 }, Cars = new string[] { "Cooper", "Brabham" } });
            racers.Add(new Racer() { FirstName = "Denny", LastName = "Hulme", Country = "New Zealand", Starts = 112, Wins = 8, Years = new int[] { 1967 }, Cars = new string[] { "Brabham" } });
            racers.Add(new Racer() { FirstName = "Graham", LastName = "Hill", Country = "UK", Starts = 176, Wins = 14, Years = new int[] { 1962, 1968 }, Cars = new string[] { "BRM", "Lotus" } });
            racers.Add(new Racer() { FirstName = "Jochen", LastName = "Rindt", Country = "Austria", Starts = 60, Wins = 6, Years = new int[] { 1970 }, Cars = new string[] { "Lotus" } });
            racers.Add(new Racer() { FirstName = "Jackie", LastName = "Stewart", Country = "UK", Starts = 99, Wins = 27, Years = new int[] { 1969, 1971, 1973 }, Cars = new string[] { "Matra", "Tyrrell" } });
            racers.Add(new Racer() { FirstName = "Emerson", LastName = "Fittipaldi", Country = "Brazil", Starts = 143, Wins = 14, Years = new int[] { 1972, 1974 }, Cars = new string[] { "Lotus", "McLaren" } });
            racers.Add(new Racer() { FirstName = "James", LastName = "Hunt", Country = "UK", Starts = 91, Wins = 10, Years = new int[] { 1976 }, Cars = new string[] { "McLaren" } });
            racers.Add(new Racer() { FirstName = "Mario", LastName = "Andretti", Country = "USA", Starts = 128, Wins = 12, Years = new int[] { 1978 }, Cars = new string[] { "Lotus" } });
            racers.Add(new Racer() { FirstName = "Jody", LastName = "Scheckter", Country = "South Africa", Starts = 112, Wins = 10, Years = new int[] { 1979 }, Cars = new string[] { "Ferrari" } });
            racers.Add(new Racer() { FirstName = "Alan", LastName = "Jones", Country = "Australia", Starts = 115, Wins = 12, Years = new int[] { 1980 }, Cars = new string[] { "Williams" } });
            racers.Add(new Racer() { FirstName = "Keke", LastName = "Rosberg", Country = "Finland", Starts = 114, Wins = 5, Years = new int[] { 1982 }, Cars = new string[] { "Williams" } });
            racers.Add(new Racer() { FirstName = "Niki", LastName = "Lauda", Country = "Austria", Starts = 173, Wins = 25, Years = new int[] { 1975, 1977, 1984 }, Cars = new string[] { "Ferrari", "McLaren" } });
            racers.Add(new Racer() { FirstName = "Nelson", LastName = "Piquet", Country = "Brazil", Starts = 204, Wins = 23, Years = new int[] { 1981, 1983, 1987 }, Cars = new string[] { "Brabham", "Williams" } });
            racers.Add(new Racer() { FirstName = "Ayrton", LastName = "Senna", Country = "Brazil", Starts = 161, Wins = 41, Years = new int[] { 1988, 1990, 1991 }, Cars = new string[] { "McLaren" } });
            racers.Add(new Racer() { FirstName = "Nigel", LastName = "Mansell", Country = "UK", Starts = 187, Wins = 31, Years = new int[] { 1992 }, Cars = new string[] { "Williams" } });
            racers.Add(new Racer() { FirstName = "Alain", LastName = "Prost", Country = "France", Starts = 197, Wins = 51, Years = new int[] { 1985, 1986, 1989, 1993 }, Cars = new string[] { "McLaren", "Williams" } });
            racers.Add(new Racer() { FirstName = "Damon", LastName = "Hill", Country = "UK", Starts = 114, Wins = 22, Years = new int[] { 1996 }, Cars = new string[] { "Williams" } });
            racers.Add(new Racer() { FirstName = "Jacques", LastName = "Villeneuve", Country = "Canada", Starts = 165, Wins = 11, Years = new int[] { 1997 }, Cars = new string[] { "Williams" } });
            racers.Add(new Racer() { FirstName = "Mika", LastName = "Hakkinen", Country = "Finland", Starts = 160, Wins = 20, Years = new int[] { 1998, 1999 }, Cars = new string[] { "McLaren" } });
            racers.Add(new Racer() { FirstName = "Michael", LastName = "Schumacher", Country = "Germany", Starts = 250, Wins = 91, Years = new int[] { 1994, 1995, 2000, 2001, 2002, 2003, 2004 }, Cars = new string[] { "Benetton", "Ferrari" } });
            racers.Add(new Racer() { FirstName = "Fernando", LastName = "Alonso", Country = "Spain", Starts = 105, Wins = 19, Years = new int[] { 2005, 2006 }, Cars = new string[] { "Renault" } });
            racers.Add(new Racer() { FirstName = "Kimi", LastName = "Räikkönen", Country = "Finland", Starts = 122, Wins = 15, Years = new int[] { 2007 }, Cars = new string[] { "Ferrari" } });
            racers.Add(new Racer() { FirstName = "Lewis", LastName = "Hamilton", Country = "UK", Starts = 253, Wins = 52, Years = new int[] { 2008, 2014, 2015, 2017, 2018, 2019 }, Cars = new string[] { "McLaren", "Mercedes" } });
            racers.Add(new Racer() { FirstName = "Jenson", LastName = "Button", Country = "UK", Starts = 306, Wins = 6, Years = new int[] { 2009 }, Cars = new string[] { "Mercedes" } });
            racers.Add(new Racer() { FirstName = "Sebastian", LastName = "Vettel", Country = "Germany", Starts = 222, Wins = 34, Years = new int[] { 2010, 2011, 2012, 2013 }, Cars = new string[] { "Red Bull" } });
            racers.Add(new Racer() { FirstName = "Nico", LastName = "Rosberg", Country = "Germany", Starts = 206, Wins = 9, Years = new int[] { 2016 }, Cars = new string[] { "Mercedes" } });
            return racers;
        }

        public static IList<Team> GetContructorChampions()
        {
            List<Team> teams = new List<Team>(20);
            teams.Add(new Team() { Name = "Vanwall", Years = new int[] { 1958 } });
            teams.Add(new Team() { Name = "Cooper", Years = new int[] { 1959, 1960 } });
            teams.Add(new Team() { Name = "Ferrari", Years = new int[] { 1961, 1964, 1975, 1976, 1977, 1979, 1982, 1983, 1999, 2000, 2001, 2002, 2003, 2004, 2007, 2008 } });
            teams.Add(new Team() { Name = "BRM", Years = new int[] { 1962 } });
            teams.Add(new Team() { Name = "Lotus", Years = new int[] { 1963, 1965, 1968, 1970, 1972, 1973, 1978 } });
            teams.Add(new Team() { Name = "Brabham", Years = new int[] { 1966, 1967 } });
            teams.Add(new Team() { Name = "Matra", Years = new int[] { 1969 } });
            teams.Add(new Team() { Name = "Tyrrell", Years = new int[] { 1971 } });
            teams.Add(new Team() { Name = "McLaren", Years = new int[] { 1974, 1984, 1985, 1988, 1989, 1990, 1991, 1998 } });
            teams.Add(new Team() { Name = "Williams", Years = new int[] { 1980, 1981, 1986, 1987, 1992, 1993, 1994, 1996, 1997 } });
            teams.Add(new Team() { Name = "Benetton", Years = new int[] { 1995 } });
            teams.Add(new Team() { Name = "Renault", Years = new int[] { 2005, 2006 } });
            teams.Add(new Team() { Name = "Brawn", Years = new int[] { 2009 } });
            teams.Add(new Team() { Name = "Red Bull", Years = new int[] { 2010, 2011, 2012, 2013 } });
            teams.Add(new Team() { Name = "Mercedes", Years = new int[] { 2014, 2015, 2016, 2017, 2018, 2019 } });

            return teams;
        }
    }
    public class Car
    {
        public string PetName { get; set; }
        public string Color { get; set; }
        public int Speed { get; set; }
        public string Make { get; set; }
    }
}
