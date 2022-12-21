# .NET 6 Apps
# Applied OOPs
	- Class
		- Encapsulation
			- Data is encapsulated
				- name, address, specific information to resource
			- Data Members
				- private or protected
		- ABstraction
			- Behavioral information aka operations aka methods
			- Properties
				- get, set
		- Inheritence
		- Polymorphism
	- Access Specifiers
		- public, private, proteted, internal, internal protected, 
	- Access Modifiers
		- static, abstract, sealed, virtual, override, new, readonly

# Standard Classes
- String
	- An Array of characters
- Char
	- A Strcuture that represents a single character
- TO Read and evauates each character of string using iteratios
	- for..loop
		- The Explicit length is needed 
	- foreach loop
		- The loops itsekf avances an execute till the end-of-array (or collection) is not reched
# Collection Framework
	- Data is stored in an organized manner
	- Array
		- Sizable Data Structure
	- Collections, System.Collections
		- No limit for storing data
		- Default to available memory
		- The data alloation is hanled using the type of Data Structure
			- ArrayList
			- Stack
			- Queue
			- LinkedList
			- SortedList

- Generics
	- .NET Frwk 2.0
	- TypeSafe Data Structures
	- System.COllections.Generics
		- List<T>
		- Stack<T>
		- LInkedList<T>
		- Queue<T>
		- HashSet<T>
		- Dictionary<K,V>
		-...
	- T is Template for which the binary Copy of the Generic Collection class will be created in memory 

# C# Programming FEatures
	- Delegate
		- It is used to invoke a method with its reference
			- The delegate MUST know an address of the method
			- The delegate acts as a 'Proxy' for the method
			- Object A can invoke a metod from Object B using Delegate
				- For A delegate is an method from Object B
		- It is used to invoke a method Asynchronously
		- Declare an Event
		- USed for Evaluating Expressions anonymousl, C# 3.0+
			- Lambda Expression
	- Event
		- A mechanism to geneate Notifications when "Something Happens"
			- If Objet A executes a logic and and generate a notfication to object B then, A must raise an event and B must subscribe to it 
	- Interfaces