---
aliases: [CS (C#), C#, C sharp]
tags: Techniek
---

# C#
C# is an object-oriented ([[OOP]]) programming language that evolved from [[C++]] and [[C]]. 

## Type converting
* `Convert.ToBoolean(...)` converts value to a boolean
* `Convert.ToDouble(...)`
* `Convert.ToInt16(...)` this int is `short`
* `Convert.ToInt32(...)` default `int`
* `Convert.ToInt64(...)` this int is `long`

## Field vs Property
```csharp
private string text; 			// field
public string Text				// property
{
	get { return text; }		// return the private val
	set { text = value; }		// set private val to input
}
```

## Structs
A `struct` type is a value type that is typically used to encapsulate small groups of related variables, such as the coordinates of a rectangle or the characteristics of an item in an inventory. Structs share most of the same syntax as classes, but are more limited than classes. Unlike classes, structs can be instantiated without using a new operator. Structs do not support inheritence and cannot contain virtual methods.

```cs
struct Book {
	public string title;
	public double price;
	public string author;
}

static void Main(string[] args) {
	Book b;
	b.title = "Test";
	b.price = 5.99;
	b.author = "David";
	
	Console.WriteLine(b.title);
}
```

Structs can contain methods, properties, indexers, and so on. They cannot contain default constructors (without parameters), but they can have constructors that take parameters. In that case the `new` keyword is used to instantiate a struct object, similar to class objects. 

```cs
struct Point {
	public int x;
	public int y;
	public Point(int x, int y) {
		this.x = x;
		this.y = y;
	}
}
static void Main(string[] args) {
	Point p = new Point(10,15);
	Console.WriteLine(p.x);
}
```

Structs are best suited for small data structures that contain primarily data that is not intended to be modified after the struct is created. Consider defining a struct instead of a class if you are trying to represent a simple set of data. 

## Enums
The `enum` keyword is used to declare an enumeration: a type that consists of a set of named constants called the enumerator list. They are often used with `switch` statements, like below:

```cs
enum TrafficLights { Green, Red, Yellow };

static void Main(string[] args) {
	TrafficLights x = TrafficLights.Red;
	switch(x) {
		case TrafficLights.Green: 
			Console.WriteLine("Go!");
			break;
		case TrafficLights.Red:
			Console.WriteLine("Stop!");
			break;
		case TrafficLights.Yellow:
			Console.WriteLine("Caution!");
			break;
	}
}
```

## Generics
```cs
static void Swap<T>(ref T a, ref T b) {
	T temp = a;
	a = b;
	b = temp;
}
```

Create a generic type with `<>` syntax. `T` is a commonly used name. We also use this type for the placeholder field `temp`. You can also use multiple generic parameters like in `Func<T,U>`. 

Generic types can also be used with classes, which is most commonly used for collections. 

```cs
class Stack<T> {
	int index=0;
	T[] innerArray = new T[100];
	public void Push(T item) {
		innerArray[index++] = item;
	}
	public T Pop() {
		return innerArray[--index];
	}
	public T Get(int k) { return innerArray[k]; }
}
```

The generic class above stores elements in an array using the [[LIFO|LIFO (Last-In-First-Out)]] principle. Now it can be used to create different type-specific stacks:

```cs
Stack<int> intStack = new Stack<int>();
Stack<string> strStack = new Stack<string>();
Stack<Person> PersonStack = new Stack<Person>();
```

## Collections
```cs
using System.Collections.Generic;
```
- Generic collections (preferred type so long as every element in the collection is of the same data type; can be via common base class)
	- `List<T>`
	- `Dictionary<TKey,TValue>`
	- `SortedList<TKey,TValue>`
	- `Stack<T>`
	- `Queue<T>`
	- `Hashset<T>`
- Non-generic collections (not advised)
	- `ArrayList`
	- `SortedList`
	- `Stack`
	- `Queue`
	- `Hashtable`
	- `BitArray`

### List
A list is similar to an array, but the elements in a list can be inserted and removed dynamically. 
* `.Count` gets the number of elements contained in the list.
* `.Item[int i]` gets or sets the element in the list at the index i. Item is the indexer and is not required when accessing an element. You need only use the brackets [] and the index value inside the brackets. 
* `.Add(T t)` adds an element `t` to the end of the list.
* `.RemoveAt(int index)` removes the element at the specified position (index) from the list
* `.Sort()` sorts elements in the list.
* `.Capacity` gets the number of elements the list can hold before needing to be resized
* `.Clear()` removes all elements from the list
* `.TrimExcess()` sets the capacity to the actual number of elements in the list; useful when trying to reduce memory overhead
* `.AddRange(IEnumerable coll)` adds the elements of a collection coll with the elements of the same type as `List<T>` to the end of the list. IEnumerable is the collections interface that supports simple iteration over the collection. 
* `.Insert(int i, T t)` insert element t at specific index i
* `.InsertRange(int i, IEnumerable coll)` insert elements of collection coll at specific index i
* `.Remove(T t)` removes first occurrence of the object t from the list
* `.RemoveRange(int i, int count)` removes a specified number of elements (count) from the list starting at specified index i
* `.Contains(T t)` returns true if the specified element t is present in the list.
* `.IndexOf(T t)` returns the index of the first occurrence of the element t in the list
* `.Reverse()` reverses the order of the elements in the list
* `.ToArray()` copies the elements of the list into a new array

### SortedList
A sorted list is a collection of **key/value pairs** that are sorted by key. A key can be used to access its corresponding value in the sorted list. The generic collection `SortedList<K,V>` class requires all key/valye pairs to be of the same type **K, V**. Duplicate keys are **not permitted**, which ensures that every key/value pair is unique.

* `.Count` gets the number of key/value pairs contained in the sorted list.
* `.Item[K key]` gets or sets the value associated with the specific key contained in the sorted list. Item is the indexer and is not required when accessing an element. You need only use the brackets [] and the key, value. 
* `.Keys` gets a sorted and indexed collection containing only the keys in the sorted list
* `.Add(K key, V value)` adds an element with a specific key, value pair into the sorted list
* `.Remove(K key)` removes the element with the specific key, value pair associated with the specified key from the sorted list
* `.Values` gets a sorted and indexed collection of the values in the sorted list
* `.Clear()` removes all the elements from the sorted list
* `.ContainsKey(K key)` returns true if the specified key is present in the sorted list
* `.ContainsValue(V value)` returns true if the specified value is present in the sorted list
* `.IndexOfKey(K key)` returns the index of the specified key within the sorted list
* `.IndexOfValue(V value)` returns the index of the specified value within the sorted list

### BitArray
A bit array is a collection of bits. The value of a bit can be either 0 (off/false) or 1 (on/true). Bit arrays compactly store bits. Most commonly, they are used to represent a simple group of boolean flags or an ordered sequence of boolean values. 

* `.Count` gets the number of bits in the bit array.
* `.IsReadOnly` gets a value indicating whether the bit array is read only or not.
* `.Get(int i)` gets the value of the bit at a specified position `i` in the bit array.
* `.Set(int i, bool value)` sets the bit at a specified position `i` in the bit array to a specified value. 
* `.SetAll(bool value)` sets all the bits in the bit array to a specified value.
* `.And(BitArray ba)` performs the bitwise `AND` operation on the elements of the bit array with a specified bit array `ba`.
* `.Or(BitArray ba)` performs the bitwise `OR` operation on the elements of the bit array with a specified bit array `ba`.
* `.Not()` inverts the bit values of the bit array.
* `.Xor(BitArray ba)` performs the bitwise `XOR` operation on the elements of the current bit array and the elements in the specified bit array `ba`.

### Stack(T)
A stack is a [[LIFO|LIFO (Last-In-First-Out)]] collection of elements where the last element that goes into the stack will be the first element that comes out. Inserting an element onto a stack is called **pushing**. Deleting an element from a stack is called **popping**. Pushing and popping can be performed only at the **top** of the stack. The C# generic collection `Stack<T>` class requires all elements to be of the same type `T`. 

* `.Count` returns the number of elements in the stack.
* `.Peek()` returns the element at the top of the stack without removing it.
* `.Pop()` returns the element at the top of the stack and removes it from the stack. 
* `.Push(T t)` inserts an element `t` at the top of the stack. 
* `.Clear()` removes all the elements from the stack.
* `.Contains(T t)` returns true if the element `t` is present in the stack.
* `.ToArray()` copies the stack into a new array.

### Queue(T)
A queue is a [[FIFO|FIFI (First-In-First-Out)]] collection of elements where the first element that goes into a queue is also the first element that comes out. Inserting an element into a queue is referred to as **Enqueue**. Deleting an element from a queue is referred to as **Dequeue**. The C# generic collection `Queue<T>` class requires that all elements be of the same type `T`.

* `.Count` returns the number of elements in the queue.
* `.Dequeue()` returns the object at the beginning of the queue and also removes it.
* `.Enqueue(T t)` adds the object `t` to the end of the queue.
* `.Clear()` removes all objects from the queue.
* `.Contains(T t)` returns true if the element `t` is present in the queue.
* `.Peek()` returns the object at the beginning of the queue without returning it.
* `.ToArray()` copies the queue into a new array.

### Dictionary(K,V)
A dictionary is a collection of unique key/value pairs where a key is used to access the corresponding value. Dictionaries are used in database indexing, cache implementations, and so on. The C# generic collection `Dictionary<K,V>` class requires all key/value pairs to be of the same type `K, V`. Duplicate keys are *not permitted* to ensure that every key/value pair is unique.

* `.Count` returns the number of key/value pairs contained in the dictionary.
* `.Item[K key]` returns the value associated with the specified key in the dictionary. Item is the indexer and is not required when accessing an element. You only need to use the brackets `[]` and key value.
* `.Keys` returns an indexed collection containing only the keys contained in the dictionary. 
* `.Add(K key, V value)` adds the key/value pair to the dictionary.
* `.Remove(K key)` removes the key/value pair related to the specified key from the dictionary. 
* `.Values` returns an indexed collection containing only the values contained in the dictionary. 
* `.Clear()` removes all key/value pairs from the dictionary.
* `.ContainsKey(K key)` returns true if the specified key is present in the dictionary.
* `.ContainsValue(V value)` returns true if the specified value is present in the dictionary.

### HashSet(T)
A hash set is a set of unique values where duplicates are not allowed. The C# generic collection `HashSet<T>` class requires all elements to be of the same type `T`. The elements do not have index positions and the elements cannot be ordered.

* `.Count` returns the number of values in the hash set.
* `.Add(T t)` adds a value `t` to the hash set.
* `.IsSubsetOf(ICollection c)` returns true if the hash set is a subset of the specified collection `c`.
* `.Remove(T t)` removes the value `t` from the hash set.
* `.Clear()` removes all elements from the hash set. 
* `.Contains(T t)` returns true if a value `t` is present in the hash set.
* `.ToString()` creates a string from the hash set.
* `.IsSupersetOf(ICollection c)` returns true if the hash set is a superset of the specified collection `c`.
* `.UnionWith(ICollection c)` applies set union operation on the has set and the specified collection `c`. 
* `.IntersectWith(ICollection c)` applies set intersect operation on the has set and the specified collection `c`. 
* `.ExceptWith(ICollection c)` applies set difference operation on the has set and the specified collection `c`. 

## Classes
### Keywords
#### This
The `this` keyword is used inside the class and refers to the current instance of the class, meaning it refers to the current object. One of the common uses of `this` is to distinguish class members from other data, such as local or formal parameters of a method, as shown in the following example:

```cs
class Person 
{
	private string name;
	public Person(string name) 
	{
		this.name = name;
	}
}
```

Another common use of `this` is for passing the current instance to a method as parameter: `ShowPersonInfo(this)`. You can also target the instance fields with e.g. `PrettyPrint(this.name)`. 

#### Readonly
The `readonly` modifier prevents a member of a class from being modified after construction. It can be modified only when you declare it or from within a constructor. (Compare [[Java]]'s `final`). It can be declared in one place and then instantiated (filled) in another, which is why this keyword does allow the value to be filled in the constructor method (unlike `const` below). 

#### Const
The `const` modifier prevents a member of a class from being modified after declaration. It must be instantiated immediately. As such, it cannot be declared in general and then instantiated within the constructor method. 

#### Sealed
The `sealed` keyword prevents other classes from inheriting a class, or any of its members. 
```cs
sealed class Animal {
	//some code
}
class Dog : Animal { } //Error
```

#### Virtual
The `virtual` keyword allows any derived class to override the base class' method. 
```cs
class Shape {
	public virtual void Draw() {
		Console.Write("Base Draw");
	}
}

class Circle : Shape {
	public override void Draw() {
		// draw a circle...
		Console.WriteLine("Circle Draw");
	}
}
class Rectangle : Shape {
	public override void Draw() {
		// draw a rectangle...
		Console.WriteLine("Rect Draw");
	}
}
```

#### Abstract
```cs 
abstract class Shape {
	public abstract void Draw();
}

class Circle : Shape {
	public override void Draw() {
		// draw a circle...
		Console.WriteLine("Circle Draw");
	}
}
class Rectangle : Shape {
	public override void Draw() {
		// draw a rectangle...
		Console.WriteLine("Rect Draw");
	}
}
```

An abstract class cannot be instantiated. It can contain abstract methods and accessors. A non-abstract class derived from an abstract class must include actual imprementations of all inherited abstract methods and accessors. 

### Indexers
Declaration of an indexer is to some extent similar to a property. The difference is that indexer accessors require an index. Like a property, you use **get** and **set** for defining an indexer. However, where properties return or set a specific data member, indexers return or set a particular value from the object instance. Indexers are defined with the `this` keyword ([[1. Werk/2. Technische kennis/Languages/CS#This]]). 
```cs 
class Clients 
{
	private string[] names = new string[10];
	
	public string this[int index] {
		get {
			return names[index];
		}
		set {
			names[index] = value;
		}
	}
}
```

As you can see, the indexer definition includes the `this` keyword and an index, which is used to get and set the appropriate value. Now, when we declare an object of class Clients, we use an index to refer to specific objects like the elements of an array:

```cs
Clients c = new Clients();
c[0] = "Dave";
c[1] = "Bob";

Console.WriteLine(c[1]);
```

You can typically use an indexer if the class represents a list, collection, or array of objects.

### Destructors
As constructors are used when a class is instantiated, **destructors** are automatically invoked when an object is destroyed or deleted. 
* A class can only have **one** destructor.
* Destructors cannot be called. They are invoked automatically.
* A destructor does not take modifiers or have parameters.
* The name of a destructor is exactly the same as the class prefixed with a **tilde (~)**. 

```cs
class Dog
{
	~Dog()
	{
		// code statements
	}
}
```

Destructors can be very useful for releasing resources before coming out of the program. This can include closing files, releasing memory, and so on.

### Static constructors
Constructors can be declared `static` to initialize static members of the class. The static constructor is automatically called once when we access a static member of the class.
```cs
class SomeClass
{
	public static int X { get; set; }
	public static int Y { get; set; }
	
	static SomeClass() 
	{
		X = 10;
		Y = 20;
	}
}
```

The constructor will get called once we try to access `SomeClass.X` or `SomeClass.Y`. 

### Operator overloading
Most operators in C# can be **overloaded**, meaning they can be redefined for custom actions. For example, you can redefine the action of the plus (+) operator in a custom class. 

```cs
class Box {
	public int Height {get; set;}
	public int Width {get; set;}
	public Box(int h, int w) {
		Height = h;
		Width = w;
	}
	
	public static Box operator+ (Box a, Box b) {
		int h = a.Height + b.Height;
		int w = a.Width + b.Width;
		Box res = new Box(h,w);
		return res;
	}
	
	public static bool operator> (Box a, Box b) {
		if (a.Height*a.Width > b.Height*b.Width)
			return true;
		else
			return false;
	}
}

static void Main(string[] args) {
	Box b1 = new Box(14,3);
	Box b2 = new Box(5,7);
	
	Box b3 = b1 + b2;
}
```

We target the operator with `operator+` in a `static` method for the class Box. 

All arithmetic and comparison operators can be overloaded. For instance, you could define greater than and less than operators for the boxes that would compare the Boxes and return a **boolean** result. Just keep in mind that when overloading the greater than operator, the less than operator should also be defined. 

### Inheritence
```cs
class Animal {
	public Animal() {
		Console.WriteLine("Animal created");
	}
	~Animal() {
		Console.WriteLine("Animal deleted");
	}
}
class Dog: Animal {
	public Dog() {
		Console.WriteLine("Dog created");
	}
	~Dog() {
		Console.WriteLine("Dog deleted");
	}
}

class Main {
	static void Main(string[] args) {
		Dog d = new Dog();
		
		/*
		Animal created
		Dog created
		(...)
		Dog deleted
		Animal deleted
		*/
	}
}
```

### Nested classes
```cs
class Car {
	string name;
	public Car(string nm) {
		name = nm;
		Motor m = new Motor();
	}
	public class Motor {
		// some code
	}
}
```

A nested class acts as a member of the class, so it can have the same access modifiers as other members (public, private, protected). 

## Static classes
### Math
* `.PI` the constant $\pi$
* `.E` represents the natural logarithmic base $e$
* `.Max()` returns the larger of its two arguments
* `.Min()` returns the smaller of its two arguments
* `.Abs()` returns the absolute value of its argument
* `.Sin()` returns the sine (sinus / $\sin$) of the specified angle
* `.Cos()` returns the cosine (cosinus / $\cos$) of the specified angle
* `.Pow()` returns a specified number raised to the specified power ($n^ x$)
* `.Round()` rounds the decimal number to its nearest integral value
* `.Sqrt()` returns the square root of a specified number ($\sqrt n$)

### Array
```cs 
int[] arr = {2, 3, 1, 4};

Array.Reverse(arr);
//arr = {4, 1, 3, 2}

Array.Sort(arr);
//arr = {1, 2, 3, 4}
```

### String
```cs
string s1 = "some text";
string s2 = "another text";

String.Concat(s1, s2); // combines the two strings

String.Equals(s1, s2); // returns false
```

### DateTime
```cs
DateTime.Now;		// represents the current date & time
DateTime.Today;		// represents the current day

DateTime.DaysInMonth(2016, 2);
// return the number of days in the specified month
```

### Console
```csharp
class MyClass 
{
	static void Main(string[] args) 
	{
		string yourName;
		Console.WriteLine("What is your name?");
		
		yourName = Console.ReadLine();
		
		Console.WriteLine("Hello {0}", yourName);
	}
}
```

* `Console.WriteLine(...)` displays a string on the 
* `string Console.ReadLine()` waits for user input and then assigns it to the variable. 
* `Console.WriteLine(..., ...)` displays a *formatted* string. 
	* `{0}` of the following array of parameters, insert the one at index=`0` here. 

### File
```cs
using System.IO;

//(...)

string str = "Some text";
File.WriteAllText("test.txt", str);
```

* `WriteAllText(filepath, content)` creates a file with the specified path and writes the content to it. If the file already exists, it is overwritten. 
* `AppendAllText(filepath, content)` appends text to the end of the file
* `ReadAllText(filepath)` reads the content to a string. 
* `Create(filepath)` creates a file in the specified location
* `Delete()` deletes the specified file
* `Exists()` determines whether the specified file exists
* `Copy()` copies a file to a new location
* `Move()` moves a specified file to a new location

All of the above methods automatically close the file after performing the operation.