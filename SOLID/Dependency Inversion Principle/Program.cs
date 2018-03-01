using System;
using System.Collections.Generic;
using System.Linq;

/*
In object-oriented design, the dependency inversion principle refers to a specific 
form of decoupling software modules. When following this principle, the conventional
dependency relationships established from high-level, policy-setting modules to low-level, 
dependency modules are reversed, thus rendering high-level modules independent of the low-level 
module implementation details. The principle states:

A. High-level modules should not depend on low-level modules. Both should depend on abstractions.
B. Abstractions should not depend on details. Details should depend on abstractions.
By dictating that both high-level and low-level objects must depend on the same abstraction this 
design principle inverts the way some people may think about object-oriented programming.

The idea behind points A and B of this principle is that when designing the interaction between a 
high-level module and a low-level one, the interaction should be thought of as an abstract interaction 
between them. This not only has implications on the design of the high-level module, but also on the low-level 
one: the low-level one should be designed with the interaction in mind and it may be necessary to change its usage interface.

In many cases, thinking about the interaction in itself as an abstract concept allows the coupling of 
the components to be reduced without introducing additional coding patterns, allowing only a lighter and 
less implementation dependent interaction schema.

When the discovered abstract interaction schema(s) between two modules is/are generic and generalization makes sense, 
this design principle also leads to the following dependency inversion coding pattern.
 */

namespace Dependency_Inversion_Principle {
    public enum Relationship {
        Parent,
        Child,
        Sibling
    }

    public class Person {
        public string Name { get; set; }

    }
    public interface IRelationshipBrowser {
        IEnumerable<Person> FindAllChildrenOf (string name);
    }
    //LOW-LEVEL
    public class Relationships : IRelationshipBrowser 
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)> ();

        public void AddParentAndChild (Person parent, Person child) {
            relations.Add ((parent, Relationship.Parent, child));
            relations.Add ((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            foreach (var relation in relations.Where (
                    x => x.Item1.Name == "John" &&
                    x.Item2 == Relationship.Parent
            )) 
            {
                yield return relation.Item3;        
            }
        }

        //public List<(Person, Relationshi, Person)> Relations => relations;
    }

    class Research {
        // BAD. Relies on low level implementaion of the Relationship class
        // public Research (Relationships relationships) {
        //     var relations = relationships.Relations;

        //     foreach (var relation in relations.Where (
        //             x => x.Item1.Name == "John" &&
        //             x.Item2 == Relationshi.Parent
        //         )) {
        //         System.Console.WriteLine ($"John has a child called {relation.Item3.Name}");
        //     }
        // }

        public Research(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
            {
                System.Console.WriteLine($"John is father of {p}");
            }
        }
        static void Main (string[] args) {
            var parent1 = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationships ();
            relationships.AddParentAndChild (parent1, child1);
            relationships.AddParentAndChild (parent1, child2);

            var r = new Research (relationships);

        }

    }
}