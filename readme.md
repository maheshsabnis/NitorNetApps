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
		- Like Abstrat classes interfaces are also used to share standardization of method declarations across various classes
		- Class can implement Multiple Interfaces
			- When a class implement an interface then all methods of interface MUST be implemeneted by class
			- It is recommended that the class should implement interface 'explicitly'
				- The class provides definition for methods but they are 'OWNED by' interface
			- Such a class can be instantiated using interface reference(?)
				- e.g.
					- I1 is interface
					- C1 is class
				- C1:I1	
					- Define instance
						- I1 i = new C1();
							- i is reference of I1 that points to memory for C1
			- I1, M1(), M2()
			- I2, M3(), M4()
			- C2:I1, I2
				- C2 MUST implement M1, M2,M3, and M4
			- When C2 instance is declare using I1
				- I1 obj1 = new C2();
					- Then obj1 will have access to M1 and M2 only
				- I2 obj2 = new C2()
					- obj2 will access M3 and M4 only

- Extension Methods
	- Rules:
		- The Class that defines an extension method MUST be static
		- The Method that acts as an etension method MUST be static
		- THe first parameter of the method MUST be 'this' referred reference of the class / interface for which this method will act as an extension method
- Generic COllections
	-  USe Language Integrated Queries (LINQ)
		- Expressions that uses
			- Extension Methods
				- Where, Select, OrderBy, Group By, Join, etc.
			- Lambda Expressions
				- Stadandard Delegates
					- Fucn<>
					- Action
					- Predicate
			- OPerators
				- Take, Skip, First, FirOrDEfault. etc.
			- Aggrigate Methods
				- Sum, Min, Max, etc.s
		- Declarative LINQ
			- A Query Expression using Extension Methods and Lambda Expression
		- Imperative Query
			- Keywords Like SQL Query 
			- Keywords
				- select, where, orderby, groupby, etc.

# THreading
	- AN Approach of performing follwing operations in apps
		- Simulteneous Execution
			- Case 1: Multiple methods are executed on seperate threads, these methods will not share common data and has an independent Execution
			- Case 2: The common object (resource) is shared across multiple threads
				- Acquire Exclusive Lock on Resource 
		- Thread class
			- Start()
			- Abort()
			- Join()
		- ThreadStart Delegate
		- ParameterizedThreadStart Delegate
		- Thread t = new Thead(()=>{.....}); For ThreadStart
		- Thread t = new Thread((x,y)=>{....}); For ParameterizedThreadStart
		- PLan for Returning Value from THread
			- Generaly use 'Join()' to receive data from thread
		- MAke sure that the Exception Handling is on place
		- THread SYnchronization using following
			- 'lock', an object that allows only one thread to acquire resource control and rest all thares will be in wainting
			- Monitor
			- Mutex


			- Parallel Execution
				- .NET FRwk 4.0
					- Parallel
						- Invke(()=>{....... all parallel Operations.....})
						- For()
						- ForEach()
					- Task
						- UNit of Async OPerations
							- Start()
							- Run()
							- FActory
							- COntinueWith()

			- Asynchronous Execution
				- .NET 4.5 +
					- Async Methods for all UnManaged Resurces(?)
		
