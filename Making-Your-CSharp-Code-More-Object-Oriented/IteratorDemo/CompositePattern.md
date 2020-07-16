### Composite: class diagram
* Compose a number of objects into a new object exposing the same public interface.
* Composite object looks like a single object
  * It can receive method calls just like a single object does

```plantuml
@startuml

package "Composite domain" #DDDDDD {

    class Component {
        void Operation()
    }

    class Leaf {
        void Operation()
    }

    class Composite {
        void Operation()
    }

    Component <|-- Composite
    Component <|-- Leaf
    Component "1" <--o "*" Composite : aggregation

}
@enduml
```