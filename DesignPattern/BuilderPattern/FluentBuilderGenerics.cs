using System;
namespace BuilderPattern
{


    public class Person
    {
        public string Name;
        public string Company;

        public class Builder : PersonJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"Person {Name} works for {Company}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }


    public class PersonInfoBuilder<SELF> : PersonBuilder
        where SELF: PersonInfoBuilder<SELF>
    {
        public SELF InitializePersonName(string Name)
        {
            person.Name = Name;
            return (SELF)this;
        }
    }

    public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAt(string companyName)
        {
            person.Company = companyName;
            return (SELF)this;
        }
    }

    public class FluentBuilderGenerics
    {
        public FluentBuilderGenerics()
        {
            var me = Person.New.InitializePersonName("Aakash").WorksAt("Google").Build();
            Console.WriteLine(me);
        }
    }
}
