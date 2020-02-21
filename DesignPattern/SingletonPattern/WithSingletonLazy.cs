using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace WithSingletonPatternLazy
{

    public interface IDatabase
    {
        int GetPopulation(string cityName);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> cityDict;

        private SingletonDatabase()
        {
            Console.WriteLine("Initializing the database");

            //Open a file and read all the data
            cityDict = File.ReadAllLines("CityPopulation.txt").
                Batch(2).
                ToDictionary
                (
                    list => list.ElementAt(0),
                    list => int.Parse(list.ElementAt(1))
                );

        }

        public int GetPopulation(string cityName)
        {
            return cityDict[cityName];
        }

        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(()=> new SingletonDatabase());
        public static SingletonDatabase Instance => instance.Value;
    }
    public class WithSingletonLazy
    {
        public WithSingletonLazy()
        {
            var db = SingletonDatabase.Instance;
            Console.WriteLine(db.GetPopulation("Losangeles"));
        }
    }
}
