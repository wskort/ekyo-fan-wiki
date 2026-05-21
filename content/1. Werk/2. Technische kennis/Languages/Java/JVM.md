---
aliases:
  - JVM (Java Virtual Machine)
tags: Techniek
---
# [[Java]] [[VM]]
The **Java Virtual Machine** is an application that represents a virtual computer according to the JVM specification document. It executes the compiled Java bytecode and translates it into low-level commands, which the computer understands. Each platform has its own version of the JVM, but since all JVMs match the same specification, your program will behave identically on different devices.

One of the main concepts of the Java Platform is "write once, run anywhere". It means that a program can run on various devices as long as they have a JVM installed. This concept is also frequently called **platform independence** or portability.

It's important to remember: the code input into the JVM is platform-independent, while the output code is platform-dependent.

![[JVM.png]]

The Java Platform allows using more than one programming language to create programs. This is achieved by the design of the JVM: it doesn't know anything about any particular programming language. It only understands Java bytecode. If the tools for a programming language can generate bytecode, programs written in this language can be executed on the JVM. Such languages are often called **JVM languages**. They include Java itself, Kotlin, Scala, Groovy, Clojure, and others. So, to create programs in the world of Java, you can choose the most convenient language of your choice. 

Nowadays, you can find tools to generate Java bytecode for almost any programming language, which means that there's hardly any language that is not a JVM language. 

![[JVM 1.png]]

## Call stack
JVM uses a **call stack** (or **execution stack**) to understand which method should be invoked next and to access information regarding the method. The call stack is composed of **stack frames** that store information about methods that have not yet terminated. The information includes the address of a method, parameters, local variables, intermediate computations, and some other data. 
See [[ADT#Stack]]. 

|             |                   |
| ----------- | ----------------- |
|             | method local vars |
| stack frame | method name       |
|             | method params     |

As a regular stack, the call stack follows the rule [[LIFO|LIFO (Last-In-First-Out)]], so stack frames are pushed at the top and move everything down. A new stack frame is added when the execution enters the method, and the stack frame is removed from the call stack if the execution of a method is done. 

```java
public class Main {  
	public static void main(String[] args) {  
		int n = 99;  
		printNextEvenNumber(n);  
	}  
	
	public static void printNextEvenNumber(int n) {
		int next = (n % 2 == 0) ? n + 2 : n + 1;  
		System.out.println(next);  
	}  
}
```

|               |                     |        |
| ------------- | ------------------- | ------ |
| stack frame 2 | next                | vars   |
| stack frame 2 | printNextEvenNumber | name   |
| stack frame 2 | n                   | params |
|               |                     |        |
| stack frame 1 | n                   | vars   |
| stack frame 1 | main                | name   |
| stack frame 1 | args                | params |

Essentially, this means that a method cannot be completed until all methods called by (methods called by)* this method have been completed. Execution stops when all methods have been completed, with the main method being the last one to finish.

### Stack overflow
The number of possible method invocations depends on the amount of memory allocated to the stack. When your stack contains too many stack frames, it can be overflowed. This leads to the `StackOverflowError` which stops execution. You can set the stack size in the command line with `-Xss` but this is **advanced material**. Also, sometimes when you get this error, it's actually a recursion issue and no amount of stack size is going to help you.

```bash
java YourProgramName -Xss256k
```