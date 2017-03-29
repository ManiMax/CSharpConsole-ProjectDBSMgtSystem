using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Collections;

namespace College
{
    public class Lecturer:Staff, IProcessList, IEnumerable<object>
    {
		/// <summary>
		/// Lecturer Class (Derived) Definition: Inherited from Staff class, attributes and methods for Lecturer specific entries are processed here.
		/// Part of the B8IT117 Project Submission for John Mulhall, StudentID:10042622.
		/// </summary>

		//declare class variable
		bool writeToObject = true;
		public bool testLecturerSearchResult;

		//Declare and initialise class member arraylist
		List<object> lecturerRecords = new List<object>();
		List<object> lecturerRecordStore = new List<object>(); //persistent printable master listt
		List<object> searchLecturerStore = new List<object>(); //persistent searchable master list

        //Declare Properties 
        public string SubjectsTaught { get; set; }
		Lecturer memberList { get; set; }
		string lecturerRecordFile = "lecturerRecordFile";
		string searchLecturerRecordFile = "searchLecturerRecordFile";

        //default contstructor
        public Lecturer() { }

        //overloaded constructor
        public Lecturer(string ppsNumber, string firstName, string lastName, string address1, string address2, string city, string postCode, string contactNumber,
            string email, int staffID, double salary, bool isLecturer, string subjectsTaught):base(ppsNumber, firstName, lastName, address1, address2, city, postCode, 
                contactNumber, email, staffID, salary, isLecturer)
        {
			SubjectsTaught = subjectsTaught;
			memberList = new Lecturer();
        }

