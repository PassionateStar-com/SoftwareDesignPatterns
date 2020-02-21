using System;
using WithoutSingletonPattern;
using WithSingletonPattern;
using WithSingletonPatternLazy;

namespace SingletonPattern
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //WithoutSingleton obj = new WithoutSingleton();
            //WithSingleton obj2 = new WithSingleton();
            WithSingletonLazy obj3 = new WithSingletonLazy();
        }
    }
}
