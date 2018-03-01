using System;
using System.IO;
using System.Collections.Generic;

namespace Open_Closed_Principle
{
    /*

        In object-oriented programming, the open/closed principle states "software entities (classes, modules, functions, etc.) 
        should be open for extension, but closed for modification"; that is, such an entity can allow its behaviour to be extended 
        without modifying its source code.

        The name open/closed principle has been used in two ways. Both ways use inheritance to resolve the apparent dilemma, but the goals, 
        techniques, and results are different.
    
     */
    public enum Color 
    {
        Red, Green, Blue
    }

    public enum Size 
    {
        Small, Medium, Large, Yuge
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            if (name == null)
            {

            }
            Name = name;
            Color = color;
            Size = size;
        }
    }

    public class ProductFilter
    {
        /*
            Open for extension. Closed for modification.
            Which means that I should be able to add new filters
            without modifying the class itself.

            This as it is now is not open-closed.
         */
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size) 
        {
            foreach (var p in products)
            {
                if (p.Size == size)
                    yield return p; 
            }
        }
        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color) 
        {
            foreach (var p in products)
            {
                if (p.Color == color)
                    yield return p; 
            }
        }


    }
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;

        public SizeSpecification(Size size)
        {
            this.size = size;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Size == size;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;

        public AndSpecification(ISpecification<T> f, ISpecification<T> s)
        {
            first = f;
            second = s;
        }
        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var i in items)
            {
                if (spec.IsSatisfied(i))
                    yield return i;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = {apple, tree, house};

            var pf = new ProductFilter();
            Console.WriteLine("Green Products (old):");
            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {p.Name} is green");
            }

            var bf = new BetterFilter();
            Console.WriteLine("Green products (new)");
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($" - {p.Name} is green");
            }
            Console.WriteLine("Large blue items");
            foreach (var p in bf.Filter(products,
                new AndSpecification<Product>(
                    new ColorSpecification(Color.Blue),
                    new SizeSpecification(Size.Large)
                )))
                {
                    Console.WriteLine($" - {p.Name} is blue and large");
                }
        }
    }
}
