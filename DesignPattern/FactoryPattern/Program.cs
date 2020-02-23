using System;
using FactoryPattern.WithoutFactoryPattern;
using FactoryPattern.WithFactoryPattern;
using FactoryPattern.FactoryAsynPattern;
using FactoryPattern.WithFactoryClassPattern;

namespace FactoryPattern
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //WithoutFactory withoutFactory = new WithoutFactory();
            //WithFactory withFactory = new WithFactory();
            //FactoryAsync factoryAsync = new FactoryAsync();
            WithFactoryClass factoryClass = new WithFactoryClass();


        }
    }
}
