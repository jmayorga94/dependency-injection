Dependency injection is a design pattern that supports the development of loosely couple code.

The use of DI supports the implementation of two important concepts. The inversion of control and dependency inversion principle.

Is foundational concept in netcore that the framework.

It is strongly recommended to use it.

How to address problems?

Invert control

DI => high level modules should not depend on low level modules. Both should depend on abstractions.

Abstractions should not depend upon details, Details should depende on abstractions.

Advantages
Promotes loosely coupling of components
Promotes logical abstractions of components
Supports unit testing by allowing fake or moq the dependencies
Improves readability of our code
