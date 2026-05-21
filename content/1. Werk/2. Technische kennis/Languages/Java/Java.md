---
aliases:
  - Oracle Java
tags: Techniek
---
# Java
Java is an object-oriented ([[OOP]]) programming language. 

**TODO**
- Check out javadoc formatting/conventions. <3
- Check out Java Swing to create window-based GUI! <3

## Packages
Large projects can have a lot of classes, so **packages** let you group them together. They can also be nested, which helps to avoid conflicting class names. 

If two classes are in the same package, using one class inside the other is no problem. If they are in different packages, you'll need to write an `import` statement. You can even add `.*` behind the class name in the import to import all static members (methods and fields) and use them without referring to their parent class. 

If you do not declare a package, the class will be placed in the **default package**. Classes placed in default cannot be imported to classes inside named packages. As such, it is highly discouraged.

## Classes
A class body can include **fields**, [[Java#Methods]] and [[Java#Constructors]]. 

```java
class Patient {
	String name;
	int age;
	float height;
	String[] complaints;
}
```

A **field** is a variable that stores data, and can have any type. A class can have as many fields as you need. 

### Class inheritence
**Inheritence** is a mechanism for deriving a new class from another class (base class). The new class acquires some fields and methods of the base class. 

A class **derived** from another class is called a **subclass** (it's also known as a **derived class**, **extended class** or **child class**). The class from which the subclass is derived is called a **superclass** (also a **base class** or a **parent class**). 

```java
class SuperClass { }

class SubClassA extends SuperClass { } 

class SubClassB extends SuperClass { }

class SubClassC extends SubClassA { }
```

* A class can only inherit from a single superclass.
* A class hierarchy can have multiple levels (class `C` can extend class `B` that extends class `A`)
* A superclass can have more than one subclass.

A subclass inherits all `public` and `protected` fields and methods from the superclass. It can also add new fields and methods. The inherited and added members will be used the same way. 

A subclass doesn't inherit `private` fields and methods from the superclass. However, if the superclass has public or protected methods for accessing its private fields, these members can be used inside subclasses. 

Constructors are not inherited, but the superclass' constructor can be invoked from the subclass using the special keyword `super`. 

If you'd like the base class members to be accessible from all subclasses but not from the outside code (excluding the same package), use the access modifier `protected`. 

**Inheritence** represents the **IS-A** relationship. A base class represents the general and a subclass represents the particular or specific. 

A class with the keyword `final` cannot have subclasses at all. Some standard classes are declared as final: `Integer`, `Long`, `String`, `Math`. They cannot be extended.

If class A is a superclass of B and class B is a superclass of class C then a variable of class A can reference any object derived from that class (for instance, objects of the class B and the class C). This is possible because each subclass object is an object of its superclass but not vice versa.

```java
class Person { }
class Client extends Person { }
class Employee extends Person { }

Person client = new Client(); // the reference is Person, the object is Client  
Person employee = new Employee(); // the reference is Person, the object is Employee

Client whoIsIt = new Employee(); // it's impossible

Client client = new Person(); // it's impossible too

```

But when you have a superclass object like this, you cannot access specific members of the subclass through the base class reference. Those do not exist at the superclass level. 

You can always cast an object of a subclass to its superclass. It may also be possible to cast an object from a superclass to a subclass, but *only* if the object is an instance of this subclass, otherwise a `ClassCastException` will be thrown. 

#### Keyword super
You can use the keyword `super` to access instance fields, methods or constructors of the superclass. This keyword is optional if members of the superclass and subclass have different names, but is necessary to access hidden (with the same name) members of the base class.

Constructors are not inherited by subclasses, but a superclass constructor can be invoked from a subclass using the keyword `super()`, which can include arguments. 
* Invoking `super(...)` must be the first statement in a subclass constructor, otherwise the code will not compile.
* The default constructor of a subclass automatically calls the no-argument constructor of the superclass.

```java
class Person {  
  
 protected String name;  
 protected int yearOfBirth;  
 protected String address;  
  
 public Person(String name, int yearOfBirth, String address) {  
 this.name = name;  
 this.yearOfBirth = yearOfBirth;  
 this.address = address;  
 }  
  
 // getters and setters  
}  
  
class Employee extends Person {  
  
 protected Date startDate;  
 protected Long salary;  
  
 public Employee(String name, int yearOfBirth, String address, Date startDate, Long salary) {  
 super(name, yearOfBirth, address); // invoking a constructor of the superclass  
   
 this.startDate = startDate;  
 this.salary = salary;  
 }  
  
 // getters and setters  
}
```

#### Overriding
Overriding is a **dynamic (run-time)** type of [[Polymorphism]].

You can declare a method in a subclass with the same name as a method in the superclass, so you can give a specific implementation of a superclass method. The annotation `@Override` is optional but encouraged. You can also invoke the base class method within the overridden method using the keyword `super`. 

Some rules:
- The method must have the same name as in the superclass
- The arguments should be exactly the same as in the superclass method
- The return type should be the same type or a subtype of the return type declared in the method of the superclass
	- When the overriding subclass returns a subtype of the superclass method's return type, this is called a **covariant return type**. This is only possible for non-primitive return types.
- The access level must be the same as or more open than the overridden method's access level
- A `private` method cannot be overridden, because it isn't inherited by subclasses
- If the superclass and its subclass are in the same package, then `package-private` methods can be overridden
- `static` methods *cannot* be overridden
	- If a subclass has a static method with the same signature (name & parameters) as a static method in the superclass, then the method in the subclass hides the one in the superclass. You will get a compile-time error if you do this unless you change the signature.

The annotation `@Override` tells the compiler that this should be an overriding method. It will then generate an error if overriding is not possible. 

If you want to forbid overriding of a method, declare it with the keyword `final`. Overriding this method in a subclass will now generate a compile-time error.

Note: Overriding can coexist with [[Java#Overloading]]. 

### Methods
A method contains a **set of modifiers**, a **type of the return value**, a **name**, a list of **parameters** in parentheses `()`, and a **body** in curly brackets `{}`. The combination of the name of the method and the list of its parameters is known as a method **signature**. 

When you pass values into a method, the method uses a local copy of those values. The original values are not change unless you specifically target them *instead* of the local values. 

#### Main method
```java
public class Main {
	
	public static void main(String[] args) {
		System.out.println("Hello, world");
	}
}
```

The class can have any name (matching the file name), but you *need* a `main` method with that exact name. 
* the keyword `public` indicates that the method can be invoked from everywhere;
* the keyword `static` indicates the method can be invoked without creating an instance of the class;
* the keyword `void` indicates the method doesn't return any value;
* the array variable `args` contains arguments entered at the command line, the array is empty if there are no arguments. 

Some troubleshooting:
* The program cannot be compiled if the main method decloration breaks the syntax of Java. 
* The program can be compiled but not run if the main method has a correct declaration as a *regular* method but doesn't satisfy the specific requirements of the *main* method. 

#### Modifiers
There are two types of modifiers in Java
* [[Java#Access modifiers]] define the visibility of the method.
* **Non-access modifiers** provide information about the behaviour of methods to [[JVM]]. 
	* `static` means that the method belongs to the class and can be accessed without creating any object/instance. 
	* If a method is declared without the `static` modifier, it can only be invoked through an object or instance of this class.

##### Access modifiers
* `public` available to anyone
* `package-private` default; no explicit modifier; visible only for classes from the same package
* `protected` visible to package + own subclasses
* `private` visible to self only

![[Java 1.png]]

| Modifier  | Class | Package | Subclass | Global |
| --------- | ----- | ------- | -------- | ------ |
| Public    | Yes   | Yes     | Yes      | Yes    |
| Protected | Yes   | Yes     | Yes      | No     |
| Default   | Yes   | Yes     | No       | No     |
| Private   | Yess  | No      | No       | No     |

#### Parameters
Each parameter has a type and a (local) name. The types, sequence and amount of parameters are all part of the unique signature of the method. *Non-parameterized* methods don't have any values passed to them. 

##### Variable-length arguments (varargs)
You can pass an arbitrary number of the same type of arguments to a method, which will then be processed as an array.  
```java
public static void printNumberOfArguments(int... numbers) {
	System.out.println(numbers.length);
}
```

You can pass any amount of arguments into this method, or a matching array.

```java
printNumberOfArguments(1);						// 1
printNumberOfArguments(1, 2);					// 2
printNumberOfArguments(1, 2, 3);				// 3
printNumberOfArguments(new int[] { });			// 0
printNumberOfArguments(new int[] { 1, 2 });		// 2
```

This way a *single* parameter can be used to process *multiple* arguments.

Note: If a method has more than one parameter, then the `vararg` parameter  *must* be the last one.

#### Return 
A method can return any specific type or no type at all (`void`). Specify in the body of the method what should be returned and when. 
```java
return 5;
return "success";
return true;
return;
```

#### Getters & Setters
According to the **data encapsulation** principle, the fields of a class are hidden (`private`) and can only be accessed through the methods of that particular class.
```java
private String name;
private boolean flag;

public String getName() {
	return name;
}

public void setName(String name) {
	this.name = name;
}

public boolean isFlag() {
	return flag;
}

public void setFlag(boolean flag) {
	this.flag = flag;
}
```

Getters and setters can contain more sophisticated logic, and can also be used to provide conditional access.

#### Overloading
Overloading is a **static (compile-time)** type of [[Polymorphism]]. 

If methods have the same name, but different number and/or type of parameters, they are **overloaded**. It means you can invoke different methods by the same name by passing different arguments. They do not need to have the same return type. You cannot have fully duplicate method names + parameters (return type doesn't count!). Also, note that when parameters have different types, changing their order is a valid case of overloading, so `method(int i, String s)` is not the same as `method(String s, int i)`.

A class constructor can also be overloaded, which is nifty. You can also invoke one constructor from inside another one, which allows you to initialize one part of an object by one constructor and another part by another constructor. 

```java
this();			// calls a no-argument constructor
this("arg1")	// calls a constructor with 1 string argument
```

### Objects
When you create an **instance** of a class, you're creating a new object. 

```java
Patient patient1 = new Patient();
```

You can then access the fields of that particular object.

```java
System.out.println(patient1.name);
System.out.println(patient1.age);
```

Different objects of the same class can have different values for their fields. 

#### The 'Object' class
The default parent of all standard classes and all custom classes is the `Object` class from the [[JSL|JSL (Java Standard Library)]]. Every class extends this one implicitly, therefore it's a root of inheritence in Java programs. The class belongs to the `java.lang` package that is imported by default. 

The `Object` class can refer to an instance of any class because any instance is a kind of `Object` (*upcasting*). 

##### Object methods
Instance methods:
* Threads synchronization (for working in multithreaded applications)
	* `wait`
	* `notify`
	* `notifyAll`
* Object identity
	* `hashCode` returns a hash code value for the object
	* `equals` indicates whether some other object is **"equal to"** this particular one
* Object management
	* `finalize` is deprecated as of JDK 9.
	* `clone` creates and returns a copy of the object.
	* `getClass` returns an instance of `Class`, which has information about the runtime class
* Human-readable representation
	* `toString` returns a string representation of the object

#### Constructors
Consturctors are special methods that initialize a **new object** of the class. It is invoked when an instance is created using the keyword `new`. 

Constructor methods differ from other methods in that:
* It has the same name as the class that contains it
* It has no return type (not even `void`)

```java
class Patient {
	
	String name;
	int age;
	float height;
	
	public Patient(String name, int age, float height) {
		this.name = name;
		this.age = age;
		this.height = height;
	}
}
```

Now when we initialize an instance, we can immediately pass field values into it. The keyword `this` refers to the current instance of the class it's in. 

By default, the compiler provides a default no-argument constructor *if no constructor is defined*, through which  no arguments are processed and all fields are filled with the default values of their types. 

#### Instance methods
Non-static  methods require an instance (object) to work, so that they can access the field values of the class. You can optionally use the `this` keyword to make it explicit that you're using fields from the current object. 

### Enums
An enum is an *enumeration* of a finite set of options that a variable can take. 
```java
public enum UserStatus {
	PENDING, ACTIVE, BLOCKED		// three instances
}
```

You can declare an enum inside or outside of a class. When declared inside, you don't need the `public` keyword to access it from that class. 

In general, an enum can be considered a class with predefined instances. Here, we have three instances of user statuses `PENDING`, `ACTIVE` and `BLOCKED` inside the storage `UserStatus`. If we want to extend the list of constants, we can just add another instance in the enum. 

```java
UserStatus active = UserStatus.ACTIVE;
UserStatus blocked = UserStatus.valueOf("BLOCKED");
```

Here a variable of the type `UserStatus` is initialized in two different ways. Note that this is case sensitive. 

* `.name()` access the name of an enum. 
* `.values()` get an array of all constants of an enumeration
* `.ordinal()` get the ordinal position of an instance of an enum (how manieth option, counting from 0).
* `.equals()` and `==` can be used normally, despite enum variables being reference types.  

You can use an enum as the pivot variable for a [[Java#Switch]] statement. You can also use a [[Java#For-each loop]] to iterate over each instance. 

```java
for (UserStatus status : UserStatus.values()) {
	System.out.println(status);
}
```

#### Enum fields & methods
An enum is a type of class, and as such it can have fields and methods just like a class. It can also have a constructor. 

```java
public enum ChargeLevel {
	
	// Constants:
	FULL(4, "green"),
	HIGH(3, "green"),
	MEDIUM(2, "yellow"),
	LOW(1, "red");
	
	// Fields:
	int sections;
	String color;
	
	// Constructor:
	ChargeLevel(int sections, String color) {
		this.sections = sections;
		this.color = color;
	}
	
	// Other methods:
	public int getSections() {
		return sections;
	}
	
	public String getColor() {
		return color;
	}
	
	public static ChargeLevel findByNumberOfSections(int sections) {
		for (Chargelevel value : values()) {
			if (value.sections == sections) {
				return value;
			}
		}
		return null;
	}
}
```

Note that all enum instances are created by the JVM in the same way as a static field of a class. This is the reason why an enum *cannot* contain a public constructor. This means that we *cannot* create enum objects by invoking an enum constructor with the `new` keyword but have to choose one of the predefined instances instead. Keep in mind that if your enum contains fields and methods, you should always define them *after* the list of constants in the enum. 

Also note that we extended the enum with a custom static method that finds a `ChargeLevel` instance by the given number of sections.

```java
System.out.println(ChargeLevel.findByNumberOfSections(2)); // MEDIUM
```

### Interfaces
Unlike with [[Java#Class inheritence]], a class can implement multiple interfaces. An interface can also extend one or more other interfaces using the keyword `extends`. Finally, a class can extend another class *and* implement multiple interfaces.

An interface can contain:
* `public` constants 
* abstract methods without an implementation (the keyword `abstract` is not required here)
* `default` methods with implementation (the keyword `default` is required)
* `static` methods with implementation (the keyword `static` is required)
* `private` methods with implementation

An interface can *not* contain:
* fields (only **constants**)
* constructors
* non-public abstract methods

```java
interface DrawingTool {
	void draw (Curve curve);
}
```

The interface `DrawingTool` declares the `draw` method without implementation. 

```java
class Pencil implements DrawingTool {
	...
	public void draw(Curve curve) {...}
}

class Brush implements DrawingTool {
	...
	public void draw(Curve curve) {...}
}
```

Any class that implements an interface, has to implement all declared methods. Now just by looking at the class declaration, you can tell that this class is able to draw. I.E., the main idea of an interface is *declaring functionality*. 

In addition, you can use interfaces as types. 

```java
DrawingTool pencil = new Pencil();
DrawingTool brush = new Brush();
```

This is another way of supporting **polymorphism**, which helps to design reusable functions. 

```java
void drawCurve(DrawingTool tool, Curve curve) {
	System.out.println("Drawing a curve " + curve + " using a " + tool);
	tool.draw(curve);
}
```

#### Marker interfaces
In some situations, an interface can have no members at all. Such interfaces are called **marker** or **tagged interfaces**. Some examples are `Serializable`, `Cloneable` and `Remote`. They are used to provide essential information to the [[JVM]]. 

#### Static interface methods
You can declare and implement a static method in an interface, which can be invoked directly from an interface. This is mostly used for utility functionality that is common for all classes implementing the interface. They help to avoid code duplication an creating additional utility classes.

#### Comparable interface
The `Comparable` interface provides the `compareTo()` method which allows comparing an object with other objects of the same type. It's also important to comply with the conditions: all objects can be compared to other objects of the same type in the most widely used way, which means `compareTo()` should be consistent with the `equals` method. A sequence of data has the **natural ordering**, if for each 2 elements `a` and `b`, where `a` is located to the left of `b`, the condition is true: `a.compareTo(b) <= 0`.

The classes `Integer` and `String` already implement the `Comparable` interface, but for custom classes we'd need to implement a custom method to compare them by one or more fields. 

The method `.compareTo()` is a prerequisite for the method `.sort()`. 

For example, this is how the `compareTo()` method is implemented in the `Integer` class:

```java
@Override  
public int compareTo(Integer anotherInteger) {  
 return compare(this.value, anotherInteger.value);  
}  
  
public static int compare (int x, int y) {  
 return (x < y) ? -1 : ((x == y) ? 0 : 1);  
}
```

* `compareTo()` is negative if the current object is less than the parameter object
* `compareTo()` is zero if they are equal
* `compareTo()` is positive if the current object is greater than the parameter object

Beware that when overriding the `compareTo()` method, that you may also need to override the method `equals()`, because `medium1.compareTo(medium2) == 0` should have the same boolean value as `medium2.equals(medium1)`

Another example: Sort the object `Cake` by its name.
```java
public class Cake implements Comparable<Cake> {
	private String name;
	private String description;
	private int weight;
	
	// constructor
	
	// getters and setters
	
	@Override
	public int compareTo(Cake otherCake) {
		return getName().compareTo(otherCake.getName());
	}
}
```

### Collections Framework
Collections are represented by different classes from the [[JSL|JSL (Java Standard Library)]]. All modern collections are **[[Java#Generic type]]s** while old collections are **non-generic**. As regular generics, modern collections can store any reference types including custom classes. Collections can be **mutable** and **immutable**. 

In addition to standard collections, there are external libraries with collections. 

The collections framework consists of classes and interfaces for commonly reusable data structures such as lists, dynamic arrays, sets, and so on. It has a unified architecture for representing and manipulating collections, enabling collections to be used independently of implementation details via its interfaces.

The framework includes:
* interfaces that represent different types of collections
* primary implementation of the interfaces
* legacy implementations from earlier releases ("old collections")
* special-purpose implementations (like immutable collections)
* algorithms represented by static methods that perform useful operations on collections. 

Here are basic interfaces from the collections framework in the `java.util` package.

There are two root generic interfaces `Collection<E>` and `Map<K,V>`, and some more specific interfaces to represent different types of collections. 
![[Java 2.png]]

#### The Collection interface
* `int size()` returns the number of elements in this collection
* `boolean isEmpty()` returns `true` if this collection contains no element
* `boolean contains(Object o)` returns `true` if this collection contains the specified element
	* Note: this method relies on the method `equals` of the elements. If you store non-standard classes in the collection, `equals` together with `hashCode` should be overridden. 
* `boolean add(E e)` adds an element to the collection. Returns `true` if the element was added, else returns `false`
* `boolean remove(Object o)` removes a single instance of the specified element 
	* Note: this method relies on the method `equals` of the elements. If you store non-standard classes in the collection, `equals` together with `hashCode` should be overridden. 
* `boolean removeAll(Collection<?> collection` removes elements from this collection that are also contained in the specified collection (Set theory: SetA - SetB) 
* `void clear()` removes all elements from this collection
* `Collections.sort(Collection c)` sorts the elements of the collection depending on the default sorting of the contained object type.
* `Collections.max(Collection c)` returns the maximum element in `c` as determined by natural ordering
* `Collections.min(Collection c)` returns the minimum element in `c` as determined by natural ordering

You could also iterate over all elements of *any* collection with a [[Java#For-each loop]], or use another style for iterations using the `.forEach(Consumer<T> consumer` method with method references or lambda expressions.

```java
for (String lang : languages) {
	System.out.println(lang);
}

languages.forEach(System.out::println); 				// with method reference  
languages.forEach(elem -> System.out.println(elem));	// with lambda expression
```

Both mutable and immutable collections implement the `Collection<E>` interface, but immutable collections will throw `UnsupportedOperationException` when trying to invoke methods to change them, like `add`, `remove` and `clear`.

##### List interface
* `Collections.reverse(List list)` reverses the sequence in list
* `Collections.shuffle(List list)` shuffles (i.e. randomizes order) the elements in list
* `get(index)` returns the value stored at that particular index (0+)

###### ArrayList
```java
import java.util.ArrayList;
```

The `ArrayList` class is a primary representation of the interface `List<E>`.  

It is a dynamic array, which means that it has a scaling max-capacity depending on the amount of elements. Operations:
* From `Objects` interface:
	* `equals()` returns `true` if two lists contain the same elements in the same order. The list's type does not matter. 
* From `Collection<E>` interface:
	* `int size()` return number of elements in the list
	* `add(Object o)` Add an element (at the end of the array)
	* `boolean contains(Object o)` returns whether an object is contained or not
	* `boolean isEmpty()` returns `true` if the collection contains no elements.
	* `remove(Object o)` Remove an element by value (delete & doorschuiven). It removes **the first occurrence** of that element.
	* `clear()` Clear (remove all) (or technically, set capacity to 0 so everything falls out). 
	* `removeAll(Collection<E> c)` can be used to remove **all occurences** of one or more elements
	* `addAll(Collection c)` add an entire collection to the list, appended at the end. 
* From `List<E>` interface:
	* `set(int index, Object o)` Update value at specified index
	* `get(int index)` Get element by index
	* `indexOf(Object o)` returns (first) index of an element (-1 if not found)
	* `lastIndexOf(Object o)` returns (last) index of an element (-1 if not found)
	* `List<E> subList(int fromIndex, int toIndex)` returns a sublist of this list from `fromIndex` included to `toIndex` exlcuded
	* `add (int index, Object o)` Add an element at the specified index (insert & doorschuiven)
	* `remove(int index)` Remove an element by index (delete & doorschuiven). 

```java
ArrayList<String> list = new ArrayList<>();

list.add("first");
list.add("second");
list.add("third");

System.out.println(list); 			// [first, second, third]

System.out.println(list.get(0));	// first
System.out.println(list.get(1));	// second
System.out.println(list.get(2));	// third

list.remove("first");

System.out.println(list);			// [second, third]

System.out.println(list.size());	// 2
```

Note that we need the `get(int index)` method because this is not a standard array. It also requires [[Java#Wrapper classes]] for [[Java#Primitive types]]. 

Also note that we do not get the `.get(i)` method from the `Collection<E>` interface. Instead, it comes from the `List<E>` interface.

Also note that we inherited `.toString` from the root `Object` that supercedes ALL classes. 

The default initial capacity of an ArrayList is 10, but you can also initialize it at a specific capacity, or initialize it with the contents of another list.
```java
ArrayList<String> list = new ArrayList<>(50);
ArrayList<String> list = new ArrayList<>(anotherList);
```

###### LinkedList
In addition to storing the object, the LinkedList stores the memory address (or link) of the following element. ArrayList is good at quickly storing and accessing data (by calling a specific index), whereas LinkedList is good at quickly manipulating data (such as inserting and deleting a lot). 

###### Immutable lists
```java
List<String> daysOfWeek = List.of(
	"Monday",
	"Tuesday",
	"Wednesday",
	"Thursday",
	"Friday", 
	"Saturday",
	"Sunday"
);
```

The simplest way to create an immutable list is with the `of` method of the `List` interface. If you try to change it, you'll get the error `UnsupportedOperationException`. 

###### Array.asList()
```java
import java.util.Arrays;
import java.util.ArrayList;

String[] array = "This is my array".split(" ");  
ArrayList<String> list = new ArrayList<>(Arrays.asList(array));  
list.set(3, "list");  
  
System.out.printf("{%s, %s, %s, %s}%n", 
				  array[0], array[1], array[2], array[3]); 		// {This, is, my, array}  
System.out.println(list); 										// [This, is, my, list]
```

##### Set interface
###### HashSet
Sets are collections that cannot contain duplicate elements. HashSet is one of the implementations of the Set interface.

###### LinkedHashSet
In addition to working like a HashSet, a LinkedHashSet maintains a linked list of the set's element in the order in which they were inserted. 

##### Map interface
###### HashMap
HashMap is used for storing data collections as key and value pairs. One object is used as a key (index) to another object (the value). 

```java
import java.util.HashMap;

public class MyClass {
	public static void main(String[] args) {
		HashMap<String, Integer> points = new HashMap<String, Integer>();
		
		points.put("Amy", 154);
		points.put("Dave", 42);
		points.put("Rob"), 733);
		
		System.out.println(points.get("Dave"));
	}
}
```

* `put(..., ...)` adds a key-value pair to the HashMap. If that key is already present, the old element is overwritten.
* `remove(..., ...)` removes a key-value pair to the HashMap.
* `get(...)` returns the value corresponding to the key value.
* `containsKey(...)` returns true if that key is in the HashMap.
* `containsValue(...)` returns true if that value is in the HashMap.

##### Iterator
An iterator is an object that enables to cycle through a collection, obtain or remove elements. Each of the collection classes provides an `iterator()` method that returns an iterator to the start of the collection. By using this iterator object, you can access each element in the collection, one element at a time.

* `boolean hasNext()` returns `true` if there is at least one more element
* `next()` returns the next object and advances the iterator
* `remove()` removes the last object that was returned by `next()` from the collection

```java
import java.util.Iterator;
import java.util.LinkedList;

public class MyClass {
	public static void main(String[] args) {
		LinkedList<String> animals = new LinkedList<String>();
		
		animals.add("fox");
		animals.add("cat");
		animals.add("dog");
		animals.add("rabbit");
		
		Iterator<String> it = animals.iterator(); 	// start at beginning
		String value = it.next(); 					// load 1st element
		System.out.println(value);					// print 1st element
		System.out.println(it.next());				// load next element and print it (=2nd)
	}
}
```

Typically, iterators are used in loops.

```java
import java.util.Iterator;
import java.util.LinkedList;

public class MyClass {
	public static void main(String[] args) {
		LinkedList<String> animals = new LinkedList<String>();
		
		animals.add("fox");
		animals.add("cat");
		animals.add("dog");
		animals.add("rabbit");
		
		Iterator<String> it = animals.iterator();
		while(it.hasNext()) {
			String value = it.next();
			System.out.println(value);
		}
	}
}
/* 
fox
cat
dog
rabbit
*/
```

#### Math
* `Math.min(..., ...)` returns the smaller value of two arguments
* `Math.max(..., ...)` returns the greater value of two arguments
* `Math.abs(...)` returns the absolute value of its argument
* `Math.floor(...)` returns the largest double value that is less than or equal to its argument and is equal to an integer. 
* `Math.ceil(...)` returns the smallest double value that is greater than or equal to its argument and is equal to an integer.
* `Math.sqrt(...)` returns the square root of its argument
* `Math.cbrt(...)` returns the cube root of its argument
* `Math.pow(..., ...)` returns the value of the first argument raised to the power of the second argument
* `Math.sin(...)` returns the trigonometric sine of the given angle in radians
* `Math.cos(...)` returns the trigonomic cosine of the given angle in radians
* `Math.toRadians(...)` converts an angle measured in degrees to an angle measured in radians (approximately).
* `Math.random()` returns a double value with a positive sign, greater than or equal to 0.0 and less than 1.0. 
* `Math.PI` is the ratio of the circumference of a circle to its diameter
* `Math.E` is the base of the natural logarithm.
* `Math.hypot(..., ...)` calculates the length of a hypotenuse (google it if you really care)

### Abstract class
An **abstract class** is declared with the keyword `abstract` and represents an abstract concept that is used as a base class for subclasses. 
- It is impossible to create an instance of an abstract class
- An abstract class can contain abstract methods that must be implemented in non-abstract subclasses
- It can contain fields and non-abstract methods (including static)
- An abstract class can extend another class, including abstract
- It can contain a constructor

#### Abstract method
An **abstract method** is declared with the keyword `abstract` and has a declaration (modifiers, return type, argument signature) but no implementation. Each concrete (non-abstract) subclass must implement these methods. 

Note that a `static` method cannot be `abstract`. 

### Initialization block
#### Static initialization block
A **static initialization block** is a block of code enclosed by braces `{}` and preceded by the `static` keyword: 

```java
static {
	// code
}
```

It's used to initialize **static fields** and **constants**, just like constructors help to initialize instance fields. We can create objects and invoke static methods in a static block. It is executed once for the whole class, not for each instance of the class.

#### Instance initialization block
You can initialize instance data members in an **instance initialization block**. It is run each time an object of the class is created, *before* the constructor is invoked (but *after* the superclass constructor is invoked). 

## Types
### Primitive vs Reference types
Java provides 8 primitive types; all other types are reference types. **Primitive types** are built-in keywords with lowercase names. 
1. `byte`
2. `short`
3. `int`
4. `long`
5. `float`
6. `double`
7. `char`
8. `boolean`

Everything else is a **reference type**. In most cases, instances of a **reference type** can be created using the `new` keyword. During this 'instantiation' memory is allocated for the created object. 

A variable of a **primitive type** stores the actual values, whereas a variable of a **reference type** stores an address in memory (reference) to the data. 

There are two main memory spaces: **stack** and **heap**. All values of **primitive types** are stored in **stack** memory, but variables of **reference types** store an **address in stack memory** to the **object in heap memory**. Note that when assiging the value of one variable to another variable, the stack memory value is copied. So for primitive types this is the actual value, whereas for reference types this is a secondary reference to the singular object. 

Note that [[Java#Relational operators]] compare the stack memory, so they cannot be used to (for instance) compare the contents of two String objects. The correct way to compare content is to invoke the special method `equals`. 

```java
String s1 = new String("java");
String s2 = new String("java"); 
String s3 = s2;

System.out.println(s1 == s2); // false; different String object.
System.out.println(s2 == s3); // true; same String object.

System.out.println(s1.equals(s2)); // true; same String content.
System.out.println(s2.equals(s3)); // true; same String content.
```

**Reference types** can refer to a special `null` value to represent that it is not yet initialized or doesn't have a value yet, but a **primitive type** cannot be `null` and wouldn't compile.

#### Primitive types

##### Numbers
###### Integer numbers
- `byte`: size 8 bits (1 byte), range from -128 to 127
- `short`: size 16 bits (2 bytes), range from -32768 to 32767
- `int`: size 32 bits (4 bytes), range from -(2^31) to (2^31)-1
- `long`: size 64 bits (8 bytes), range from -(2^63) to (2^63)-1
	- You can mark a number as `long` with an `L` like so: `20L`. 

###### Fractional numbers
- `float`: size 32 bits (4 bytes), up to 6-7 decimal digits
	- You can mark a number as `float` with an `f` like so: `20f`.
- `double`: size 64 bits (8 bytes), up to 14-16 decimal digits. 
	- You can mark a number as `double` with a `d` like so: `20d`. 

##### Characters
A single letter is stored in 16 bits (2 bytes). That's because it's in [[Unicode]] (UTF-16). That 16 means 16 bits. Mind. Blown.

##### Booleans
###### Logical operators
- `!` NOT
- `&&` AND
- `||` OR
- `^` XOR
These operators are processed in the following order: `!` --> `^` --> `&&` --> `||`.

###### Relational operators
- `==` equal to (evaluates to same *result*)
- `===` *exactly* equal to 
- `!=` not equal to
- `>` greater than
- `>=` greater than or equal to
- `<` less than
- `<=` less than or equal to
#### Reference types
##### Strings
In Java, strings are *technically* special objects made of an array of characters. That is why strings share attributes with arrays, such as that this is an immutable type and individual characters can be accessed by indexes. Because it is a class and not a strict data type, `String` is capitalised unlike other types such as `int` and `char`.  

###### String manipulation
- `String.valueOf()` convert non-String to String. 
	- `String text = String.valueOf(char[] array)`
		- reverse: `char[] array = text.toCharArray()`
- `.length()` returns the number of characters in the string
- `.charAt(int index)` returns a character by its index
- `.isEmpty()` returns `true` if the string is empty, otherwise – `false`
- `.toUpperCase()` returns a new string in uppercase
- `.toLowerCase()` returns a new string in lowercase
- `.startsWith(prefix)` returns `true` if the string starts with the given string prefix, otherwise, `false`
- `.endsWith(suffix)` returns `true` if the string ends with the given string suffix, otherwise, `false`
- `.contains(...)` returns `true` if the string contains the given string or character
- `.substring(beginIndex, endIndex)` returns a substring of the string in the range: `beginIndex`, `endIndex - 1`
- `.replace(old, new)` returns a new string obtained by replacing all occurrences of `old` with `new` that can be chars or strings
- `.trim()` returns a copy of the string obtained by omitting the leading and trailing whitespace. Note that whitespace includes not only the space character, but mostly everything that looks empty: tab, carriage return, newline character, etc.
- `text.concat(String postfix)` combines text+postfix to create a new String. 
- `+` another way to do concatenation. Note, this is sequential. `str1 + str2` != `str2 + str1`
- `.equals(other)` compares two strings (case sensitive)
- `.equalsIgnoreCase(other)` compares two strings (case insensitive)
- `.split(" ")` split the string into an array of strings, using the specified **separator** `" "` as cut-lines
	- `.split("")` cut into array of strings of 1-char length. 
- `String.format(String, arg...)` create *formatted* string.
	* `%c` char
	* `%s` String
	* `%d` int, short, byte, long
	* `%f` float, double
		* `%.2f` float with two decimal points. 
	* `%n` new-line
* `.formatted(args...)` alternative writing style of above.

```java
int age = 22;
String str1 = String.format("My age is %d", age);
System.out.println(str);
// My age is 22

char initial = 'M';  
String surname = "Anderson";  
double height = 1.72;  
  
String details = "My name is %c. %s.%nMy age is %d.%nMy height is %.2f."  
	.formatted(initial, surname, age, height);  
  
System.out.println(details);
/* My name is M. Anderson.
** My age is 22. 
** My height is 1.72. 		*/
```

###### Escape sequences
There are some special characters starting with backslash `\` which are known as the escape or control sequences. They do not have corresponding symbols and cannot be found on a keyboard. To represent such characters we use a pair of regular symbols. In a program, this pair will be considered as exactly one character with the appropriate code.

-   `\n` is the newline character;
-   `\t` is the tab character;
-   `\r` is the carriage return character;
-   `\\` is the backslash character itself;
-   `\'` is the single quote mark;
-   `\"` is the double quote mark.

###### Exceptions when processing strings
- `NullPointerException` happens when a string is `null` (empty). 
- `StringIndexOutOfBoundsException` happens when you try to access a non-existing character in a String. Note that `' '` (space) is an existing character.

###### Printing
* `System.out.print(String)` print (as) a String
* `System.out.println(String)` print (as) a String followed by new-line. 
* `System.out.printf(String, arg...)` print *formatted* string.
	* `%c` char
	* `%s` String
	* `%d` int, short, byte, long
	* `%f` double, float
		* `%.2f` float with two decimal points. 

```java
System.out.printf("My name is %s. I was born in %d.", "Mike", 1998)
```
You can use a variable as one of the arguments. 

##### StringBuilder
The class `StringBuilder` is a mutable alternative to the immutable `String` type. 
- `int length()` same as String
- `int capacity()` amount of storage available for newly inserted characters, beyond which an allocation will occur. Dynamic value.
- `char charAt(int index)` same as String
- `void setCharAt(int index, char ch)` replace single character at specified index
- `void deleteCharAt(int index)` remove single character at specified index
- `.toString()`
- `.append(arg)` This method not available for normal Strings. It converts the argument to a String and then appends its characters to the character sequence. 
- `StringBuilder insert(int offset, arg)` inserts the given argument-as-String into the existing `StringBuilder` object at the given position indicated by the offset. 
- `StringBuilder replace(int start, int end, String str)` replaces the substring from the specified index (inclusive) to the end index (exclusive) with a given string. 
- `StringBuilder delete(int start, int end)` removes the substring from the start index (inclusive) to the end index (exclusive).
- `StringBuilder reverse()` causes this character sequence to be replaced by the reverse of the sequence. 

```java
StringBuilder sb1 = new StringBuilder();
StringBuilder sb2 = new StringBuilder("Hi!"); 
```

##### Arrays
An array is a **reference type** (see [[Java#Primitive vs Reference types]]). All array elements are stored in the memory sequentially. Each element of the array is accessed by its numerical index and the first element has the **index 0**. The last element is accessed by the index equal to **array size -1**. It is possible to create an array to store elements of any type. 

```java
int[] array; // declaration form 1
int array[]; // declaration form 2: less used.

int[] numbers = { 1, 2, 3, 4 };		// instantiation.

int a = 1, b = 2, c = 3, d = 4;
int[] numbers = { a, b, c, d };		// instantiation using variables.

int n = 10;  						// n is a length of an array
int[] numbers = new int[n]; 		// initialization values unknown but length fixed.

int[] numbers; 						// declaration
numbers = new int[n];				// instantiation and initialization with default values
numbers = new int[] { 1, 2, 3, 4 };	// instantiation and initialization
```

###### Array length
```java
int[] array = { 1, 2, 3, 4 };		// make an array with 4 values

int length = array.length;			// count the number elements in the array

System.out.println(length);			// 4
```

###### Accessing array elements
Set the value by the index:
```java
	array[index] = val;
```

Get the value by the index:
```java
val = array[index];
```

Indexes of an array have numbers from **0** to **length - 1** inclusive. If you try to access a non-existing element then a runtime exception occurs. For instance, accessing an index of length or above throws `ArrayIndexOutOfBoundsException`.

###### Arrays utitlity class
* `Arrays.toString(array)` converts an array to string
* `Arrays.sort(array)` sorts a whole array or a part of it
* `Arrays.equals(array1, array2)` two arrays are equal if they contain the same elements in the same order
* `Arrays.fill(array, startIndex, endIndexExclusive, value)` bulk fills (part of) an array with a specific value. 
* [See further here](https://docs.oracle.com/javase/8/docs/api/java/util/Arrays.html).

###### Loop over array
```java
int n = 10; // the size of an array  
int[] squares = new int[n]; // creating an array with the specified size  
  
System.out.println(Arrays.toString(squares)); // [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]  
  
/* iterating over the array */  
for (int i = 0; i < squares.length; i++) {  
 squares[i] = i * i; // set the value by the element index   
}  
  
System.out.println(Arrays.toString(squares)); // [0, 1, 4, 9, 16, 25, 36, 49, 64, 81]

/* iterating over the array, alternative */
for (int x : squares) {
	System.out.print(x = " ");
}
// 0 1 4 9 16 25 36 49 64 81 
```

##### Multidimensional array
A multidimensional array is an array of arrays. Most common are **two-dimensional arrays**, which can be used to represent a **matrix** or a **table**. 

###### Two-dimensional arrays

```java
int[][] twoDimArray = {  
	{1, 2, 3}, // first array of ints  
	{4, 5, 6}, // second array of ints  
	{7, 8, 9} // third array of ints  
};
```

Unlike 'real' tables, the nested arrays do not have to have equal lengths. 

When accessing an element of the two-dimensional array, we first choose the nested array (counting from zero), and then choose the element inside (counting from zero). 

```java
twoDimArray[0][2]	// returns 3
twoDimArray[1][0]	// returns 4
twoDimArray[2][1]	// returns 8
```

Like all arrays, multidimensional arrays can be looped through. 

###### 3+-dimensional arrays
You can envision this array as representing a box instead of a simple grid, or as a table containing arrays in each field. 
| Just      | Like      | This      |
| --------- | --------- | --------- |
| [0,0,0,0] | [1,1,1,1] | [2,2,2,2] |
| [3,3,3,3] | [4,4,4,4] | [5,5,5,5] |

This particular array would be an `int[][][]` type. You can compare this with set theory and empty collections. 
```java
int[2][4][3] =
{
	{ {}, {}, {} },
	{ {}, {}, {} },
	{ {}, {}, {} },
	{ {}, {}, {} }
},
{
	{ {}, {}, {} },
	{ {}, {}, {} },
	{ {}, {}, {} },
	{ {}, {}, {} }
};
```

### Constants
You can mark a variable as immutable with the keyword `final`, turning it into a **constant**. 
Best practice is to represent a final variable in all caps with underscores to seperate words. This marks them as clearly different from regular variables. For local final variables, lowercase is also acceptable. 

You will get an error if you try to change a final variable, or if you try to use a final variable that hasn't had a value assigned to it yet.

Note: You can use the `final` keyword for reference values, in which case the *reference* cannot be changed, but the data that the reference points to *can* be changed. I.e., you don't change the object, but the *fields* of the object, which is fine.

### Wrapper classes
Each primitive type has a class dedicated to it. These classes are known as **wrappers** and they are **immutable** (just like strings). Wrapper classes can be used in different situations:
* When a variable can be `null` (absence of a value);
	* Note, this also exposes you to `NullPointerException`! [[Java#Run-time errors]]
* When you need to store values in generic collections
* When you want to use special methods of these classes.

| Primitive | Wrapper Class | Constructor Argument    |
| --------- | ------------- | ----------------------- |
| boolean   | Boolean       | boolean or String       |
| byte      | Byte          | byte or String          |
| char      | Character     | char                    |
| int       | Integer       | int or String           |
| float     | Float         | float, double or String |
| double    | Double        | double or String        |
| long      | Long          | long or String          |
| short     | Short         | short or String         |

#### Boxing and unboxing
**Boxing** is the conversion of primitive types to objects of the corresponding wrapper classes. **Unboxing** is the reverse process. **Autoboxing** and **auto-unboxing** are automatic conversions performed by the Java compiler. You can mix both automatic and manual boxing/unboxing processes in your programs. 

Autoboxing only works when both parts of an assignment have the same type.

```java
Long n1 = 10L ; 		// OK, assigning long to Long
Integer n2 = 10;		// OK, assigning int to Integer

Long n3 = 10;			// WRONG, assigning int to Long
Integer n4 = 10L		// WRONG, assigning long to Integer
```

#### Wrapper constructors
Deprecated since Java 9.

#### Comparing wrappers
Since wrappers are reference objects, `==` will compare whether two values *refer* to the same object in memory, so use `.equals()` to meaningfully compare the contents. 

### Generic type
A generic type is a generic class (or interface) that is parameterized over types. To declare a generic class, we need to declare a class with the type parameter section delimited by `<` angle brackets `>` following the class name. In the following example, the class `GenericType` has a single type parameter named `T`. We assume that the type `T` is "some type" and write the class body regardless of the concrete type. 

```java
class GenericType<T> {
	private T t;
	
	public GenericType(T t) {
		this.t = t;
	}
	
	public T get() {
		return t;
	}
	
	public T set(T t) {
		this.t = t;
		return this.t;
	}
}
```

After being declared, a type parameter can be used inside the class body as an ordinary type for fields, constructors, methods and even method return types. The behaviour of this class does not depend on the concrete type of T. 

When creating objects of generic classes, you need to specify the type argument following the type name.

```java
// from Java 5 onwards:
GenericType<Integer> obj1 = new GenericType<Integer>(10);
GenericType<String> obj2 = new GenericType<String>("abc");

// from Java 7 onwards:
GenericType<Integer> obj3 = new GenericType<>(10);
GenericType<String> obj4 = new GenericType<>("abc");

// from Java 10 onwards:
var obj5 = new GenericType<>("abc");
```

Note that you need to invoke a reference type, so use [[Java#Wrapper classes]] to refer to primitive types.

The latter ways of invoking the generic class' constructor only works if the compiler can *infer* the type arguments from the context. The keyword `var` forces automatic type inference based on the type of the assigned value.

After we have created an object with a specified type argument, we can invoke methods of class that take or return the type parameter:

```java
Integer number = obj1.get();		// 10
String string = obj2.get();			// "abc"

System.out.println(obj1.set(20));	// prints the number 20
System.out.println(obj.set("def"));	// prints the string "def"
```

If a class has multiple type parameters, we need to specify all of them when creating instances:

```java
GenericType<Type1, Type2, ..., TypeN> obj = new GenericType<>(...);
```

#### Non-generic alternative
Another, older style to write generic code is to use the `Object` class instead.

```java
class NonGenericClass {
	private Object val;
	
	public NonGenericClass(Object val) {
		this.val = val;
	}
	
	public Object get() {
		return val;
	}
}
```

When you `get()`, you don't get a `String` or an `Integer`, but you get an `Object` instead. It would need to be converted back with explicit [[Java#Type casting]]. 

```java
NonGenericClass instance = new NonGenericClass(123);
String str (String) instance.get(); // throws java.lang.ClassCastException
```

So the main advantage of generics over the `Object` class is that you don't need an explicit type-cast, avoiding runtime exceptions. If we do something wrong, we can see it at compile-time and fix it early.

Note: you can create an instance of a generic class with an implicit `Object` class, but then we get the same problems again. 

```java
GenericType instance = new GenericType("my-string");			// same
GenericType<Object> instance = new GenericType<>("my-string");	// same
```

#### Generic type parameter naming conventions
* `T` type
* `S` type2
* `U` type 3
* `V` type 4
* `E` element (used extensively by different collections)
* `K` key
* `V` value
* `N` number

#### Custom generic array
```java
public class ImmutableArray<T> {
	private final T[] items;
	
	public ImmutableArray(T[] items) {
		this.items = items.clone();
	}
	
	public T get(int index) {
		return items[index];
	}
	
	public int length() {
		return items.length;
	}
}
```

This class shows that a generic class can have methods (like length) that do not use the parameter type at all. 

## Type casting
Java provides two types of casting for primitive types: **implicit** and **explicit**. 

### Implicit casting
The compiler automatically performs **implicit casting** when the target type is wider (more bits) than the source type. The picture below illustrates the direction of this casting. 

![[Java.png]]

Normally, there is no loss of information when the target type is wider than the source type, such as when casting `int` to `long`. But it is not possible to automatically cast in the backward order. Two types don't need to be adjacent for the casting to work, so long as the implicit direction is followed.

Note: there is no `boolean` type on the picture above, because it is impossible to cast this type to any other and vice versa. 

### Explicit casting
```java
(targetType) source
```
When you use explicit casting, you may lose information and precision. Any possible casting not covered by implicit casting can *only* be converted with explicit casting. 

Examples:
```java
double d = 2.00003;  
  
// it loses the fractional part  
long l = (long) d; // 2  
  
// requires explicit casting because long is wider than int  
int i = (int) l; // 2   
  
// requires explicit casting because the result is long (indicated by L)  
int val = (int) (3 + 2L); // 5  
  
// casting from a long literal to char  
char ch = (char) 55L; // '7'
```

Explicit casting may truncate the value in order to fit into the new type. This problem is known as **type overflow**. 

Note: you still cannot cast to or from `boolean` in Java. 

## Input and Output
### Scanner
```java
import java.util.Scanner;

class Main {
	public static void main(String[] args) {
		// Initialise the Scanner object to enable input reading
		Scanner scanner = new Scanner(System.in);
	
		String word = scanner.next();			// Store a single word of input as String. 
		String line = scanner.nextLine();		// Store an entire line of input as String.
		int numeric = scanner.nextInt();		// Store input as an integer.
		boolean boo = scanner.nextBoolean();	// Store input as a boolean.
		boolean has = scanner.hasNext();		// Check whether there is more input to process.
	}
}
```

Note that this will use the system settings for how to read doubles and floats (with a decimal `.` or a decimal `,`). To override, set up the scanner as follows:

```java
Scanner scan = new Scanner(System.in).useLocale(Locale.US);
```

The constructor of the `Scanner` class can also take a `File` object as input. It also inherits from the [[Java#Iterator]] class.

```java
try {
	File x = new File("C:\\sololearn\\test.txt");
	Scanner sc = new Scanner(x);
	
	while(sc.hasNext()) {
		System.out.println(sc.next());
	}
	sc.close();		// closing files after use is good practice.
} 
catch (FileNotFoundException e) {
	// error handling.
}
```

### Random
```java
import java.util.Random;
```

Java provides the `Random` class to generate pseudorandom values of different types, such as `int`, `long`, `double` and `boolean`. 

* `Random()` creates a new random generator and sets a random**seed** of the generator. 
	* `Random(long seed)` creates a new random generator with a specific seed. 
* `int nextInt()` returns a pseudorandom value of the `int` type.
	* `int nextInt(int n)` returns a pseudorandom value of `int` type in the range from `0` (inclusive) to `n` (exclusive). 
* `long nextLong()` returns a pseudorandom value of `long` type.
* `double nextDouble()` returns a pseudorantom value of `double` type between `0.0` and `1.0`.
* `void nextBytes(byte[] bytes)` generates random bytes and places them into a user-supplied byte array.

The methods generate uniformly distributed values. The method `nextGaussian()` can be used for a Gaussian distributed pseudorandom double, which has specific use cases. 

### File
The `java.io` package includes a `File` class that allows you to work with files. To start, create a `File` object and specify the filepath in the constructor.

```java
import java.io.File;
...
File file = new File("C:\\data\\input-file.txt");
// One backslash should be escaped in the path String, so double backslashes are used.
```

* `boolean exists()` checks whether a filepath corresponds with an actually existing file. 
* `String getName()` returns the filename of an existing file.

### Formatter
The `java.util` package also has the `Formatter` class, which is used to create content and write it to files.

```java
import java.util.Formatter;

public class MyClass {
	public static void main(String[] args) {
		try {
			Formatter f = new Formatter("C:\\sololearn\\test.txt");
		} catch (Exception e) {
			System.out.println("Error");
		}
	}
}
```

The code above creates an empty file at the specified path. If the file already exists, this will overwrite it.

* `.format(..., ...)` formats its parameters according to its first parameter. See [[Java#String manipulation]] for a guide to using this method effectively.

```java
import java.util.Formatter;

public class MyClass {
	public static void main(String[] args) {
		try {
			Formatter f = new Formatter("C:\\sololearn\\test.txt");
			f.format("%s %s %s", "1", "John", "Smith \r\n");
			f.format("%s %s %s", "2", "Amy", "Brown");
			f.close();
		} catch (Exception e) {
			System.out.println("Error");
		}
	}
}
```

The code above creates a file with the following content:

```
1 John Smith
2 Amy Brown
```

## Ternary operator
 ```java
if (condition) {
	result = trueCase;
} else {
	result = elseCase;
}
```

The above three-part clause can be abbreviated as follows:
```java
result = condition ? trueCase : elseCase;
```

While it is possible to nest a ternary operator inside *another* ternary operator, this makes it much less readable and is greatly discouraged.

## Switch
```java
switch (variable) {
	case value1:
		// do something
		break;
	case value2:
		// do something
		break;
	// ...
	case valueN:
		// do something
		break;
	default: // the default case is optional
		// do something
		break; // this last break is optional
}
```

The switch statement provides a way to choose between multiple cases based on the value of a single variable (int, char, String, enum). It does not work for expressions. It is possible to write nested switch statements, but it is not recommended.

## Loops
### For loop
```java
for (initialization; condition; modification) {
	// do something
}
```

For example:
```java
for (int i = 0; i < 5; i++) {
	System.out.println(i);
}
```

The flow is as follows:
1. The initialization statement.
2. If the condition is `false` then terminate the loop.
3. If the condition is `true` then execute the code in the body.
4. The modification statement. 
5. Return to step 2 (condition).

### While loop
```java
while (condition) {
	// do something
}
```

If the condition fails immediately, the body is never executed. 

### Do-while loop
```java
do {
	// do something
} while (condition);
```

Execute code once, then check condition, then repeat if condition is met. 

### For-each loop
For-each loops can be used to loop through data sequences such as arrays without knowing the length in advance. 

```java
for (type var : array) {
	// statements using var
}
```
For each element `var` of type `type` in the `array` array do `{` some statements in the body `}`. If you don't know the specific variable type in advance, you can use `var` as an agnostic type.

The for-each loop has some limitations. First of all, you cannot use it if you want to modify an array, because the variable we use for iterations doesn't store the array element itself, only its copy. It is also impossible to obtain an element by its index since we have no index track. Finally, as is clear from the name, we cannot move through an array with more than one step per iteration: we iterate over each and every element, so we work with them one by one.

That said, it is impossible to get an `ArrayIndexOutOfBoundsException` with this type of loop, and it is more readable than the `for` loop equivalent. 

### Break
The **break** statement has two uses: 
1. It terminates the current loop of any type ([[Java#For loop]], [[Java#While loop]], [[Java#Do-while loop]], [[Java#For-each loop]]).
2. It terminates a case in the [[Java#Switch]] statement. 
It only terminates the loop in which it is currently located. If this loop is performed inside another loop, the outer loop won't be stopped. To stop the outer loop, you could use a boolean variable `stopped` (or similar) as a special flag. 

### Continue
This statement causes a loop to skip the rest of the current iteration and go to the next one. It can be used inside any kind of loop. 
- Inside the [[Java#For loop]], the continue causes control to immediately move to the increment/decrement statement.
- Inside the [[Java#While loop]] or [[Java#Do-while loop]], control immediately moves to the condition. 
Like the [[Java#Break]] statement, **continue** only affects the current loop. 

## Errors
Here is the simplified hierarchy of exceptions:

![[Java 4.png]]

The base class for all exceptions is `java.lang.Throwable`, and it provides a set of common methods:
* `String getMessage()` returns the detailed string message of this exception object
* `Throwable getCause()` returns the cause of this exception or `null` if the cause is nonexistent or unknown
* `printStackTrace()` prints the stack trace on the standard error stream

Subclassses: 
* `java.lang.Error` represents low-level exceptions in the [[JVM]] like `OutOfMemoryError` and `StackOverflowError`. 
* `java.lang.Exception` deals with exceptional events inside applications, such as `RunTimeException` and `IOException`.
	* `java.lang.RuntimeException` represents **unchecked** exceptions ([[Java#Run-time errors]]) including `ArithmeticException`, `NumberFormatException` and `NullPointerException`.

### Compile-time errors
Compile-time errors (also called **checked errors**) are errors that prevent a Java program from being compiled: 
* a **syntax error**; **incorrect keyword**, a **forgotten** `;` at the end of a statement
* a **bad source code file name**
* invoking a **non-existing method**
* etc.

Many of these mistakes can be caught by modern [[IDE]]s with static code analyzers to both identify and prevent such mistakes.

If a method `throws` a checked exception ([[Java#Throw]]) in the method declaration, the code *will* compile. 

### Run-time errors
Run-time errors (also called **unchecked** errors) only happen when faulty code is run. There are two subtypes of run-time errors:
* **logic errors** - when a program produces a wrong result because the code is not correct
* **unhandled exceptional events** like division by zero, not found files, and other unexpected cases. 

Avoiding these errors is more difficult than avoiding compile-time errors. Successful compilation is no guarantee for a bug-free application. There are various strategies to find such errors:
* to **debug** your program
* to write **automatic tests** for your program
* to use the practice of **code review** as part of the development program

* `ArithmeticException` is thrown when an exceptional condition has occurred in an arithmetic operation.
* `ArrayIndexOutOfBoundsException` is thrown to indicate that an array has been accessed with an illegal index. The index is either negative or greater than or equal to the size of the array.
* `ClassNotFoundException` is raised when we try to access a class whose definition is not found.
* `FileNotFoundException` is raised when a file is not accessible or does not open.
* `IOException` is thrown when an input-output operation failed or interrupted.
* `InterruptedException` is thrown when a thread is waiting, sleeping, or doing some processing, and it is interrupted.
* `NoSuchFieldException` is thrown when a class does not contain the field (or variable) specified.
* `NoSuchMethodException` is thrown when accessing a method which is not found.
* `NullPointerException` is raised when referring to the members of a null object. Null represents nothing.
* `NumberFormatException` is raised when a method could not convert a string into a numeric format.
* `RuntimeException` represents any exception which occurs during runtime.
* `StringIndexOutOfBoundsException` is thrown by String class methods to indicate that an index is either negative or greater than the size of the string.

#### Exceptions
An exception is an error that only occurs when trying to execute "broken" code. These errors can be prevented with an error catching logic flow that funnels "broken" input through a custom error message, preventing the program from ever executing the broken code & crashing. 

* `ArithmeticException` such as "/ by zero". 
* `NumberFormatException` trying to convert a string to an integer, if the string has unsuitable format. 

```java
if (input.matches("\\d+")) {		// if all digits
	// do the conversion
} else {
	System.out.println("Incorrect number: " + input);
}
```

This regular expression 'trick' can be used to avoid `NumberFormatException`. 

* `NullPointerException` or `NPE` caused by unassigned reference variable

```java
String str = null;

int size = str != null ? str.length : 0;
// If the string is null, return 0 instead

if (str.equals("abc")) { } 	// NPE; applying String method to null
if ("abc".equals(str)) { }  // no NPE; applying String method to String
if (Objects.equals(str1, str2)) {}	// no NPE; RECOMMENDED METHOD
```

* `NegativeArraySizeException` when you try to create an array with, you know, negative size
* `ArrayIndexOutOfBounds` when accessing an index that doesn't exist (array isn't that long)

### Try/catch
```java
try {
	// some code
} catch (Exception e) {
	// some code to handle errors
}
```

A `catch` statement involves declaring the type of exception you are trying to catch. If an exception occurs in the `try` block, the `catch` block that follows the `try` is checked. If the exception that occurred is listed there, the exception is passed to the `catch` block much as an argument is passed into a method parameter. The `Exception` type can be used to catch all possible exceptions. 

The specified type in the `catch` block must extend the `Throwable` class. 

If you catch multiple types of exceptions, order them from specific to generic. Or more accurately, put any and all subclasses before their base class. 

```java
try {
	// some code
} catch (ExceptionType1 e1) {
	// catch block
} catch (ExceptionType2 e2) {
	// catch block
} catch (ExceptionType3 | ExceptionType4 e) {
	// this was added in Java 7; these exceptions will have a single code block for handling them. These multi-catch types cannot be each other's subclasses.
}
} catch (Exception e) {
	// ultra-generic catch block
}
```

You can get info about the exception caught by the `catch` block. For example:

```java
try {
	double d = 2 / 0;
} catch (Exception e) {
	System.out.println(e.getMessage());
}
// An exception occured: / by zero
```

#### Finally
```java
try {
	// code that may throw an exception
} catch (Exception e) {
	// code that is executed if an exception is encountered
} finally {
	// code always excecuted after try/catch sequence
}
```

The `finally` block is executed even if another exception occurs in the `catch` block. 

You can also omit the `catch` block to execute the `finally` block right after `try` (whether that works or not). 

### Throw
```java
int div(int a, int b) throws ArithmeticException {
	if (b == 0) {
		throw new ArithmeticException("Division by Zero");
	} else {
		return a / b;
	}
}
```

## Threads
Java is a **multi-threaded** programming language. 

![[Java 3.png]]

### Extend Thread class
You can create a custom thread by extending the `Thread` class and overriding its `run()` method. Then you create a new object of your class and call its `start()` method to run the thread.

Every Java thread is prioritized to help the [[1. Werk/2. Technische kennis/Algemene concepten/OS|OS (Operating system)]] determine the order in which to schedule threads. The priorities range from 1 to 10, with each thread defaulting to priority 5. You can set the thread priority with the `setPriority()` method. 

```java
class A extends Thread {
	
	public void run() {
		System.out.println("Hello");
	}
	
	public static void main(String[] args) {
		A object = new A();
		object.start();
	}
}
```

### Implement Runnable interface
You can implement the `Runnable` [[Java#Interfaces]] in your class and then implementing the `run()` method. Then you create a new `Thread` object, pass your class to the constructor, and start it by calling the `start()` method. 

```java
class Loader implements Runnable {
	public void run() {
		System.out.println("Hello");
	}
}

class MyClass {
	public static void main(String[] args) {
		Thread t = new Thread(new Loader());
		t.start();
	}
}
```

The `Thread.sleep()` method pauses a Thread for an amount of miliseconds. For example, calling `Thread.sleep(1000)` pauses the thread for one second. Keep in mind that `Thread.sleep()` throws an `Interrupted Exception`, so be sure to surround it with a `try`/`catch` block. 

The implementation method is preferred for multithreading, because you can only extend one class while you can implement multiple interfaces.
## Annotations
- `@Deprecated` indicates that the marked element (class, method, field, etc) is deprecated and should no longer be used. This annotation causes a compile warning if the element is used.
- `@SuppressWarning(String... value)` instructs the compiler to disable the compile-time warnings specified in the annotation parameters. This annotation can be applied to classes, methods, fields, local variables and other elements. 
	- `"unused"` suppresses warning about unused local variables
	- `"deprecation"` suppresses warning about using deprecated elements
- `@Override` marks a method that overrides a superclass method. This annotation can only be applied to methods. 

(External) libraries can define more annotations. 
Note that for any annotation that can pass elements, you *have* to specify the name of that element *unless* there is only one element *which is called*`value`. 