---
tags:
  - Techniek
---
# SOLID
Acronym for five principles for understandable, flexible and maintainable source code. 

### Single responsibility principle

The [single-responsibility principle](https://en.wikipedia.org/wiki/Single-responsibility_principle "Single-responsibility principle") (SRP) states that there should never be more than one reason for a [class](https://en.wikipedia.org/wiki/Class_\(programming\) "Class (programming)") to change. In other words, every class should have only one responsibility.

Importance:

- Maintainability: When classes have a single, well-defined responsibility, they're easier to understand and modify.
- Testability: It's easier to write unit tests for classes with a single focus.
- Flexibility: Changes to one responsibility don't affect unrelated parts of the system.

### Open–closed principle

The [open–closed principle](https://en.wikipedia.org/wiki/Open%E2%80%93closed_principle "Open–closed principle") (OCP) states that software entities should be open for extension, but closed for modification.

Importance:

- Extensibility: New features can be added without modifying existing code.
- Stability: Reduces the risk of introducing bugs when making changes.
- Flexibility: Adapts to changing requirements more easily.

### Liskov substitution principle

The [Liskov substitution principle](https://en.wikipedia.org/wiki/Liskov_substitution_principle "Liskov substitution principle") (LSP) states that functions that use pointers or references to base classes must be able to use pointers or references of derived classes without knowing it. See also [design by contract](https://en.wikipedia.org/wiki/Design_by_contract "Design by contract").

Importance:

- [Polymorphism](https://en.wikipedia.org/wiki/Polymorphism_\(computer_science\) "Polymorphism (computer science)"): Enables the use of polymorphic behavior, making code more flexible and reusable.
- Reliability: Ensures that subclasses adhere to the contract defined by the superclass.
- Predictability: Guarantees that replacing a superclass object with a subclass object won't break the program.

### Interface segregation principle

The [interface segregation principle](https://en.wikipedia.org/wiki/Interface_segregation_principle "Interface segregation principle") (ISP) states that clients should not be forced to depend upon interface methods that they do not use.

Importance:

- Decoupling: Reduces dependencies between classes, making the code more [modular](https://en.wikipedia.org/wiki/Modularity "Modularity") and maintainable.
- Flexibility: Allows for more targeted implementations of interfaces.
- Avoids unnecessary dependencies: Clients don't have to depend on methods they don't use.

### Dependency inversion principle

The [dependency inversion principle](https://en.wikipedia.org/wiki/Dependency_inversion_principle "Dependency inversion principle") (DIP) states to depend upon abstractions, not concretes.

Importance:

- [Loose coupling](https://en.wikipedia.org/wiki/Loose_coupling "Loose coupling"): Reduces dependencies between modules, making the code more flexible and easier to test.
- Flexibility: Enables changes to implementations without affecting clients.
- [Maintainability](https://en.wikipedia.org/wiki/Maintainability "Maintainability"): Makes code easier to understand and modify.