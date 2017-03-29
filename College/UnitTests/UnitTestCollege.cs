using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using College;
using System.Collections.Generic;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class UnitTestCollege
    {
        /// <summary>
        /// Class Definition: Unit Test Class of 5 methods (2 Student, 3 Lecturer) of the DBS College Admin Application. Part of the B8IT117 Project Submission for John Mulhall, StudentID:10042622
        /// </summary>
        
        /*  Note: This test class will not display symbols for report feedback due to the server security policies of DBS when I unzipped the .zip file on the P Drive.
        *   I opened a ticket, lost 8 critical hours debugging and finally found the P drive server side policies were the issue. Emailed Shazia on it. */

        //Unit Test 1 - Test the Input to List Output of the InputMemberList() method in Student Class (Operational Method).    
        [TestMethod]
        public void TestInputMemberList()
        {
            //declare objects for input and use hardcoded evaluation as a control comparision
            //t1
            Student testInputListObject1 = new Student("1010101h", "Jarjar", "Binks", "15 Jungen Drive", "Ballyfermot", "Dublin", "D22", "083 3423422", "jarjar@email.com",
                                                   10032344, "Undergraduate");
            //t2
            List<object> testStudentList1 = testInputListObject1.InputMemberList();

            //input unit test comparision list date
            List<object> compareInputList = new List<object>();
            compareInputList.Add("1010101h");
            compareInputList.Add("Jarjar");
            compareInputList.Add("Binks");
            compareInputList.Add("15 Jungen Drive");
            compareInputList.Add("Ballyfermot");
            compareInputList.Add("Dublin");
            compareInputList.Add("D22");
            compareInputList.Add("083 3423422");
            compareInputList.Add("jarjar@email.com");
            compareInputList.Add(10032344);
            compareInputList.Add("Undergraduate");
            Assert.AreEqual(testStudentList1, compareInputList);
        }

        //Unit Test 2 - Test the overloaded constructor of Student class.
        [TestMethod]
        public void TestStudentConstructor()
        {
            //declare objects for input and use hardcoded evaluation as a control comparision
            Student testStudentListObject2 = new Student("1010101h", "Jarjar", "Binks", "15 Jungen Drive", "Ballyfermot", "Dublin", "D22", "083 3423422", "jarjar@email.com",
                                                   10032344, "Undergraduate");
            //comparsison data
            Student ExpectedInputListObject = new Student();
            ExpectedInputListObject.PPSNumber = "1010101h";
            ExpectedInputListObject.FirstName = "Jarjar";
            ExpectedInputListObject.LastName = "Binks";
            ExpectedInputListObject.AddressLine1 = "15 Jungen Drive";
            ExpectedInputListObject.AddressLine2 = "Ballyfermot";
            ExpectedInputListObject.City = "Dublin";
            ExpectedInputListObject.PostCode = "D22";
            ExpectedInputListObject.ContactNumber = "083 3423422";
            ExpectedInputListObject.Email = "jarjar@email.com";
            ExpectedInputListObject.StudentID = 10032344;
            ExpectedInputListObject.Status = "Undergraduate";
            //test
            Assert.AreEqual(ExpectedInputListObject, testStudentListObject2);
        }

        //Unit Test 3 - Test AddMemberObject() method in Lecturer Class
        [TestMethod]
        public void TestAddMemberAsObject()
        {
            //input data - assign properties for test
            Lecturer testLecturerObjectProduction = new Lecturer("1010101h", "Jarjar", "Binks", "15 Jungen Drive", "Ballyfermot", "Dublin", "D22", "083 3423422", "jarjar@email.com",
                                                   1044, 50000, true, "Science, Computing");
            //run methods to convert to object
            Lecturer testObject = testLecturerObjectProduction.AddMemberAsObject();

            //comparision data 
            Lecturer expectedObjectResults = new Lecturer();
            expectedObjectResults.PPSNumber = "1010101h";
            expectedObjectResults.FirstName = "Jarjar";
            expectedObjectResults.LastName = "Binks";
            expectedObjectResults.AddressLine1 = "15 Jungen Drive";
            expectedObjectResults.AddressLine2 = "Ballyfermot";
            expectedObjectResults.City = "Dublin";
            expectedObjectResults.PostCode = "D22";

            expectedObjectResults.ContactNumber = "083 3423422";
            expectedObjectResults.Email = "jarjar@email.com";
            expectedObjectResults.StaffID = 1044;
            expectedObjectResults.Salary = 50000;
            expectedObjectResults.IsLecturer = true;
            expectedObjectResults.SubjectsTaught = "Science, Computing";
            //Assert true to been equal
            Assert.IsTrue(testObject == expectedObjectResults);
        }

        //Unit Test 4 - Test Check Exception Handling for Null on UpdateMasterMemberList() (Asserts are handed by ExceptionExpected)
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestUpdateMasterMemberList()
        {
            Lecturer lecturerClass = new Lecturer();
            lecturerClass.AddMemberAsObject();
            lecturerClass.UpdateMasterMemberList();
        }

        //Unit Test 5 - Test to ensure the Lecturer RetrieveSearchMemberList() Exception Handling For I/O using the filenotfound. (Asserts are handed by ExceptionExpected)
        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void TestRetrieveSearchMemberList() {
            Lecturer lecturerClass = new Lecturer();
            lecturerClass.AddMemberAsObject();
            lecturerClass.UpdateMasterMemberList();
            lecturerClass.SaveMemberList();
            lecturerClass.RetrieveSearchMemberList();
        }
    }
}
