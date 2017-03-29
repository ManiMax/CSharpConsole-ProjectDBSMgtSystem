using System;

namespace College
{
	/// <summary>
	/// Student Class (Derived + Base) Definition: Properties and Attributes of Staff as class inherited from Person.
	/// Part of the B8IT117 Project Submission for John Mulhall, StudentID:10042622
	/// </summary>
    public class Staff:Person
    {
        //declare properties
        public int StaffID { get; set; }
        public double Salary { get; set; }
        public bool IsLecturer { get; set; }

        //default constructor
        public Staff() { }

        //overloaded constructor
        public Staff(string ppsNumber, string firstName, string lastName, string address1, string address2, string city, string postCode, string contactNumber,
            string email, int staffID, double salary, bool isLecturer ):base(ppsNumber, firstName, lastName, address1, address2, city, postCode, contactNumber, email) {
            StaffID = staffID;
            Salary = salary;
            IsLecturer = isLecturer;
        }
		//method 0 - override two string for staff details only
		public override string ToString()
		{
			return string.Format("[Staff: StaffID={0}, Salary={1}, IsLecturer={2}]", StaffID, Salary, IsLecturer);
		}

		//method 1 - overload base method for displaying of member lists 
		public virtual void DisplayListMembers()
		{
			Console.WriteLine("Staff Record Extract:");
			Console.WriteLine("");
			Console.WriteLine("StaffID: {0}", StaffID);
			Console.WriteLine("Salary: {0}", Salary);
			Console.WriteLine("IsLecturer: {0}", IsLecturer);
		}
    }
}
