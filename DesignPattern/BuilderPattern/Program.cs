using System;
using System.Text;

namespace BuilderPattern
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            //WithoutBuilder obj = new WithoutBuilder();
            //obj.GenerateHtml();

            //WithBuilder builder = new WithBuilder();
            //builder.GenerateHtml();

            FluentBuilderGenerics fluentBuilder = new FluentBuilderGenerics();
        }
    }
}
