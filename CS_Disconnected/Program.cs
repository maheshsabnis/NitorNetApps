// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Demo Disconnected");
SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
// define adapter
SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Department", Conn);
SqlDataAdapter AdEmp = new SqlDataAdapter("Select * from Employee", Conn);
// Define DataSet
DataSet Ds = new DataSet();
// Make Suer that the TYped DataSet is Created with Primary Key
AdDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
AdEmp.MissingSchemaAction= MissingSchemaAction.AddWithKey;
// Fill ata in DataSet
AdDept.Fill(Ds, "Department");
AdEmp.Fill(Ds,"Employee");
// Data in Xml
//Console.WriteLine(Ds.GetXml());
// Get XmlSchema 
//Console.WriteLine(Ds.GetXmlSchema());

#region Add New Record in Department Table of DataSet
//// a. New Record
//DataRow Dr = Ds.Tables["Department"].NewRow();
//// b. Set it values
//Dr["DeptNo"] = 90;
//Dr["DeptName"] = "Test";
//Dr["Capacity"] = 500;
//Dr["Location"] = "Pune";
////c. Add Rwo in DataSet Table COllection for Deparment TAble
//Ds.Tables["Department"].Rows.Add(Dr);
//// d. Send data back to Database
//SqlCommandBuilder builder = new SqlCommandBuilder (AdDept);
//AdDept.Update(Ds,"Department");

#endregion

#region Update
try
{
	// a Serach
	DataRow DrFind = Ds.Tables["Department"].Rows.Find(90);
	// b. chagnge columns value for the row
	DrFind["DeptName"] = "Automated Tests";
	// c. Update
	SqlCommandBuilder builder = new SqlCommandBuilder(AdDept);
	AdDept.Update(Ds, "Department");
}
catch (Exception ex)
{

	throw;
}
#endregion

#region Delete
//// a Serach
//DataRow DrDelete = Ds.Tables["Department"].Rows.Find(90);
//// b. delete
//DrDelete.Delete();


////// c. Update
//SqlCommandBuilder builder1 = new SqlCommandBuilder(AdDept);
//AdDept.Update(Ds, "Department");
#endregion

Console.ReadLine();
