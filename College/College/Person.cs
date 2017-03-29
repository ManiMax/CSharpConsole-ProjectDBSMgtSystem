using System;
using System.IO;

namespace College
{
    public class Person
    {
		/// <summary>
		/// Person Class (Base) Definition: Defining base person properties and methods supporting the DBS Program. 
		/// Part of the B8IT117 Project Submission for John Mulhall, StudentID:10042622
		/// </summary>
        //declare properties
        public string PPSNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

		//declare variables
		string personRecordFile = "personRecordFile";
        Person recordList;

        //default constructor
        public Person() { }

        //overloaded constructor
        public Person(string ppsNumber, string firstName, string lastName, string address1, string address2, string city, string postCode, string contactNumber,
            string email)
        {
            PPSNumber = ppsNumber;
            FirstName = firstName;
            LastName = lastName;
            AddressLine1 = address1;
            AddressLine2 = address2;
            City = city;
            PostCode = postCode;
            ContactNumber = contactNumber;
            Email = email;
        }

        //Method 1 - override ToString() with list return
        public override string ToString()
        {
			return string.Format("Member List is: {0}\n", recordList);
        }

        //method 2 - display all members in the staff list (using ToString())
        public void DisplayListMembers(Person recordList)
        {
            Console.WriteLine("Member List:");
            Console.WriteLine("*************");
            Console.WriteLine(recordList);
        }

        //method 3 - base save method for object lists
        public virtual void SaveMemberList()
		{
			if (File.Exists(personRecordFile))
			{
				File.Delete(personRecordFile);
				Console.WriteLine("Note: Old member file successfully deleted");
			}
			StreamWriter fileWriter = new StreamWriter(personRecordFile);
			Console.WriteLine("Note: Person Member list successfully saved. \nObject Ref: {0}", personRecordFile);
			fileWriter.Close();
		}
		//method 4 - base retrieve method for object lists
		public virtual void RetrieveMemberList()
		{
			using (StreamReader fileReader = File.OpenText(personRecordFile))
			{
				string readFile = "";
				readFile = fileReader.ReadToEnd();
				Console.WriteLine("Successfully retrieved lecturer filestore contents: {0}", personRecordFile);
				fileReader.Close();
			}
		}
	}
}
