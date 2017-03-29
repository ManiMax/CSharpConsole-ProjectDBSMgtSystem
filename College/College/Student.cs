using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Collections;

namespace College
{
    public class Student : Person, IProcessList, IEnumerable<object>
    {
        /// <summary>
        /// Student Class (Derived) Definition: Inherited from Person class, attributes and methods for student specific entries are processed here.
        /// Part of the B8IT117 Project Submission for John Mulhall, StudentID:10042622
        /// </summary>

        //declare class variable
        bool writeToObject = true;
        public bool testStudentSearchResult; //for test class only

        //declare/initialise ArrayList/Objects for student records
        List<object> studentRecords = new List<object>();
        List<object> studentRecordStore = new List<object>(); //master list object
        List<object> searchStudentStore = new List<object>(); //searchable store list for search function

        //declare properities
        public int StudentID { get; set; }
        public string Status { get; set; }
        Student memberList { get; set; }
        string studentRecordFile = "studentRecordFile";
        string searchStudentRecordFile = "searchStudentRecordFile";

        //default constructor
        public Student() { }

        //overloaded constructor
        public Student(string ppsNumber, string firstName, string lastName, string address1, string address2, string city, string postCode, string contactNumber,
            string email, int studentID, string status) : base(ppsNumber, firstName, lastName, address1, address2, city, postCode, contactNumber, email)
        {
            //assign class properites
            StudentID = studentID;
            Status = status;
            memberList = new Student();
        }

        //Method Helper 0 - Helper methods to set up and return ienumerator for object iteration
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

        //method Helper (1,3)0a - Override ToString for method 3 to print as required;
        public override string ToString()
        {
            return string.Format("\n*************** \nStudent Details \n*************** " +
                                 "\nStudent PPS Number: {0} \nStudent Name: {1} {2} \nStudent Address: {3}, {4}, {5}, {6} " +
                                 "\nStudent Contact Number: {7} \nStudent Email: {8} \nStudent ID: {9} \nStudent Status: {10} " +
                                 "\n***************",
                PPSNumber, FirstName, LastName, AddressLine1, AddressLine2, City, PostCode, ContactNumber, Email, StudentID, Status);
        }

        //method 1 - add students to object, then to memberList
        public List<object> InputMemberList()
        {
            try
            {
                //declare variables
                string input = "";
                bool isValidID;
                int studentID = 0;

                //run method routine
                while (PPSNumber == null || PPSNumber == "")
                {
                    Console.WriteLine("PPS Number: Please enter the member PPS Number Now");
                    PPSNumber = Console.ReadLine().ToUpper().Trim();
                }
                Console.WriteLine("First Name: Please enter First Name");
                FirstName = Console.ReadLine().Trim();
                Console.WriteLine("Last Name: Please enter the Last Name");
                LastName = Console.ReadLine().Trim();
                Console.WriteLine("Address First Line: Thank you, now enter address line 1");
                AddressLine1 = Console.ReadLine().Trim();
                Console.WriteLine("Address Second Line: Enter address line 2 now");
                AddressLine2 = Console.ReadLine().Trim();
                Console.WriteLine("City: Enter city now");
                City = Console.ReadLine().Trim();
                Console.WriteLine("Post Code: Enter post code now");
                PostCode = Console.ReadLine().Trim();
                Console.WriteLine("Contact Number: Enter contact number now");
                ContactNumber = Console.ReadLine().Trim();
                Console.WriteLine("Email: Enter email address now");
                Email = Console.ReadLine().Trim();
                Console.WriteLine("Student ID: Enter (student) member ID now"); //to be parsed in following lines
                input = Console.ReadLine().Trim();
                isValidID = int.TryParse(input, out studentID);
                StudentID = studentID;
                input = "";
                Console.WriteLine("Student Status: Enter student status now (ug/undergrad/pg/postgrad)");
                input = Console.ReadLine().Trim();
                if ((input.ToLower() == "undergrad") || (input.ToLower() == "undergraduate") || ((input.ToLower() == "ug") || input.ToLower() == "undergradutes"))
                {
                    Status = "Undergraduate";
                }
                else if ((input.ToLower() == "postgrad") || (input.ToLower() == "postgraduate") || ((input.ToLower() == "pg") || input.ToLower() == "postgradutes"))
                {
                    Status = "Postgraduate";
                }
                else
                {
                    Status = "Undeclared Student Type";
                }
                input = "";
                Console.WriteLine("Thank you, do you want to add this record to student store? y/n");
                input = Console.ReadLine();
                //Assign by element from object to list for searchable .element objects 
                if (input.Trim() == "n" || input == "")
                {
                    Console.WriteLine("Note: Record not added to file store");
                    writeToObject = false;
                }
                else
                {
                    studentRecords.Add(PPSNumber);
                    studentRecords.Add(FirstName);
                    studentRecords.Add(LastName);
                    studentRecords.Add(AddressLine1);
                    studentRecords.Add(AddressLine2);
                    studentRecords.Add(City);
                    studentRecords.Add(PostCode);
                    studentRecords.Add(ContactNumber);
                    studentRecords.Add(Email);
                    studentRecords.Add(StudentID);
                    studentRecords.Add(Status);
                }
                foreach (object member in studentRecords)
                {
                    Console.WriteLine("StudentRecord Entry Pending Approval: {0}", member);
                }
            }
            catch (SystemException se)
            {
                Console.WriteLine("Something went wrong with input, error message is {0}", se.Message);
            }
            return studentRecords;
        }