		//method o - helper method - get enumerator (used for checking of prior entry duplicates)
		private IEnumerable<object> Events() 
		{
			yield return memberList;
		}
		public IEnumerator<object> GetEnumerator() 
		{
			return Events().GetEnumerator();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		//method 0a - helper method - override ToString() to get lecturer printout format 
        public override string ToString()
		{
			return string.Format("\nRecorded Lecturer Name: {0} {1}", FirstName, LastName);
		}

        //method 1 - add lecturer to a list (overload staff class method)
        public List<object> InputMemberList()
        {
			try
			{
				//declare local variables
				string input = "", confirm = "y";
				bool isValid;
				double salary = 0.0;
				int staffID = 0;

				//run method
				while (PPSNumber == null || PPSNumber == "")
				{
					Console.WriteLine("PPS Number: Please enter the lecturer's PPS Number Now");
					PPSNumber = Console.ReadLine().ToUpper().Trim();
				}
				Console.WriteLine("First Name: Please enter First Name");
				FirstName = Console.ReadLine().Trim();
				Console.WriteLine("Last Name: Please enter the Last Name");
				LastName = Console.ReadLine().Trim();
				Console.WriteLine("Address First Line: Enter address line 1");
				AddressLine1 = Console.ReadLine().Trim();
				Console.WriteLine("Address Second Line: Enter address line 2 now");
				AddressLine2 = Console.ReadLine().Trim();
				Console.WriteLine("City: Enter city name now");
				City = Console.ReadLine().Trim();
				Console.WriteLine("Post Code: Enter the post code now");
				PostCode = Console.ReadLine().Trim();
				Console.WriteLine("Contact Number: Enter contact Number now");
				ContactNumber = Console.ReadLine().Trim();
				Console.WriteLine("Email: Enter email address now");
				Email = Console.ReadLine().Trim();
				Console.WriteLine("Staff ID: Enter (staff) member ID now"); //to be parsed in below lines
				input = Console.ReadLine().Trim();
				isValid = int.TryParse(input, out staffID);
				StaffID = staffID;
				input = "";
				Console.WriteLine("Salary: Enter staff salary now (per annum)");
				input = Console.ReadLine().Trim();
				isValid = double.TryParse(input, out salary);
				Salary = salary;
				input = "";
				Console.WriteLine("Is this staff member a lecturer, press y (and return) to confirm. \nOtherwise, press any other key to continue");
				input = Console.ReadLine().Trim();
				if (input == confirm)
				{
					IsLecturer = true;
					Console.WriteLine("What subjects does this lecturer teach? (seperate subjects with comma)");
					SubjectsTaught = Console.ReadLine().Trim();
				}
				else
				{
					IsLecturer = false;
					SubjectsTaught = "No Subjects Thought. Reason: Not a Lecturer";
					Console.WriteLine("Please note only lectuerers should be added in this area. \nPlease retry using option 1 (add student)");
				}
				Console.WriteLine("");
				Console.WriteLine("Thank you, do you want to add this record to lecturer store? y/n");
				input = Console.ReadLine();
				//add loaded proprties to file store
				if (input == "" || input.Trim() == "n")
				{
					Console.WriteLine("Note: Record not added to file store");
					writeToObject = false;
					IsLecturer = false;
				}
				else 
				{
					lecturerRecords.Add(PPSNumber);
					lecturerRecords.Add(FirstName);
					lecturerRecords.Add(LastName);
					lecturerRecords.Add(AddressLine1);
					lecturerRecords.Add(AddressLine2);
					lecturerRecords.Add(City);
					lecturerRecords.Add(PostCode);
					lecturerRecords.Add(ContactNumber);
					lecturerRecords.Add(Email);
					lecturerRecords.Add(StaffID);
					lecturerRecords.Add(Salary);
					lecturerRecords.Add(IsLecturer);
					lecturerRecords.Add(SubjectsTaught);
				}
				foreach (var member in lecturerRecords) {
					Console.WriteLine("LecturerRecord Entry Pending Approval: {0}", member);
                }
            }
            catch (SystemException se) {
                Console.WriteLine("Something went wrong, error details are: {0}", se.Message);
            }
			return lecturerRecords;
        }

		//method 1a - add member object from list 
		public Lecturer AddMemberAsObject()
		{
			try
			{
				memberList = new Lecturer();
				//Assign by element from object to list for printable .element objects (ToString() override)
				if ((SubjectsTaught != "") & ((IsLecturer == true) & (writeToObject == true)))
				{
					memberList.PPSNumber = PPSNumber;
					memberList.FirstName = FirstName;
					memberList.LastName = LastName;
					memberList.AddressLine1 = AddressLine1;
					memberList.AddressLine2 = AddressLine2;
					memberList.City = City;
					memberList.PostCode = PostCode;
					memberList.ContactNumber = ContactNumber;
					memberList.Email = Email;
					memberList.StaffID = StaffID;
					memberList.Salary = Salary;
					memberList.IsLecturer = IsLecturer;
					memberList.SubjectsTaught = SubjectsTaught;
				}
				else 
				{
					Console.WriteLine("Record write to memory failed");
				}
			}
			catch (SystemException se)
			{
				Console.WriteLine("Something went wrong with input, error message is {0}", se.Message);
			}
			return memberList;
		}

		//method 1b - add student record list items to private student sorted list by parsed student number. Called from method 1b
		public void AddRecordEntryToSearchList()
		{
			if (writeToObject == false)
			{
				Console.WriteLine("Record write to searchLecturerStore list has failed. Invalid entry detected");
			}
			else
			{
				if (StaffID == 0)
				{
					Console.WriteLine("Record write to searchLecturerStore has failed, empty or alpha number (lecturer) number is invalid");
					Console.WriteLine("Note: This record is not searchable");
				}
				else {
					foreach (object record in lecturerRecords)
					{
						searchLecturerStore.Add(record);
					}
					lecturerRecords.Clear();
				}
			}
		}

		//method 1c - update main List<object> with object from method 1a
		public void UpdateMasterMemberList()
		{
            try
            {
                memberList = AddMemberAsObject();
                if (memberList == null || memberList.Equals(memberList.Last()))
                {
                    Console.WriteLine("Record skipped: null and/or duplicate entry");
                }
                else
                {
                    lecturerRecordStore.Add(memberList);
                }
                DisplayListMembers();
            }
            catch (NullReferenceException ne)
            {
                Console.WriteLine("Oh dear, something went wrong, please revise and retry. Error details are: {0}", ne.Message);
            }
		}

		//method 2 -  SearchLecturer on using searchable master list
        public void SearchMemberList(string searchTerm)
		{
			try
			{
				//declare local variables
				int count = 0, foundCount = 0, loadCount = 0;
				bool foundRecord = false;

				//run method routine
				foreach (object record in searchLecturerStore)
				{
					if (searchTerm.Trim() == "")
					{
						Console.WriteLine("Empty search term submitted, abandoning record search...");
						break;
					}
					if (record.ToString() == searchTerm)
					{
						Console.WriteLine("Matched the following record:");
						Console.WriteLine("********************************************");
						Console.WriteLine("Record successfully retrieved");
						Console.WriteLine("Printing recorded name for referenced (Lecturer) PPS number {0}:", record);
						Console.WriteLine("****************Search Results********************");
						Console.WriteLine("**************************************************");
						foreach (object line in searchLecturerStore)
						{
							if ((count == foundCount) || (foundCount > count))
							{

								Console.WriteLine("PPS Reference: {0} | Record Detail: {1}", searchTerm, line);
								loadCount++;
								if (loadCount == 3) { break; }
							}
							foundCount++;
						}
						Console.WriteLine("***************************************************");
						foundRecord = true;
						testLecturerSearchResult = true;
					}
					count++;
				}
				if (foundRecord == false)
				{
					Console.WriteLine("");
					Console.WriteLine("PPS Number {0} returned zero (Lecturer) results", searchTerm);
				}
				Console.WriteLine("");
			}
			catch (NullReferenceException ne)
			{
				Console.WriteLine("You dont have any search records populated, please input member details and try again. \nError Details: {0}", ne.Message);
			}
			catch (ArgumentException ae)
			{
				Console.WriteLine("Oh dear, something went wrong, please revise and retry. Error details are: {0}", ae.Message);
			}
		}

		//method 3 - save Member List to I/O - specific to lecturers - override base SaveMemberList()*
		public override void SaveMemberList()
		{
			try
			{
				string input = "";
				Console.WriteLine("Do you want to delete existing record store: lecturerRecordFile? y/n");
				input = Console.ReadLine().Trim();
				if (input == "y")
				{
					File.Delete("lecturerRecordFile");
					File.Delete("searchLecturerRecordFile");
					Console.WriteLine("Note: Old lecturer files successfully deleted");
				}
				StreamWriter fileWriter = new StreamWriter("lecturerRecordFile", true);
				foreach (object record in lecturerRecordStore)
				{
					fileWriter.WriteLine(record);
				}
				Console.WriteLine("Note: Printable lecturer member file successfully saved");
				fileWriter.Close();
				//searchable file read/write
				StreamWriter searchableFileWriter = new StreamWriter("searchLecturerRecordFile", true);
				foreach (object line in searchLecturerStore)
				{
					searchableFileWriter.WriteLine(line);
				}
				Console.WriteLine("Note: Searchable lecturer member file successfully updated");
				searchableFileWriter.Close();
			}
			catch (IOException io)
			{
				Console.WriteLine("Oh dear, something went wrong with the lecturer file retrieve process. Error details are {0}", io.Message);
			}
			catch(NullReferenceException ne)
			{
				Console.WriteLine("Oh dear, something went wrong with the lecturer file update and save process. Error details are {0}", ne.Message);
			}
		}

		//method 4 - retreive member list from I/O -  Override base class version
		public override void RetrieveMemberList()
		{
			try
			{
				string readFile = "";
				if (lecturerRecordFile == null)
				{
					Console.WriteLine("No lecturer file found. Please revise and try again");
				}
				else
				{
					using (StreamReader fileReader = File.OpenText(lecturerRecordFile))
					{
						readFile = fileReader.ReadToEnd();
						lecturerRecordStore.Clear();
						lecturerRecordStore.Add(readFile);
						Console.WriteLine("Successfully retrieved lecturer filestore contents:");
						fileReader.Close();
					}
				}
			}
			catch (IOException io)
			{
				Console.WriteLine("Oh dear, something went wrong with the lecturer file retrieve process. Error details are {0}", io.Message);
			}
			catch (NullReferenceException ne)
			{
				Console.WriteLine("Oh dear, something went wrong with the lecturer file retrieve process. Error details are {0}", ne.Message);
			}
		}

		//method 4a - retreive searchable list save from I/O
        public void RetrieveSearchMemberList()
		{
			string searchableReadFile = "";
			try
			{
				if (searchLecturerRecordFile == null)
				{
					Console.WriteLine("No searchable student file found. Please revise and try again");
				}
				else
				{
					searchLecturerStore.Clear();
					using (StreamReader searchableFileReader = File.OpenText(searchLecturerRecordFile))
					{
						while ((searchableReadFile = searchableFileReader.ReadLine()) != null)
						{
							if (searchableReadFile != "")
							{
								searchLecturerStore.Add(searchableReadFile);
							}
						}
					}
				}
			}
			catch (IOException io)
			{
				Console.WriteLine("Oh dear, something went wrong with the student file retrieve process. Error details are {0}", io.Message);
			}
			catch (NullReferenceException ane)
			{
				Console.WriteLine("Oh dear, something went wrong with the student file retrieve process. Error details are {0}", ane.Message);
			}
		}

		//method 5 - (helper method) display all lecturer names from current list (overrides base method (staff) and overrides ToString() for format display per spec)
		public override void DisplayListMembers()
		{
			if (IsLecturer == true)
			{
				Console.WriteLine("**************************");
				Console.WriteLine("Lecturer record saved as: \n{0}", memberList);
				Console.WriteLine("");
			}
			else {
				Console.WriteLine("No lecturer records found for display. Please revise and try again");
			}
        }

		//method 6 - print out all objects loaded into the record store
		public void PrintAllLecturers() {
			Console.WriteLine("");
			Console.WriteLine("***Lecturer Master List Printout***");
			if (lecturerRecordStore == null | lecturerRecordFile == "")
			{
				Console.WriteLine("No student records found, please try again");
			}
			else
			{
				foreach (object member in lecturerRecordStore)
				{
					Console.WriteLine(member);
				}
			}
			Console.WriteLine("");
		}
    }
}

