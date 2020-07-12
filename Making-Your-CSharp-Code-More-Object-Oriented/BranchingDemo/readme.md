## State Pattern
* Object of the state class represents one state.
* Change the object when you want to change the state

* each operation to return next state

## Consequences of the State Pattern
* Class doesn't have to represent its state explicitly anymore.
* Class doesn't have to manage state transition logic.

* No more branching.
* Runtime type of the state object replaces branching.
* Dynamic dispatch used to choose one implementation or the other.

## Advice
* Let the class do only one thing.
* E.g. Account only takes care of the balance
* (a.k.a. Sigle Responsibility Principle - SRP)

## Consequences of separated responsibilities
* Each class is doing one thing.
* One new requirement means one new class will be added.
* New requirement doesn't require an existing class to change!

## Bad design 
* A class which is doing everything itself
* This typically leads to if-then-else instructions everywhere

## Better design
* Move separate implementations to separate *state* classes
* Substitute the *state* object to substitute implementation

## Benefits of the State pattern
* Class that uses states becomes simple
* It can focus on its primary role
* Other roles are delegated to concrete state classes
* Each concrete class is simple