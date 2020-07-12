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


### uml: class diagram
```plantuml
@startuml
package "Account domain" #DDDDDD {
    class Account0 {
        bool IsVerified
        bool IsClosed
        bool IsFrozen
        void Deposit(decimal amount)
        void Withdraw(decimal amount)
        void HolderVerified()
        void Freeze()
        void Close()
    }

    class Account {
        IAccountState State
        void Deposit(decimal amount)
        void Withdraw(decimal amount)
        void HolderVerified()
        void Freeze()
        void Close()
    }

    interface IAccountState {
        void Deposit(Action addToBalance)
        void Withdraw(Action subtractFromBalance)
        void HolderVerified()
        void Freeze()
        void Close()
    }

    class NotVerified {

    }

    class Active {

    }

    class Frozen {

    }

    class Closed {

    }

    IAccountState <|-- NotVerified
    IAccountState <|-- Active
    IAccountState <|-- Frozen
    IAccountState <|-- Closed
    IAccountState <-- Account
}
@enduml
```