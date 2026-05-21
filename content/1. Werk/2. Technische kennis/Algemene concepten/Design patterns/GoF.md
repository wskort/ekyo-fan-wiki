---
aliases:
  - GoF (Gang of Four)
  - Design Patterns: Elements of Reusable Object-Oriented Software (1994)
tags: Techniek
---
# Design Patterns: Elements of Reusable Objects-Oriented Software
This software engineering book has been influential to the field of software engineering and is regarded as an important source for object-oriented design theory and practice. The authors are often referred to as the **Gang of Four (GoF)**. 

Chapter 1 is a discussion of [[OOP|OOP (Object-Oriented Programming)]] design techniques, based on the authors' experience, which they believe would lead to good object-oriented software design, including:
-   "Program to an interface, not an implementation." (Gang of Four 1995:18)
-   [Composition over inheritance](https://en.wikipedia.org/wiki/Composition_over_inheritance "Composition over inheritance"): "Favor '[object composition](https://en.wikipedia.org/wiki/Object_composition "Object composition")' over '[class inheritance](https://en.wikipedia.org/wiki/Inheritance_(computer_science) "Inheritance (computer science)")'." (Gang of Four 1995:20)

The authors claim the following as advantages of [interfaces](https://en.wikipedia.org/wiki/Interface_(computer_science) "Interface (computer science)") over implementation:
-   clients remain unaware of the specific types of objects they use, as long as the object adheres to the interface
-   clients remain unaware of the classes that implement these objects; clients only know about the abstract class(es) defining the interface

Use of an interface also leads to [dynamic binding](https://en.wikipedia.org/wiki/Dynamic_dispatch "Dynamic dispatch") ([[Java#Generic type]]) and [[Polymorphism]], which are central features of object-oriented programming.

## Patterns by type
- [[GoF#Creational patterns]]
	- [[GoF#Abstract Factory]] groups object factories that have a common theme
	- [[GoF#Builder]] constructs complex objects by seperating construction and representation
	- [[GoF#Factory Method]] creates objects without specifying the exact class to create
	- [[GoF#Prototype]] create objects by cloning an existing object
	- [[GoF#Singleton]] restricts object creation for a class to only one instance.
- [[GoF#Structural patterns]]
	- [[GoF#Adapter]] allows classes with incompatible interfaces to work together by wrapping its own interface around that of an already existing class
	- [[GoF#Bridge]] decouples an abstraction from its implementation so that the two can vary independently
	- [[GoF#Composite]] composes zero-or-more similar objects so that they can be manipulated as one object
	- [[GoF#Decorator]] dynamically adds/overrides behaviour in an existing method of an object
	- [[GoF#Facade]] reduces the cost of creating and manipulating a large number of similar objects
	- [[GoF#Flyweight]] reduces the cost of creating ang manipulating a large number of similar objects.
	- [[GoF#Proxy]] provides a placeholder for another object to control access, reduce cost, and reduce complexity
- [[GoF#Behavioural patterns]]
	- [[GoF#Chain of Responsibility]] delegates commands to a chain of processing objects
	- [[GoF#Command]] creates objects that encapsulate actions and parameters
	- [[GoF#Interpreter]] implements a specialized language
	- [[GoF#Iterator]] accesses the elements of an object sequentially without exposing its underlying representation
	- [[GoF#Mediator]] allows loose coupling between classes by being the only class that has detailed knowledge of their methods
	- [[GoF#Memento]] provides the ability to restore an object to its previous state (undo)
	- [[GoF#Observer]] is a publish/subscribe pattern, which allows a number of observer objects to see an event
	- [[GoF#State]] allows an object to alter its behaviour when its internal state changes
	- [[GoF#Strategy]] allows one of a family of algorithms to be selected on-the-fly at runtime
	- [[GoF#Template Method]] defines the skeleton of an algorithm as an abstract class, allowing its subclasses to provide concrete behaviour.
	- [[GoF#Visitor]] separates an algorithm from an object structure by moving the hierarchy of methods into one object.

### Creational patterns
#### Abstract Factory
The **abstract factory pattern** provides a way to encapsulate a group of individual [[GoF#Factory Method]]s that have a common theme without specifying their concrete classes. In normal usage, the client software creates a concrete implementation of the abstract factory and then uses the generic interface of the factory to create the concrete objects that are part of the theme. The client does not know (or care) which concrete objects it gets from each of these internal factories, since it uses only the generic interfaces of their products. This pattern separates the details of implementation of a set of objects from their general usage and relies on object composition, as object creation is implemented in methods exposed in the factory interface.

#### Builder
Creating and assembling the parts of a complex object directly within a class is inflexible. It commits the class to creating a particular representation of the complex object and makes it impossible to change the representation later independently from (without having to change) the class.

The Builder design pattern describes how to solve such problems:
-   Encapsulate creating and assembling the parts of a complex object in a separate `Builder` object.
-   A class delegates object creation to a `Builder` object instead of creating the objects directly.

A class (the same construction process) can delegate to different `Builder` objects to create different representations of a complex object.

#### Factory Method
In class-based programming such as [[Java]] or [[1. Werk/2. Technische kennis/Languages/CS|C#]], the **factory method pattern** is a creational pattern that uses factory methods to deal with the problem of creating objects without having to specify the exact class of the object that will be created. This is done by creating objects by calling a factory method -- either specified in an interface and implemented by child classes, or implemented by a base class and optionally overridden by derived classes -- rather than by calling a constructor. 

#### Prototype
The **prototype pattern** is a creational design pattern in software development. It is used when the type of objects to create is determined by a prototypical instance, which is cloned to produce new objects. This pattern is used to avoid subclasses of an object creator in the client application, like the [[GoF#Factory Method]] pattern does and to avoid the inherent cost of creating a new object in the standard way (e.g., using the `new` keyword) when it is prohibitively expensive for a given application.

To implement the pattern, declare an abstract base class that specifies a pure virtual _clone()_ method. Any class that needs a "polymorphic constructor" capability derives itself from the abstract base class, and implements the _clone()_ operation.

The client, instead of writing code that invokes the "new" operator on a hard-coded class name, calls the _clone()_ method on the prototype, calls a [[GoF#Factory Method]] with a parameter designating the particular concrete derived class desired, or invokes the _clone()_ method through some mechanism provided by another design pattern.

#### Singleton
The singleton design pattern solves problems by allowing it to:
-   Ensure that a class only has one instance
-   Easily access the sole instance of a class
-   Control its instantiation
-   Restrict the number of instances
-   Access a global variable

The singleton design pattern describes how to solve such problems:
-   Hide the constructors of the class.
-   Define a public static operation (`getInstance()`) that returns the sole instance of the class.

In essence, the singleton pattern forces it to be responsible for ensuring that it is only instantiated once. A hidden constructor—declared `private` or `protected`—ensures that the class can never be instantiated from outside the class. The public static operation can be accessed by using the class name and operation name, e.g., `Singleton.getInstance()`.

### Structural patterns
#### Adapter
The **adapter pattern** is a software design pattern (also known as wrapper, an alternative naming shared with the [[GoF#Decorator]]) that allows the interface of an existing class to be used as another interface. It is often used to make existing classes work with others without modifying their source code.

An example is an adapter that converts the interface of a [[Document Object Model]] of an [[XML]] document into a tree structure that can be displayed.

#### Bridge
The **bridge pattern** is a design pattern used in software engineering that is meant to "decouple an abstraction from its implementation so that the two can vary independently". The bridge uses encapsulation, aggregation, and can use inheritance to separate responsibilities into different classes.

When a class varies often, the features of [[OOP|OOP (Object-Oriented Programming)]] become very useful because changes to a program's code can be made easily with minimal prior knowledge about the program. The bridge pattern is useful when both the class and what it does vary often. The class itself can be thought of as the abstraction and what the class can do as the implementation. The bridge pattern can also be thought of as two layers of abstraction.

When there is only one fixed implementation, this pattern is known as the Pimpl idiom in the [[C++]] world.

The bridge pattern is often confused with the [[GoF#Adapter]] pattern, and is often implemented using the object adapter pattern.

Variant: The implementation can be decoupled even more by deferring the presence of the implementation to the point where the abstraction is utilized.

#### Composite
The composite pattern describes a group of objects that are treated the same way as a single instance of the same type of object. The intent of a composite is to "compose" objects into tree structures to represent part-whole hierarchies. Implementing the composite pattern lets clients treat individual objects and compositions uniformly.

#### Decorator
The decorator pattern is a design pattern that allows behavior to be added to an individual object, dynamically, without affecting the behavior of other objects from the same class. The decorator pattern is often useful for adhering to the Single Responsibility Principle, as it allows functionality to be divided between classes with unique areas of concern. Decorator use can be more efficient than subclassing, because an object's behavior can be augmented without defining an entirely new object.

#### Facade
Analogous to a facade in architecture, a facade is an object that serves as a front-facing interface masking more complex underlying or structural code. A facade can:
- improve the readability and usability of a software library by masking interaction with more complex components behind a single (and often simplified) [[API]]
- provide a context-specific interface to more generic functionality (complete with context-specific input validation)
- serve as a launching point for a broader refactor of monolithic or tightly-coupled systems in favor of more loosely-coupled code

Developers often use the facade design pattern when a system is very complex or difficult to understand because the system has many interdependent classes or because its source code is unavailable. This pattern hides the complexities of the larger system and provides a simpler interface to the client. It typically involves a single wrapper class that contains a set of members required by the client. These members access the system on behalf of the facade client and hide the implementation details.

#### Flyweight
 The flyweight software design pattern refers to an object that minimizes memory usage by sharing some of its data with other similar objects. 

The flyweight pattern is useful when dealing with large numbers of objects with simple repeated elements that would use a large amount of memory if individually stored. It is common to hold shared data in external data structures and pass it to the objects temporarily when they are used.

A classic example are the data structures used representing characters in a word processor. Naively, each character in a document might have a glyph object containing its font outline, font metrics, and other formatting data. However, this would use hundreds or thousands of bytes of memory for each character. Instead, each character can have a reference to a glyph object shared by every instance of the same character in the document. This way, only the position of each character needs to be stored internally.

As a result, flyweight objects can:
- store intrinsic state that is invariant, context-independent and shareable (for example, the code of character 'A' in a given character set)
- provide an interface for passing in extrinsic state that is variant, context-dependent and can't be shared (for example, the position of character 'A' in a text document)

Clients can reuse Flyweight objects and pass in extrinsic state as necessary, reducing the number of physically created objects.

#### Proxy
 A _proxy_, in its most general form, is a class functioning as an interface to something else. The proxy could interface to anything: a network connection, a large object in memory, a file, or some other resource that is expensive or impossible to duplicate. In short, a proxy is a wrapper or agent object that is being called by the client to access the real serving object behind the scenes. Use of the proxy can simply be forwarding to the real object, or can provide additional logic. In the proxy, extra functionality can be provided, for example caching when operations on the real object are resource intensive, or checking preconditions before operations on the real object are invoked. For the client, usage of a proxy object is similar to using the real object, because both implement the same interface.
 
### Behavioural patterns
#### Chain of Responsibility
the **chain-of-responsibility pattern** is a behavioural design patterns consisting of a source of [[GoF#command]] objects and a series of **processing objects**. Each processing object contains logic that defines the types of command objects that it can handle; the rest are passed to the next processing object in the chain. A mechanism also exists for adding new processing objects to the end of this chain.

In a variation of the standard chain-of-responsibility model, some handlers may act as dispatchers, capable of sending commands out in a variety of directions, forming a _tree of responsibility_. In some cases, this can occur recursively, with processing objects calling higher-up processing objects with commands that attempt to solve some smaller part of the problem; in this case recursion continues until the command is processed, or the entire tree has been explored. An [[XML]] [[GoF#Interpreter]] might work in this manner.

This pattern promotes the idea of [loose coupling](https://en.wikipedia.org/wiki/Loose_coupling "Loose coupling").

The chain-of-responsibility pattern is structurally nearly identical to the [[GoF#Decorator]] pattern, the difference being that for the decorator, all classes handle the request, while for the chain of responsibility, exactly one of the classes in the chain handles the request. This is a strict definition of the Responsibility concept in the [[GoF]]) book. However, many implementations (such as loggers, or UI event handling, or servlet filters in [[Java]], etc) allow several elements in the chain to take responsibility.

#### Command
The **command pattern** is a behavioral design pattern in which an object is used to encapsulate all information needed to perform an action or trigger an event at a later time. This information includes the method name, the object that owns the method and values for the method parameters.

Four terms always associated with the command pattern are _command_, _receiver_, _invoker_ and _client_. A _command_ object knows about _receiver_ and invokes a method of the receiver. Values for parameters of the receiver method are stored in the command. The receiver object to execute these methods is also stored in the command object by aggregation. The _receiver_ then does the work when the `execute()` method in _command_ is called. An _invoker_ object knows how to execute a command, and optionally does bookkeeping about the command execution. The invoker does not know anything about a concrete command, it knows only about the command _interface_. Invoker object(s), command objects and receiver objects are held by a _client_ object, the _client_ decides which receiver objects it assigns to the command objects, and which commands it assigns to the invoker. The client decides which commands to execute at which points. To execute a command, it passes the command object to the invoker object.

Using command objects makes it easier to construct general components that need to delegate, sequence or execute method calls at a time of their choosing without the need to know the class of the method or the method parameters. Using an invoker object allows bookkeeping about command executions to be conveniently performed, as well as implementing different modes for commands, which are managed by the invoker object, without the need for the client to be aware of the existence of bookkeeping or modes.

The central ideas of this design pattern closely mirror the semantics of first-class functions and higher-order functions in functional programming languages. Specifically, the invoker object is a higher-order function of which the command object is a first-class argument.

#### Interpreter
The **interpreter pattern** is a design pattern that specifies how to evaluate sentences in a language. The basic idea is to have a class for each symbol (terminal or nonterminal) in a specialized computer language. The syntax tree of a sentence in the language is an instance of the [[GoF#Composite]] pattern and is used to evaluate (interpret) the sentence for a client.

#### Iterator
The **iterator pattern** is a design pattern in which an iterator is used to traverse a container and access the container's elements. The iterator pattern decouples algorithms from containers; in some cases, algorithms are necessarily container-specific and thus cannot be decoupled.

For example, the hypothetical algorithm _SearchForElement_ can be implemented generally using a specified type of iterator rather than implementing it as a container-specific algorithm. This allows _SearchForElement_ to be used on any container that supports the required type of iterator.

#### Mediator
The **mediator pattern** defines an object that encapsulates how a set of objects interact. This pattern is considered to be a behavioral pattern due to the way it can alter the program's running behavior.

In [[OOP|OOP (Object-Oriented Programming)]], programs often consist of many classes. Business logic and computation are distributed among these classes. However, as more classes are added to a program, especially during maintenance and/or refactoring, the problem of communication between these classes may become more complex. This makes the program harder to read and maintain. Furthermore, it can become difficult to change the program, since any change may affect code in several other classes.

With the **mediator pattern**, communication between objects is encapsulated within a **mediator** object. Objects no longer communicate directly with each other, but instead communicate through the mediator. This reduces the dependencies between communicating objects, thereby reducing coupling.

#### Memento
The memento pattern is implemented with three objects: the _originator_, a _caretaker_ and a _memento_. The originator is some object that has an internal state. The caretaker is going to do something to the originator, but wants to be able to undo the change. The caretaker first asks the originator for a memento object. Then it does whatever operation (or sequence of operations) it was going to do. To roll back to the state before the operations, it returns the memento object to the originator. The memento object itself is an opaque object (one which the caretaker cannot, or should not, change). When using this pattern, care should be taken if the originator may change other objects or resources—the memento pattern operates on a single object.

Classic examples of the memento pattern include a pseudorandom number generator (each consumer of the PRNG serves as a caretaker who can initialize the PRNG (the originator) with the same seed (the memento) to produce an identical sequence of pseudorandom numbers) and the state in a finite state machine.

#### Observer
The **observer pattern** is a software design pattern in which an object, named the **subject**, maintains a list of its dependents, called **observers**, and notifies them automatically of any state changes, usually by calling one of their methods.

It is mainly used for implementing distributed event handling systems, in "event driven" software. In those systems, the subject is usually named a "stream of events" or "stream source of events", while the observers are called "sinks of events". The stream nomenclature alludes to a physical setup where the observers are physically separated and have no control over the emitted events from the subject/stream-source. This pattern then perfectly suits any process where data arrives from some input that is not available to the CPU at startup, but instead arrives "at random" (HTTP requests, GPIO data, user input from keyboard/mouse/..., distributed databases and blockchains, ...). Most modern programming-languages comprise built-in "event" constructs implementing the observer-pattern components. While not mandatory, most 'observers' implementations would use background threads listening for subject-events and other support mechanisms provided by the kernel (Linux [epoll](https://en.wikipedia.org/wiki/Epoll "Epoll"), ...).

#### State
The **state pattern** is a behavioral software design pattern that allows an object to alter its behavior when its internal state changes. This pattern is close to the concept of finite-state machines. The state pattern can be interpreted as a strategy pattern, which is able to switch a strategy through invocations of methods defined in the pattern's interface.

The state pattern is used in computer programming to encapsulate varying behavior for the same object, based on its internal state. This can be a cleaner way for an object to change its behavior at runtime without resorting to conditional statements and thus improve maintainability.

#### Strategy
In computer programming, the **strategy pattern** (also known as the **policy pattern**) is a behavioral software design pattern that enables selecting an algorithm at runtime. Instead of implementing a single algorithm directly, code receives run-time instructions as to which in a family of algorithms to use.

Strategy lets the algorithm vary independently from clients that use it. Deferring the decision about which algorithm to use until runtime allows the calling code to be more flexible and reusable.

#### Template Method
This pattern has two main parts:
- The "template method" is implemented as a method in a base class (usually an abstract class). This method contains code for the parts of the overall algorithm that are invariant. The template ensures that the overarching algorithm is always followed. In the template method, portions of the algorithm that may *vary* are implemented by sending self messages that request the execution of additional *helper* methods. In the base class, these helper methods are given a default implementation, or none at all (that is, they may be abstract methods). 
- Subclasses of the base class "fill in" the empty or "variant" parts of the "template" with specific algorithms that vary from one subclass to another. It is important that subclasses do not override the *template method* itself.

At run-time, the algorithm represented by the template method is executed by sending the template message to an instance of one of the concrete subclasses. Through inheritance, the template method in the base class starts to execute. When the template method sends a message to self requesting one of the helper methods, the message will be received by the concrete sub-instance. If the helper method has been overridden, the overriding implementation in the sub-instance will execute; if it has not been overridden, the inherited implementation in the base class will execute. This mechanism ensures that the overall algorithm follows the same steps every time, while allowing the details of some steps to depend on which instance received the original request to execute the algorithm.

This pattern is an example of inversion of control because the high-level code no longer determines what algorithms to run; a lower-level algorithm is instead selected at run-time.

Some of the self messages sent by the template method may be to *hook methods*. These methods are implemented in the same base class as the template method, but with empty bodies (i.e., they do nothing). Hook methods exist so that subclasses can override them, and can thus fine-tune the action of the algorithm without the need to override the template method itself. In other words, they provide a "hook" on which to "hang" variant implementations.

#### Visitor
In object-oriented programming and software engineering, the **visitor design pattern** is a way of separating an algorithm from an object structure on which it operates. A practical result of this separation is the ability to add new operations to existing object structures without modifying the structures. It is one way to follow the open/closed principle.

In essence, the visitor allows adding new virtual functions to a family of classes, without modifying the classes. Instead, a visitor class is created that implements all of the appropriate specializations of the virtual function. The visitor takes the instance reference as input, and implements the goal through double dispatch.
