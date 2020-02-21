using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace WithSingletonPattern
{
    //SingletonPopulationFinder has a strict hardcoded dependency of the singletondatabase
    //This is bad for testing
    public class SingletonPopulationFinder
    {
        public int GetTotalPopulation(List<string> cityNames)
        {
            int result = 0;
            foreach (var city in cityNames)
            {
                result += SingletonDatabase.Instance.GetPopulation(city);
            }

            return result;
        }
    }


    [TestFixture]
    public class SingletonTest
    {
        [Test]
        public void IsSingletonTest()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDatabase.InstanceCount, Is.EqualTo(1));
        }

        //There is a problem. We have to look into actual database to find the total population.
        //We are not able to pass in a mock database
        //Because the class SingletonPopulationFinder has a strict hardcoded dependency of the singletondatabase 
        [Test]
        public void TestTotalPopulation()
        {
            List<string> cities = new List<string>{ "Seattle", "Sanfrancisco" };
            SingletonPopulationFinder popFinder = new SingletonPopulationFinder();
            Assert.That(popFinder.GetTotalPopulation(cities), Is.EqualTo(130000));
        }

    }
}
