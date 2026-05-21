---
aliases: [CDT, CDT (Concrete Data Type)]
tags: Techniek
---
# Data structure
**Data structures** are a way of organizing data and providing convenient access to it. It refers to a collection of elements containing data, as well as relationships between them, and data operations. As a rule, data structures have two types of **operations**: **internal**, supporting data organization, and **external**, available to users for storing, retrieving, or modifying data. 

Common data structures:
* Array
* Linked list
* Hash table
* Trees
	* Binary search tree
	* Heap
	* Red-black tree
	* B-tree
	* etc.

Data structures and their inherent complexities greatly impact [[Algorithm efficiency]], so it is essential to choose the most efficient for the task at hand. 

## Dijkstra's algorithm
Shortest path algorithm with two main implementations: using an array or a heap as a data structure.
* Array: $O(n^2+m)$ 
* Heap: $O((n+m)\log n)$ (faster)