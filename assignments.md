# Day 1 : Date:19-Dec-2022l 

1. Use the following string in your C# project
"The James Bond series focuses on a fictional British Secret Service agent created in 1953 by writer Ian Fleming, who featured him in twelve novels and two short-story collections. Since Fleming's death in 1964, eight other authors have written authorised Bond novels or novelisations: Kingsley Amis, Christopher Wood, John Gardner, Raymond Benson, Sebastian Faulks, Jeffery Deaver, William Boyd, and Anthony Horowitz. The latest novel is With a Mind to Kill by Anthony Horowitz, published in May 2022. Additionally Charlie Higson w*rote a series on a young James Bond, and Kate Westbrook wrote three novels based on the diaries of a recurring series character, Moneypenny.

The character—also known by the code number 007 (pronounced "double-oh-seven")—has also been adapted for television, radio, comic strip, video games and film. The films are one of the longest continually running film series and have grossed over US$7.04 billion in total at the box office, making it the fifth-highest-grossing film series to date, which started in 1962 with Dr. No, starring Sean Connery as Bond. As of 2021, there have been twenty-five films in the Eon Productions series. The most recent Bond film, No Time to Die (2021), stars Daniel Craig in his fifth portrayal of Bond; he is the sixth actor to play Bond in the Eon series. There have also been two independent productions of Bond films: Casino Royale (a 1967 spoof starring David Niven) and Never Say Never Again (a 1983 remake of an earlier Eon-produced film, 1965's Thunderball, both starring Connery). In 2015, the series was estimated to be worth $19.9 billion in total (based on box-office grosses, DVD sales and merchandise tie-ins),[1] making James Bond one of the highest-grossing media franchises of all time." An email of Mr. Bond is jamesb@mi16.com 

Perform FOllwing opertions on it
	- Count number of Statements in the string
	- Count number of Words in string
	- Count number of digits in string
	- Count number of speial characters in string
	- Count number of 'is', 'are' in string
	- Convert the string into word case, means first character of each word in upper case
	- Find out a number in string that represents an year
	- COnvert entire string in Upper and lower case

# Day 2: Date:20-Dec-2022
1. Modify the CS_Inheritence project by adding the Driver class from Staff class with properties like Allowance, overtime, MinNumberOfTrips.
2. Modify the StaffLogic class by adding following abstract methods
	- UpdateStaff(Staff staff)
	- DeleteStaff(Staff staff)
3. Add a DriverLogic class derived from the StaffLogic class to implemenet all methods for StaffLogi class
4. Create a class UILogic, this class will contain methods for
	- Register New Staff, Update, Delete Staff
	- This class will also have following methods to read data form StaffDb class 
		- ReadStaffByType(string staffType)
			- Here the value of the staffType will be 'Doctor' , 'Nurse', 'Driver' and the method should return only the matching type staff from StaffDb 
		- SortStaffByName()
			- THis should sort all Staff
5. Create an instance of UI class in Program.cs to show result.

# Day 3: Date:21-Dec-2022

1. Create Extension methods for String Operations those are mentioned in Lab  of Day 1
2. Print Second MAx Salary and EMpNAme for Employee
3. Print Second MAx Salary and EmpName for Each Department
4. Print First Record for Each Designation
5. Print All Employees Group by DeptName as follows
	- DeptName: {{NAME}}
		- EmpNo	EMpNAme Salary	Designation

# Day 4: Date:22-Dec-2022
1. CReate a Salary Slip for Each Staff min 100 REcords
	- First Calculate Salary as
		- Basic
		- Perform Calculations for Doctors, NUrses, and Drivers
	- CReate a Salaryslip as a File .txt for each Staff as 
		- [STaffId]-[Name]-[Date].txt
	- The Salary Calculation MUST be executed as Parallel

# Day 5: Date:23-DEc-2022

1. Copy Files in seperate folders as per an extension using Continue Tasks