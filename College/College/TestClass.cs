using System;
using System.Collections.Generic;

namespace College
{
    class TestClass
    {
        /// <summary>
        /// Class Definition: Basic Test Class for functional testing of the DBS College Admin Application. Part of the B8IT117 Project Submission for John Mulhall, StudentID:10042622
        /// </summary>

        static void Main() {

            try
            {
                //Declare test class variables
                bool isValid;
                string input;
                int menuChoice = 0;

                //run program script
                Console.WriteLine("***Test Script - DBS College Personnel Program***");
                Console.WriteLine("**************************************************");
                Console.WriteLine("");
                /*******************************************************************/
                //TEST #1

                Console.WriteLine("");
                Console.WriteLine("**1. Student Class Tests**");
                Console.WriteLine("******************************");
                Student testStudent1 = new Student("1010101h", "Jarjar", "Binks", "15 Jungen Drive", "Ballyfermot", "Dublin", "D22", "083 3423422", "jarjar@email.com",
                                                   10032344, "Undergraduate");
                //run methods
                //test 1a - validate data input methods/routinee
                Console.WriteLine();
                Console.WriteLine("Test 1a - Test Input Methods/Routine");
                Console.WriteLine("*************************************");
                testStudent1.UpdateMasterMemberList();
                if (testStudent1.PPSNumber == "1010101h")
                {
                    Console.WriteLine("Test 1a Result: Input Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 1a Result: Input Test: FAILED");
                }
                Console.WriteLine("");
                //test 1b - Properities Test
                Console.WriteLine("TestClass 1b - Test Constructor/Properties");
                Console.WriteLine("*************************************");
                if (testStudent1.FirstName == "Jarjar")
                {
                    Console.WriteLine("Test 1b Result: FirstName Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 1b Result: FirstName Property Test: FAILED");
                }
                if (testStudent1.LastName == "Binks")
                {
                    Console.WriteLine("Test 1b Result: LastNane Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 1b Result: LastNane Property Test: FAILED");
                }
                if (testStudent1.AddressLine1 == "15 Jungen Drive")
                {
                    Console.WriteLine("Test 1b Result: AddressLine1 Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 1b Result: AddressLine1 Property Test: FAILED");
                }
                if (testStudent1.AddressLine2 == "Ballyfermot")
                {
                    Console.WriteLine("Test 1b Result: AddressLine2 Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 1b Result: AddressLine2 Property Test: FAILED");
                }
                if (testStudent1.City == "Dublin")
                {
                    Console.WriteLine("Test 1b Result: City Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 1b Result: City Property Test: FAILED");
                }
                if (testStudent1.PostCode == "D22")
                {
                    Console.WriteLine("Test 1b Result: PostCode Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 1b Result: PostCode Property Test: FAILED");
                }
                if (testStudent1.ContactNumber == "083 3423422")
                {
                    Console.WriteLine("Test 1b Result: ContactNumber Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 1b Result: ContactNumber Property Test: FAILED");
                }
                if (testStudent1.Email == "jarjar@email.com")
                {
                    Console.WriteLine("Test 1b Result: Email Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 1b Result: Email Property Test: FAILED");
                }
                if (testStudent1.StudentID == 10032344)
                {
                    Console.WriteLine("Test 1b Result: StudentID Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 1b Result: StudentID Property Test: FAILED");
                }
                if (testStudent1.Status == "Undergraduate")
                {
                    Console.WriteLine("Test 1b Result: StudentID Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 1b Result: StudentID Property Test: FAILED");
                }
                //test 1c - valdiate records search update methods/routin
                Console.WriteLine("");
                Console.WriteLine("TestClass 1c - Validate Record Search/Update Routines");
                Console.WriteLine("*************************************");
                Console.WriteLine("Note: Test using PPS Number '8888888H' in test");
                Student testStudent2 = new Student();
                List<object> testInputList = testStudent2.InputMemberList();
                testStudent2.UpdateMasterMemberList();
                testStudent2.AddRecordEntryToSearchList();
                testStudent2.SaveMemberList();
                testStudent2.RetrieveSearchMemberList();
                Console.WriteLine("Search Records: Input student PPS Number 8888888h now");
                input = Console.ReadLine().ToUpper().Trim();
                testStudent2.SearchMemberList(input);
                if (testInputList != null & testInputList.ToString() != "")
                {
                    Console.WriteLine("1c Result: Input Test Validatation: PASSED");
                }
                else
                {
                    Console.WriteLine("1c Result: Input Test Validatation: FAILED");
                }
                if (testStudent2.testStudentSearchResult == true)
                {
                    Console.WriteLine("1c Result: Search Result Validatation: PASSED");
                }
                else
                {
                    Console.WriteLine("1c Result: Search Result Validatation: FAILED");
                }
                Console.WriteLine("*Press return to continue to the next test...");
                Console.ReadLine();
                /*******************************************************************/
                //TEST #2

                Console.WriteLine("");
                Console.WriteLine("**2. Staff Class Tests**");
                Console.WriteLine("********************************");
                Staff testStaff1 = new Staff("8999888M", "Jim", "Boylon", "33 Farm Grove", "Tullamore", "Offaly", "Co Offaly", "087324333", "jim@farmers.ie",
                                             1022, 55000.33, false);
                //Test 2a - propertities test
                Console.WriteLine("Test 2a - Test Constructor/Properties");
                Console.WriteLine("******************************");
                if (testStaff1.PPSNumber == "8999888M")
                {
                    Console.WriteLine("2a Result: PPSNumber: PASSED");
                }
                else
                {
                    Console.WriteLine("2a Result: PPSNumber: FAILED");
                }
                if (testStaff1.FirstName == "Jim")
                {
                    Console.WriteLine("2a Result: FirstName: PASSED");
                }
                else
                {
                    Console.WriteLine("2a Result: FirstName: FAILED");
                }
                if (testStaff1.LastName == "Boylon")
                {
                    Console.WriteLine("2a Result: LastName: PASSED");
                }
                else
                {
                    Console.WriteLine("2a Result: LastName: FAILED");
                }
                if (testStaff1.AddressLine1 == "33 Farm Grove")
                {
                    Console.WriteLine("2a Result: AddressLine1: PASSED");
                }
                else
                {
                    Console.WriteLine("2a Result: AddressLine1: FAILED");
                }
                if (testStaff1.AddressLine2 == "Tullamore")
                {
                    Console.WriteLine("2a Result: AddressLine2: PASSED");
                }
                else
                {
                    Console.WriteLine("2a Result: AddressLine2: FAILED");
                }
                if (testStaff1.City == "Offaly")
                {
                    Console.WriteLine("2a Result: City: PASSED");
                }
                else
                {
                    Console.WriteLine("2a Result: City: FAILED");
                }
                if (testStaff1.PostCode == "Co Offaly")
                {
                    Console.WriteLine("2a Result: PostCode: PASSED");
                }
                else
                {
                    Console.WriteLine("2a Result: PostCode: FAILED");
                }
                if (testStaff1.ContactNumber == "087324333")
                {
                    Console.WriteLine("2a Result: ContactNumber: PASSED");
                }
                else
                {
                    Console.WriteLine("2a Result: ContactNumber: FAILED");
                }
                if (testStaff1.Email == "jim@farmers.ie")
                {
                    Console.WriteLine("2a Result: Email: PASSED");
                }
                else
                {
                    Console.WriteLine("2a Result: Email: FAILED");
                }
                if (testStaff1.Email == "jim@farmers.ie")
                {
                    Console.WriteLine("2a Result: Email: PASSED");
                }
                else
                {
                    Console.WriteLine("2a Result: Email: FAILED");
                }
                if (testStaff1.StaffID == 1022)
                {
                    Console.WriteLine("2a Result: StaffID: PASSED");
                }
                else
                {
                    Console.WriteLine("2a Result: StaffID: FAILED");
                }
                if (testStaff1.Salary == 55000.33)
                {
                    Console.WriteLine("2a Result: Salary: PASSED");
                }
                else
                {
                    Console.WriteLine("2a Result: Salary: FAILED");
                }
                if (testStaff1.IsLecturer == false)
                {
                    Console.WriteLine("2a Result: IsLecturer: PASSED");
                }
                else
                {
                    Console.WriteLine("2a Result: IsLecturer: FAILED");
                }
                testStaff1.DisplayListMembers();

                Console.WriteLine("*Press return to continue to the next test...");
                Console.ReadLine();
                /*******************************************************************/
                //TEST #3

                Console.WriteLine("");
                Console.WriteLine("**3. Lecturer Class Method Tests**");
                Console.WriteLine("**********************************");
                Lecturer testLecturer1 = new Lecturer("1010101h", "Jarjar", "Binks", "15 Jungen Drive", "Ballyfermot", "Dublin", "D22", "083 3423422", "jarjar@email.com",
                                                   1043, 44000, true, "Science, Computing, Politics");
                //run methods
                //test 1a - validate data input methods/routin
                Console.WriteLine();
                Console.WriteLine("Test 3a - Test Input Methods/Routine");
                Console.WriteLine("*************************************");
                testStudent1.UpdateMasterMemberList();
                if (testStudent1.PPSNumber == "1010101h")
                {
                    Console.WriteLine("Test 3a Result: Input Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 3a Result: Input Test: FAILED");
                }
                Console.WriteLine("");
                //test 1b - Properities Test
                Console.WriteLine("TestClass 3b - Test Constructor/Properties");
                Console.WriteLine("*************************************");
                if (testLecturer1.FirstName == "Jarjar")
                {
                    Console.WriteLine("Test 3b Result: FirstName Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 3b Result: FirstName Property Test: FAILED");
                }
                if (testLecturer1.LastName == "Binks")
                {
                    Console.WriteLine("Test 3b Result: LastNane Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 3b Result: LastNane Property Test: FAILED");
                }
                if (testLecturer1.AddressLine1 == "15 Jungen Drive")
                {
                    Console.WriteLine("Test 3b Result: AddressLine1 Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 3b Result: AddressLine1 Property Test: FAILED");
                }
                if (testLecturer1.AddressLine2 == "Ballyfermot")
                {
                    Console.WriteLine("Test 3b Result: AddressLine2 Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 3b Result: AddressLine2 Property Test: FAILED");
                }
                if (testLecturer1.City == "Dublin")
                {
                    Console.WriteLine("Test 3b Result: City Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 3b Result: City Property Test: FAILED");
                }
                if (testLecturer1.PostCode == "D22")
                {
                    Console.WriteLine("Test 3b Result: PostCode Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 3b Result: PostCode Property Test: FAILED");
                }
                if (testLecturer1.ContactNumber == "083 3423422")
                {
                    Console.WriteLine("Test 3b Result: ContactNumber Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 3b Result: ContactNumber Property Test: FAILED");
                }
                if (testLecturer1.Email == "jarjar@email.com")
                {
                    Console.WriteLine("Test 3b Result: Email Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 3b Result: Email Property Test: FAILED");
                }
                if (testLecturer1.StaffID == 1043)
                {
                    Console.WriteLine("Test 3b Result: StaffID Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 3b Result: StaffID Property Test: FAILED");
                }
                if (testLecturer1.Salary == 44000)
                {
                    Console.WriteLine("Test 3b Result: StudentID Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 3b Result: StudentID Property Test: FAILED");
                }
                if (testLecturer1.IsLecturer == true)
                {
                    Console.WriteLine("Test 3b Result: IsLecturer Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 3b Result: IsLecturer Property Test: FAILED");
                }
                if (testLecturer1.SubjectsTaught == "Science, Computing, Politics")
                {
                    Console.WriteLine("Test 3b Result: SubjectsTaught Property Test: PASSED");
                }
                else
                {
                    Console.WriteLine("Test 3b Result: SubjectsTaught Property Test: FAILED");
                }
                //test 1c - valdiate records search update methods/routin
                Console.WriteLine("");
                Console.WriteLine("TestClass 3c - Validate Record Search/Update Routines");
                Console.WriteLine("*************************************");
                Console.WriteLine("Note: Test using PPS Number '8888888H' in test");
                Lecturer testLecturer2 = new Lecturer();
                List<object> testLecturerInput = testLecturer2.InputMemberList();
                testLecturer2.UpdateMasterMemberList();
                testLecturer2.AddRecordEntryToSearchList();
                testLecturer2.SaveMemberList();
                testLecturer2.RetrieveSearchMemberList();
                Console.WriteLine("Search Records: Input lecturer PPS Number 8888888h now");
                input = Console.ReadLine().ToUpper().Trim();
                testLecturer2.SearchMemberList(input);
                if (testLecturerInput != null & testLecturerInput.ToString() != "")
                {
                    Console.WriteLine("3c Result: Input Test Validatation: PASSED");
                }
                else
                {
                    Console.WriteLine("3c Result: Input Test Validatation: FAILED");
                }
                if (testLecturer2.testLecturerSearchResult == true)
                {
                    Console.WriteLine("1c Result: Search Result Validatation: PASSED");
                }
                else
                {
                    Console.WriteLine("1c Result: Search Result Validatation: FAILED");
                }

                /*******************************************************************/
                //TEST #4 - Trial Program Draft with Calling Methods, etc
                //declare test #4 objectss
                //declare class objects
                Student student = new Student();
                Lecturer lecturer = new Lecturer();

                //declare specific test 4 script variables
                bool goToMainMenu = false;
    
                    //run program script
                    Console.WriteLine("");
                    Console.WriteLine("***DBS College Personnel Program***");
                    Console.WriteLine("***********************************");
                    Console.WriteLine("");
                    do
                    {
                        Console.WriteLine("");
                        Console.WriteLine("*****************MENU*****************");
                        Console.WriteLine("**************************************");
                        Console.WriteLine("1. Add Student");
                        Console.WriteLine("2. Add Lecturer");
                        Console.WriteLine("3. Search Lecturer or Student");
                        Console.WriteLine("4. Display All Enrolled Student Detail");
                        Console.WriteLine("5. Display Names of All Lecturers");
                        Console.WriteLine("6. To Exit the Program");
                        Console.WriteLine("**************************************");
                        Console.WriteLine("Please enter your choice now...");
                        input = Console.ReadLine();
                        isValid = int.TryParse(input, out menuChoice);
                        //swtich statement to process choices
                        switch (menuChoice)
                        {
                            case 1:
                                //instantiate local objs and declare vars
                                Student studentClass = new Student();
                                while (input.ToLower().Trim() != "q")
                                {
                                    studentClass.InputMemberList();
                                    Console.WriteLine("Do you want to save your student records input? y/n or q to exit to manu, x to exit");
                                    input = Console.ReadLine().ToLower().Trim();
                                    if (input == "y")
                                    {
                                        studentClass.UpdateMasterMemberList();
                                        studentClass.AddRecordEntryToSearchList();
                                        studentClass.SaveMemberList();
                                        Console.WriteLine("");
                                        break;
                                    }
                                    else if (input == "n" || input == "q")
                                    {
                                        Console.WriteLine("");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Exiting Application.. Press any key to continue...");
                                        Console.ReadLine();
                                        goToMainMenu = true;
                                        break;
                                    }
                                }
                                break;
                            case 2:
                                Lecturer lecturerClass = new Lecturer();
                                while (input.ToLower().Trim() != "q")
                                {
                                    lecturerClass.InputMemberList();
                                    Console.WriteLine("Do you want to save your lecturer record? y/n or q to main menu, x to exit");
                                    input = Console.ReadLine().ToLower().Trim();
                                    if (input == "y")
                                    {
                                        lecturerClass.UpdateMasterMemberList();
                                        lecturerClass.AddRecordEntryToSearchList();
                                        lecturerClass.SaveMemberList();
                                        Console.WriteLine("");
                                        break;
                                    }
                                    else if (input == "n" || input == "q")
                                    {
                                        Console.WriteLine("");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Exiting Application.. Press any key to continue...");
                                        Console.ReadLine();
                                        goToMainMenu = true;
                                        break;
                                    }
                                }
                                break;
                            case 3:
                                Student searchStudent = new Student();
                                Lecturer searchLecturer = new Lecturer();
                                //run routine
                                while (input.ToLower().Trim() != "q")
                                {
                                    Console.WriteLine("Search Records: Input student or lecturer PPS number now to start record search " +
                                                      "\nAlternatively, press q to exit back to menu, x to exit program");
                                    input = Console.ReadLine().ToUpper().Trim();

                                    if (input.ToLower().Trim() == "q") //options
                                    {
                                        Console.WriteLine("");
                                        input = "";
                                        break;
                                    }
                                    if (input.ToLower().Trim() == "x")
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Exiting program... press any key to continue");
                                        Console.ReadLine();
                                        goToMainMenu = true;
                                        break;
                                    }
                                    if ((input.Length == 8) || (input.Length == 9)) //processing based on Irish PPS number 8 or 9 characters long
                                    {
                                        searchStudent.RetrieveSearchMemberList();
                                        searchStudent.SearchMemberList(input);
                                        searchLecturer.RetrieveSearchMemberList();
                                        searchLecturer.SearchMemberList(input);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Processing input of member PPS number failed, please try again");
                                        break;
                                    }
                                }
                                break;
                            case 4:
                                student.RetrieveMemberList();
                                student.PrintAllStudents();
                                break;
                            case 5:
                                lecturer.RetrieveMemberList();
                                lecturer.PrintAllLecturers();
                                break;
                            case 6:
                                Console.WriteLine("Exiting program... press any key to continue");
                                Console.Read();
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid Input...Please try again");
                                break;
                        }
                    } while (goToMainMenu == false);

                    Console.WriteLine("Thank you for using the DBS Personnel Programme, have a great day eh!!... Press Any key to complete exit");
                    Console.ReadLine();

                    Console.WriteLine("**End of Test Script, press return to exit..");
                    Console.ReadLine();
                }
            catch (Exception e) {
                Console.WriteLine("Oh dear, something went wrong in test class. Error details are {0}", e.Message);
            }
        }
    }
}
