using System;

namespace Interface_Seggregation_Principle
{

    public class Doucment
    {
        
    }

    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Print(Document d)
        {

        }

    }

    public class OldFashionedPrinter : IMachine
    {
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