- Task
	- Unit of Async OPerations
	- CReate and Manage THread Explicitly
	- Offering
		- Create a Single Task as a FActory	
			- Task.Factory.StartNew(()=>{.......LOGIC........});
				- CReate a THread and STart it
				- Manage Execution
				- Lose /  Terminate it
		- Wait()
			- Wait for a Task to Complete
		- WaitAll(t1,t2,.....)
			- wait for making sure that mentioned tasks in method are completed
		- WaiAny()
			- make a choice to complete a specific task
		- ContinueWith()
			- Move across Tasks
			- When the previous task is over move to next task, also can carry output of first to next task
			- Use this as a replacement o BAckground THread
	- Task can be input and output parameter to method
		- If the method returns task object then to process an execution of the method from caller we use async/await programming pattern (.NET 4.5, C# 5.0)
		- In .NET and method ends with 'Async()' that returns a TAsk object
			- The caller method MUST be decorated with access modifier as 'async' and the method aller MUST be applied with 'await'
			- e.g.
				- Connect to Database
				- public async void GetDbConnecitonAsync()
				{
					// conn  is an instance of Connection class
					await conn.OpenAsync();
				}

# ADO.NET Disconnected Architecture
1. DataSet
	- Stored data in XML Format
	- Typed DataSet and UnTyped DataSet
		- TYpedData has TAble COlumns with COnstraints e.g. Primary Key, FOreign Key, etc
		- UnTyped DataSet on has the Table Schema and No COnstraints
2. Connect to Database
3. Declare DataAdapter
	- Pass the "Plain Select STatement" and "Connection" object to it
4. Define DataSet Instance
	- DataSet Ds = new DataSet()
5. Fill Data into the DataSet
	- Adapter.MIssingSchemaAction = MissingSchemaAction.AddWithKey;
		- THis will read table with its COnstraints (Typed DataSet)
	- Adapter.Fill(DataSet, "TABLE-NAME")
	- REad Data and its Schema from DataSet in Xml FOrmat
		- DataSet.GetXml()
		- DataSet.GetXmSchema()
		- DataSet.ReadXml()
			- Read an Xml file and fill data into dataset from Xml Filde
		- DataSet.WriteXml()
			- Create Xml file that will contains data from DataSet
6. Object Model For DataSet
	- COnsider Ds is an instace of DataSet
		- Ds.Tables
			- Return DataTAbleCollection
		- Ds.Tables[INDEX | TABLE-NAME]
			- Return an instance of DataTable
		- Ds.Tables[INDEX | TABLE-NAME].Columns
			- Return an instance of DataCOlumnCollection
		- Ds.Tables[INDEX | TABLE-NAME].COlumns[INDEX | NAME-OF-COLUMN]
			- Return an instance of DataColumn
		- Ds.Tables[INDEX | TABLE-NAME].Rows
			- Return an instance of  DataRowCollection
		- Ds.Tables[INDEX | TABLE-NAME].Rows[INDEX]
			- Retunr a DataRow object
7. To REad a Row from Table BAsed on Primary Key
	- From Typed DataSet
		- Ds.Tables[INDEX | TABLE-NAME].Rows.Find("PRIMARY-KEY-VALUE");
	- From Untyped DataSet
		- Define a Untique columns fpr TAble
			- Ds.Tables[INDEX | TABLE-NAME].Columns[INDEX | COUMN-NAME].Unique = true
		- Make it as Not Null
			- Ds.Tables[INDEX | TABLE-NAME].Colums[INDEX | COLUMN-NAME].AllowDbNull = false;
		- TAke an array of dataclumns of all such colums			
			- DataCOlumns [] dc = new DataCOlumns[]{ Ds.Tables[INDEX | TABLE-NAME].Colums[INDEX | COLUMN-NAME]}
		- Make this array as Primary Key	
			-  Ds.Tables[INDEX | TABLE-NAME].PrimaryKey = dc;
		- Finally search ro based on Primary Key
			- Ds.Tables[INDEX | TABLE-NAME].Rows.Find("PRIMARY-KEY-VALUE");
8. Add a new Recrd in DataSet
	- FIrst Create an new row object
		- DataRow dr = Ds.Tables[INDEX | TABLE-NAME].NewRow();
	- Set COumns values for this new row
		- dr[IDNEX | COLUMN-NAME] = value;
	- Add this New row in the rows collection of the Table
		- Ds.Tables[INDEX | TABLE-NAME].Rows.Add(dr);
	- Define a Command Buider and pass adapter to it
		- SqlCommandBuilder bldr = new SqlCommandBuilder(Adapter);
	- Call Update Methd of the Adapter to Update data from DataSet to Database Server
		- Adapter.Update(DataSet, "TABLE-NAME");
9. To Update
	- Search REcord based on Primary Key (As per section 7)
		- DataRow DrUdate = Ds.Tables[INDEX | TABLE-NAME].Rows.Find("PRIMARY-KEY-VALUE");
	- Update Row Vaues
		- DrUpdate[INDEX | COLUMN-NAME] = values
	- USe COmand Builder
	- Adapter Update (Refer Section 8)
10.To Delete Record
	- Search Record (Section 7)
	- SearchedRwcord.Delete();
	- USe Command Builder and Adapater (Refer Section 8)