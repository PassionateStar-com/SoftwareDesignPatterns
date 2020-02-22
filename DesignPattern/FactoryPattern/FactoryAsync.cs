//To use async intialization we cannot use the constructor.
//Only way to make an intialization async is by factory method.

using System;
using System.Threading.Tasks;

namespace FactoryPattern
{
    namespace FactoryAsynPattern
    {

        public class Foo
        {

            public static async Task<Foo> CreateAsyncInstance()
            {
                await Task.Delay(10000);
                Foo obj = new Foo();
                return obj;
            }
            private Foo()
            {

            }
        }


        public class FactoryAsync
        {
            public FactoryAsync()
            {
                var foo = Foo.CreateAsyncInstance();
            }
        }
    }

}
