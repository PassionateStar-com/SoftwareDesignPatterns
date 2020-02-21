using System;

namespace MonostatePattern
{
    //Aim of this pattern is to imitatate the singleton pattern by providing static fields.
    //Static fields since they are initialized only once are exposed through a public interface
    //More than one instance is allowed to be created but since the data in the static field is shared across the instance
    //and the static constructor is called only once it imitates the singleton pattern
    public class CEO
    {
        private static string name;
        private static int age;

        public int Age { get=>age; set=> age=value; }
        public string Name { get => name; set => name = value; }

        public override string ToString()
        {
            return $"Name of the ceo is {name} and their age is {age}";
        }

    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            CEO ceo1 = new CEO();
            ceo1.Name = "Aakash";
            ceo1.Age = 25;

            CEO ceo2 = new CEO();
            Console.WriteLine(ceo2);
        }
    }
}
