#Builder Pattern
The builder pattern is an object creation software design pattern. Unlike the abstract factory pattern and the factory method pattern whose intention is to enable polymorphism, the intention of the builder pattern is to find a solution to the telescoping constructor anti-pattern[citation needed] that occurs when the increase of object constructor parameter combination leads to an exponential list of constructors. Instead of using numerous constructors, the builder pattern uses another object, a builder, that receives each initialization parameter step by step and then returns the resulting constructed object at once.

The builder pattern has another benefit: It can be used for objects that contain flat data (HTML code, SQL query, X.509 certificate…), that is to say, data that can't be easily edited step by step and hence must be edited at once.[citation needed]

Builder often builds a Composite. Often, designs start out using Factory Method (less complicated, more customizable, subclasses proliferate) and evolve toward Abstract Factory, Prototype, or Builder (more flexible, more complex) as the designer discovers where more flexibility is needed. Sometimes creational patterns are complementary: Builder can use one of the other patterns to implement which components are built. Builders are good candidates for a fluent interface.[1][better source needed]


#Overview:

The Builder design pattern is one of the twenty-three well-known GoF design patterns[2] that describe how to solve recurring design problems to design flexible and reusable object-oriented software, that is, objects that are easier to implement, change, test, and reuse.

The Builder design pattern solves problems like:[3]

How can a class (the same construction process) create different representations of a complex object?
How can a class that includes creating a complex object be simplified?
Creating and assembling the parts of a complex object directly within a class is inflexible. It commits the class to creating a particular representation of the complex object and makes it impossible to change the representation later independently from (without having to change) the class.

The Builder design pattern describes how to solve such problems:

Encapsulate creating and assembling the parts of a complex object in a separate Builder object.
A class delegates object creation to a Builder object instead of creating the objects directly.
A class (the same construction process) can delegate to different Builder objects to create different representations of a complex object.
See also the UML class and sequence diagram below.