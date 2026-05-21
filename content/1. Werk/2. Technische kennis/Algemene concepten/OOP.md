---
aliases:
  - OOP (Object-Oriented Programming)
tags: Techniek
---
# Object-Oriented Programming (OOP)
There are four basic principles of [[OOP]]. They are **encapsulation**, **abstraction**, **inheritence**, and **polymorphism**. 

* **Encapsulation** ensures bundling (=encapsulating) of data and the methods operating on that data into a single unit. It also refers to the ability of an object to hide the internal structure of its properties and methods.
* **Data abstraction** means that objects should provide the simplified, abstract version of their implementations. The details of their internal work usually aren't necessary for the user, so there's no need to represent them. Abstraction also means that only the most relevant features of the object will be presented.
* **Inheritance** is a mechanism for defining parent-child relationships between classes. Often objects are very similar, so inheritance allows programmers to reuse common logic and at the same time introduce unique concepts into the classes.
* **Polymorphism** literally means "having many forms" and is a concept related to inheritance. It allows programmers to define different implementations for the same method. Thus, the name (or interface) remains the same, but the actions performed may differ. For example, imagine a website that posts three main types of text: news, announcements, and articles. They are somewhat similar in that they all have a headline, some text, and a date. In other ways, they are different: articles have authors, news bulletins have sources, and announcements have a date after which they become irrelevant. It is convenient to write an abstract class with general information for all publications to avoid copying it every time and store what is different in the appropriate derived classes.

Attributes characterize the states or data of an object, and methods characterize its behaviour. Sometimes we see objects without a state or methods. For instance, there is such a thing as an interface, which is a type of class that serves only to be inherited from in order to guarantee an interface to its descendant classes. It has methods but no state. 

## Type vs token
A class describes a common structure of similar objects: their fields and methods. An object is an individual instance of a class. 