---
aliases: [ADT (Abstract Data Type)]
tags: Techniek
---
# Abstract Data Type (ADT)
This term is sometimes used as a synonym for [[Data Structure]], though this is not entirely correct. In general, an [[ADT|ADT (Abstract Data Type)]] is a mathematical concept, a simpler and more abstract way to view the data structure as a whole. It is a data type that is defined by a set of values and a set of possible external operations (behavior) from the user's point of view.

* **Abstraction** — a concept in object-oriented programming; it "shows" only essential attributes and "hides" unnecessary information, a.k.a. abstract classes or interfaces.
-   **Encapsulation** — a method of making a complex system easier to handle for end users. The user needn't worry about the internal details and complexities of the system. Encapsulation is the process of wrapping the data and the code that operates on that data into a single entity.

Some common [[ADT]]s are stack, queue, and so on. As a rule, modern programming languages like [[Java]], [[Python]] and [[C++]] provide these [[ADT]]s in standard libraries. 

A [[Data Structure]] (or [[Data Structure|CDT (Concrete Data Type)]]) is an exact representation of data as seen by the implementer, while an [[ADT]] views it as a user. You know what you can put in, and roughly know what to expect to get out, but you don't know (or really care) about the internal structure, and elements and procedures may be hidden from you. It's a black box. 

`java.util.Map` plays the role of an [[ADT]], whereas `HashMap` or `LinkedHashMap` can be interpreted as [[Data Structure]]s. 

In some sense, an [[ADT]] defines the logical form of the data type, while a [[Data Structure]] implements the physical form of it. 

## Stack
In this abstract data type, elements are inserted and removed according to the [[LIFO|LIFO (Last-In-First-Out)]] principle. The `push` operation inserts an item at the top of the stack, the `pop` operation removes the top item from the stack. Access to arbitrary elements is restricted. As a rule, a stack also supports the `peek` operation that just returns the current top element. In some cases, it may also be useful to check whether the stack is empty or what is its size, so these operations should also be supported.

The underlying [[Data Structure]] to implement a stack can be an array or a linked list with restricted access to its elements. 

In programming, stacks are used to:
- Evaluate arithmetic expressions
- Store arguments of functions and results of the functions' calls
- Reverse the order of elements

Operations on a stack do not gain complexity with stack size, so it is a very fast data type to process.