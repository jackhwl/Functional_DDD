### Composite: class diagram
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