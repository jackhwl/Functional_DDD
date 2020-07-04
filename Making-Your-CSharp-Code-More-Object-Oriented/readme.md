# Foundations of OO programming
  * *this* pointer
  * ynamic dispatch
## Understanding *this* pointer
  * Silently passed with a call to an instance-level function
    *  Function then operates on an object
  * Bringing operations close to data
    *  No more global functions; 
    *  Operations have become the quality of data structures
## Understanding Dynamic dispatch
  * Object's duty
    *  To carry data abount its type
  * Type's duty
    *  To keep track of its virtual functions table
    *  To override some functions from its base type 
  * Runtime's duty
    *  Jump in when call is placed on an object
    *  Find V-table of its generating type
    *  Find concrete function address
## From Structured to OO Languages
  * It is possible to write OO code in a structured language (like C)
  * It is possible to write assembler macros to make it OO
  * It is not only the programming language
    * Object orientation is the shift in thinking
  * C++ and Objective C
    * Mixing paradigms
    * Structured and OO at the same time
  * Java and C#
    * Object-oriented straight-up
    * Still support structured programming practices
## Shifting Your Mind to Become Object-oriented
  * Code
    * We are still surrounded by structured code
    * Code often looks like plain C
  * Textbooks
    * Still explain concepts through structured examples
  * Programmers
    * Becoming object-oriented required a change
## Why so Much Non-OO Code Today?
  * It takes deep understanding to start using OO concepts
  * It's not just Encapsulation-Abstraction-Inheritance-Polymorphism
## Start Thinking in Terms of OO Principles
  * Define objects
    * Which data goes with which operations?
  * Use polymorphism
    * Which operations require dynamic dispatch?
  * Bring life to objects
    * Let operations be determined dynamically
    * Substitute objects to modify behavior
## Deep Understanding of OO Programming
  * *this* pointer and dynamic dispatch
    * These are the engine of OO
  * Inheritance, abstract types, generic types, exceptions...
    * These are syntactical additions
