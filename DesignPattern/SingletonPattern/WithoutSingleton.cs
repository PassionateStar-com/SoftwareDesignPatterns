using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace WithoutSingletonPattern
{

    public interface IDatabase
    {
        int GetPopulation(string cityName);
    }

    public class Database : IDatabase
    {
        private Dictionary<string, int> cityDict;

        //With every instance of the database the file will be opened and read into the memory.
        //It's expensive operation.
        public Database()
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
    }
    public class WithoutSingleton
    {
        public WithoutSingleton()
        {
            var db = new Database();
            Console.WriteLine(db.GetPopulation("Losangeles"));

            //We should not allow the user to create more than one instance of the database since it's expensive
            //Everytime in the constructor it's loading the database again.
            var dbObj2 = new Database();
            Console.WriteLine(dbObj2.GetPopulation("Sanfrancisco"));
        }
    }
}
