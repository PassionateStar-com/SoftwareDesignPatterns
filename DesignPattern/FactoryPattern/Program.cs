using System;
using FactoryPattern.WithoutFactoryPattern;
using FactoryPattern.WithFactoryPattern;

namespace FactoryPattern
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            WithoutFactory withoutFactory = new WithoutFactory();
            WithFactory withFactory = new WithFactory();
            
        }
    }
}
