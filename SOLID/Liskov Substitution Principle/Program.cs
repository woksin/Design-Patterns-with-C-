using System;

/*
    Substitutability is a principle in object-oriented programming stating that, in a computer program,
    if S is a subtype of T, then objects of type T may be replaced with objects of type S 
    (i.e. an object of type T may be substituted with any object of a subtype S) without altering any of 
    the desirable properties of T (correctness, task performed, etc.). More formally, the Liskov substitution 
    principle (LSP) is a particular definition of a subtyping relation, called (strong) behavioral subtyping, 
    that was initially introduced by Barbara Liskov in a 1987 conference keynote address titled Data abstraction 
    and hierarchy. It is a semantic rather than merely syntactic relation because it intends to guarantee semantic 
    interoperability of types in a hierarchy, object types in particular. Barbara Liskov and Jeannette Wing formulated 
    the principle succinctly in a 1994 paper as follows:
 */
namespace Liskov_Substitution_Principle {

    public class Rectangle {
        
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {
            
        }
        public Rectangle (int width, int height) {
            this.Width = width;
            this.Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
        
    }

    public class Square : Rectangle
    {
        public override int Width
        {
            set {base.Width = base.Height = value; }
        }
        public override int Height
        {
            set {base.Width = base.Height = value; }
        }
    }
    

    class Program {
        static public int Area(Rectangle r) => r.Width * r.Height;
        static void Main (string[] args) {
            Rectangle rc = new Rectangle(2, 3);

            System.Console.WriteLine($"{rc} has area {Area(rc)}");

            // Gets correct result
            Square sq = new Square();
            sq.Width = 4;

            System.Console.WriteLine($"{sq} has area {Area(sq)}");

            // Should be same as sq, right? WRONG!
            Rectangle sq2 = new Square();
            sq2.Width = 4;

            System.Console.WriteLine($"{sq2} has area {Area(sq2)}");
            
            // Setters
        }
    }
}