        //method 1a - add member object from list
        Student AddMemberAsObject()
        {
            try
            {
                if (writeToObject == true)
                {
                    //Assign by element from object to list for printable .element objects (ToString() override)
                    memberList = new Student();
                    memberList.PPSNumber = PPSNumber;
                    memberList.FirstName = FirstName;
                    memberList.LastName = LastName;
                    memberList.AddressLine1 = AddressLine1;
                    memberList.AddressLine2 = AddressLine2;
                    memberList.City = City;
                    memberList.PostCode = PostCode;
                    memberList.ContactNumber = ContactNumber;
                    memberList.Email = Email;
                    memberList.StudentID = StudentID;
                    memberList.Status = Status;
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
                Console.WriteLine("Record write to searchStudentStore list has failed. Invalid entry detected");
            }
            else
            {
                if (StudentID == 0)
                {
                    Console.WriteLine("Record write to searchStudentStore has failed, empty or alpha number (student) number is invalid");
                    Console.WriteLine("Note: This record is not searchable");
                }
                else
                {
                    foreach (object record in studentRecords)
                    {
                        searchStudentStore.Add(record);
                    }
                    studentRecords.Clear();
                }
            }
        }

        //method 1c - update main List<object> with object from method 1a 
        public void UpdateMasterMemberList()
        {
            try
            {
                memberList = AddMemberAsObject(); //method 1a also switches writeToObject bool to true if successful for 1b to then update
                if (memberList == null || memberList.Equals(memberList.Last())) //printable object list that gets saved
                {
                    Console.WriteLine("Record skipped: null and/or duplicate entry");
                }
                else
                {
                    studentRecordStore.Add(memberList);
                }
                DisplayListMembers();
            }
            catch (NullReferenceException ne)
            {
                Console.WriteLine("Oh dear, something went wrong, please revise and retry. Error details are: {0}", ne.Message);
            }
        }

        //method 2 - SearchStudent on using searchable master list
        public void SearchMemberList(string searchTerm)
        {
            try
            {
                //declare local variables
                int count = 0, foundCount = 0, loadCount = 0;
                bool foundRecord = false;

                //run method routine
                foreach (object record in searchStudentStore)
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
                        Console.WriteLine("Printing full (Student) record results for PPS number {0}:", record);
                        Console.WriteLine("****************Search Results********************");
                        Console.WriteLine("**************************************************");
                        foreach (object line in searchStudentStore)
                        {
                            if ((count == foundCount) || (foundCount > count))
                            {

                                Console.WriteLine("PPS Reference: {0} | Record Detail: {1}", searchTerm, line);
                                loadCount++;
                                if (loadCount == 11) { break; }
                            }
                            foundCount++;
                        }
                        Console.WriteLine("***************************************************");
                        foundRecord = true;
                        testStudentSearchResult = true; //TEST: bool for testing method
                    }
                    count++;
                }
                if (foundRecord == false)
                {
                    Console.WriteLine("");
                    Console.WriteLine("PPS Number {0} returned zero (Student) results", searchTerm);
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

        //method 3 - (Helper Method) Display All Students details - overload base method
        public void DisplayListMembers()
        {
            if (writeToObject == true)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("Student record saved as: \n{0}", memberList);
            }
            else
            {
                Console.WriteLine("No student records found for display. Please revise and try again");
            }
            Console.WriteLine("");
        }

        //method 4 - save student list to I/O isolated storage (override SaveMemberlist() in base) - specific to students
        public override void SaveMemberList()
        {
            try
            {
                //declare variables
                string input = "";
                //run method routine
                Console.WriteLine("Do you want to delete existing record store: studentRecordFile? y/n");
                input = Console.ReadLine().Trim();
                if (input == "y")
                {
                    File.Delete("studentRecordFile");
                    File.Delete("searchStudentRecordFile");
                    Console.WriteLine("Note: Old student files successfully deleted");
                }
                //printable file write/save
                StreamWriter fileWriter = new StreamWriter("studentRecordFile", true);
                foreach (object record in studentRecordStore)
                {
                    fileWriter.WriteLine(record);
                }
                Console.WriteLine("Note: Printable student member file successfully updated");
                fileWriter.Close();
                //searchable file write/save
                StreamWriter searchableFileWriter = new StreamWriter("searchStudentRecordFile", true);
                foreach (object line in searchStudentStore)
                {
                    searchableFileWriter.WriteLine(line);
                }
                Console.WriteLine("Note: Searchable student member file successfully updated");
                searchableFileWriter.Close();

            }
            catch (IOException io)
            {
                Console.WriteLine("Oh dear, something went wrong with the student file update and save process. Error details are {0}", io.Message);
            }
            catch (NullReferenceException ane)
            {
                Console.WriteLine("Oh dear, something went wrong with the student file update and save process. Error details are {0}", ane.Message);
            }
        }

        //method 5 - retreive list save from I/O
        public override void RetrieveMemberList()
        {
            try
            {
                string readFile = "";
                if (studentRecordFile == null)
                {
                    Console.WriteLine("No printable student file found. Please revise and try again");
                }
                else
                {
                    using (StreamReader fileReader = File.OpenText(studentRecordFile))
                    {
                        readFile = fileReader.ReadToEnd();
                        studentRecordStore.Clear();
                        studentRecordStore.Add(readFile);
                        Console.WriteLine("Successfully retrieved student filestore contents:");
                        fileReader.Close();
                    }
                }
            }
            catch (IOException io)
            {
                Console.WriteLine("Oh dear, something went wrong with the student file retrieve process. Error details are {0}", io.Message);
            }
            catch (NullReferenceException ne)
            {
                Console.WriteLine("Oh dear, something went wrong with the student file retrieve process. Error details are {0}", ne.Message);
            }
        }

        //method 5a - retreive searchable list save from I/O
        public void RetrieveSearchMemberList()
        {
            string searchableReadFile = "";
            try
            {
                if (searchStudentRecordFile == null)
                {
                    Console.WriteLine("No searchable student file found. Please revise and try again");
                }
                else
                {
                    searchStudentStore.Clear();
                    using (StreamReader searchableFileReader = File.OpenText(searchStudentRecordFile))
                    {
                        while ((searchableReadFile = searchableFileReader.ReadLine()) != null)
                        {
                            searchStudentStore.Add(searchableReadFile);
                        }
                    }
                }
            }
            catch (IOException io)
            {
                Console.WriteLine("Oh dear, something went wrong with the student file retrieve process. Error details are {0}", io.Message);
            }
            catch (NullReferenceException ne)
            {
                Console.WriteLine("Oh dear, something went wrong with the student file retrieve process. Error details are {0}", ne.Message);
            }
        }

        //method 6 - print out all objects loaded into the record store
        public void PrintAllStudents()
        {
            Console.WriteLine("");
            Console.WriteLine("***Student Master List Printout***");
            if (studentRecordStore == null | studentRecordFile == "")
            {
                Console.WriteLine("No student records found, please try again");
            }
            else
            {
                foreach (object member in studentRecordStore)
                {
                    Console.WriteLine(member);
                }
            }
            Console.WriteLine("");
        }
    }
}

