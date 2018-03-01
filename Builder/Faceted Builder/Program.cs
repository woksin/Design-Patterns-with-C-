using System;
using static System.Console;

namespace Faceted_Builder
{    
    public class Person
    {
        public string StreetAddress { get; set; }
        public string PostCode { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public int AnualIncome { get; set; }

        public override string ToString()
        {
            return $"StreeAddress: {StreetAddress}, PostCode: {PostCode}, City: {City}" +
            $"CompanyName: {CompanyName}, Position: {Position}, AnualIncome: {AnualIncome}";
        }   
    }

    public class PersonBuilder // Facade
    {
        // Reference
        protected Person person = new Person();
        public PersonJobBuilder Works => new PersonJobBuilder(person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

        public static implicit operator Person(PersonBuilder personBuilder)
            => personBuilder.person;


    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            person.AnualIncome = amount;
            return this;
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostCode(string postcode)
        {
            person.Postcode = postcode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var pb =new PersonBuilder();
            Person person = pb
                .Lives  .At("123 London Road")
                        .In("London")
                        .WithPostCode("sw12ac")
                .Works  .At("Fabrikam")
                        .AsA("Engineer")
                        .Earning(123000);

            WriteLine(person);

        }
    }
}
