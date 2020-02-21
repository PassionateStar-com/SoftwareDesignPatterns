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

        //Here the lazy keyword will only initialize the static fields when the first object is created.
        //Hence it's an optimization. If we don't need the instance of database then no constructor is called atall!
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
