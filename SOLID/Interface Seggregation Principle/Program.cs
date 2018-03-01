using System;

/*
The interface-segregation principle (ISP) states that no client should be forced to 
depend on methods it does not use. ISP splits interfaces that are very large into 
smaller and more specific ones so that clients will only have to know about the methods that 
are of interest to them. Such shrunken interfaces are also called role interfaces. ISP is intended 
to keep a system decoupled and thus easier to refactor, change, and redeploy. 
ISP is one of the five SOLID principles of object-oriented design, similar to the High Cohesion Principle of GRASP.
 */
namespace Interface_Seggregation_Principle
{

    public class Document
    {
        
    }

    // Not good. You want to split up responsibility
    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document d)
        {
        }

        public void Print(Document d)
        {
            
        }

        public void Scan(Document d)
        {
        }
    }

    public class OldFashionedPrinter : IMachine
    {
        public void Fax(Document d)
        {
        }

        public void Print(Document d)
        {

        }

        public void Scan(Document d)
        {

        }
    }

    public interface IPrinter
    {
        void Print(Document doc);    
    }
    public interface IScanner
    {
        void Scan(Document doc);    
    }
    public interface IFaxer
    {
        void Fax(Document doc);    
    }

    public interface IMultiFunctionDevice : IScanner, IPrinter 
    { }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        IPrinter Printer;
        IScanner Scanner;
        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            if (printer == null) 
            {
                throw new ArgumentNullException();
            }
            if (scanner == null) 
            {
                throw new ArgumentNullException();
            }
            Scanner = scanner;
            Printer = printer;

        }
        public void Print(Document doc)
        {
            Printer.Print(doc);
        }

        public void Scan(Document doc)
        {
            Scanner.Scan(doc);
            // Decorator
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
