// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
try
{

	Console.WriteLine("DEMO ADO.NET Conneted Architecture");
	// 1. Establish COnnetion With Database
	string connStr = "Data Source=.;Initial Catalog=Company;Integrated Security=SSPI";
	SqlConnection Conn = new SqlConnection(connStr);
	// 2. Open The Connection
	Conn.Open();

	// 3. Define COmmand Object and PAss Connection to it
	SqlCommand Cmd = new SqlCommand();
	Cmd.Connection = Conn;
	// An ALternative eay to define a Command Object
	//SqlCommand Cmd = Conn.CreateCommand();
	// 3.a. Set the Command Text Property to "Query" that perform CRUD Operations

	Cmd.CommandText = "Select * from Department";

	// 4. Execue the Command to Read Data from Database Server
	// THe SqlDataReader, is he fastest reader for data
	SqlDataReader Reader = Cmd.ExecuteReader();

	// 4.a. STart Reading Data from DataREader (Read-Only-Form-Ward-Only) Cursor
	while (Reader.Read())
	{
		// 4.a.1. REad data
		Console.WriteLine($"DeptNo: {Reader["DeptNo"]} DeptName: {Reader["DeptName"]} Capacity: {Reader["Capacity"]} Location: {Reader["Location"]}");
	}

	// 4.b. Close the Reader, do not keep it open
	// ** We can have 'only-one-reader-active' ata a time on the Connection
	Reader.Close();

	// Lets Insert

	Cmd.CommandText = $"Insert into Department Values (90, 'Testing', 800, 'Pune')";
	int result = Cmd.ExecuteNonQuery();
	if (result > 0)
	{
		Console.WriteLine("Insert is Successful");
	}


	// Last Step
	Conn.Close();	


}
catch (Exception ex)
{
	Console.WriteLine($"Error {ex.Message}");
}



Console.ReadLine();
