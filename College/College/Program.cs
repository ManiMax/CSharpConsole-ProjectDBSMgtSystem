using System;

namespace College
{
	/// <summary>
	/// Class Definition: Entry point for the DBS College Admin Application. Part of the B8IT117 Project Submission for John Mulhall, StudentID:10042622
	/// </summary>
    class College
    {
        static void Main()
        {
			//declare class objects
         	Student student = new Student();
			Lecturer lecturer = new Lecturer();

			//declare script variables
			bool goToMainMenu = false;
			bool isValid;
			string input;
			int menuChoice = 0;
			try
			{

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
            }
			catch(Exception e) {
				Console.WriteLine("Oh dear, something went wrong in test class. Error details are {0}", e.Message);
			} 
        }
    }
}
