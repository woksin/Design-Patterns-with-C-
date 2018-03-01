using System;

namespace Fluent_Builder_Inheritance
{

    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }
        
        public class Builder : PersonJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }


    public abstract class  PersonBuilder
    {
        protected Person person = new Person();
        public Person Build() => person;
    }

    public class PersonInfoBuilder<SELF>
        : PersonBuilder
        where SELF : PersonInfoBuilder<SELF>
    {

        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF) this;
        }
    }

    public class PersonJobBuilder<SELF>
        : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF) this;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var me = Person.New
                .Called("Dimitri")
                .WorksAsA("Quant")
                .Build();

            System.Console.WriteLine(me);

        }
    }
}
