using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace WithSingletonPattern
{

    public interface IDatabase
    {
        int GetPopulation(string cityName);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> cityDict;
        private static int instanceCount;
        public static int InstanceCount => instanceCount;
        private SingletonDatabase()
        {
            Console.WriteLine("Initializing the database");
            instanceCount += 1;

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

        private static SingletonDatabase instance = new SingletonDatabase();
        public static SingletonDatabase Instance => instance;
    }
    public class WithSingleton
    {
        public WithSingleton()
        {
            var db = SingletonDatabase.Instance;
            Console.WriteLine(db.GetPopulation("Losangeles"));
        }
    }
}
