---
tags: Techniek
---
# Polymorphism
In general, **polymorphism** means that something (an object or another entity) has many forms. 

- **Ad-hoc polymorphism** refers to functions that can take arguments of varying types, but behave differently depending on the types of arguments applied. 
	- See also: [[Java#Overloading]].
- **Subtype polymorphism** (also known as **subtyping**) is the ability to use an instance of a subclass when an instance of the base class is permitted. 
	- See also: [[Java#Overriding]].
- **Parametric polymorphism** is when code is written without mention of any specific type and thus can be used transparently with any number of new types. 
	- See also: [[Java#Generic type]].

## Runtime polymorphic behaviour
Method overriding is when a subclass redefines a method of the superclass with the same signature. 

- A reference variable of the superclass can refer to any subtype object
- A superclass method can be overridden in a subclass

When an overridden method is called through the reference variable of a superclass, [[Java]] determines at runtime which version of the method (superclass/subclasses) should be executed. This is known as **dynamic method dispatching**. 