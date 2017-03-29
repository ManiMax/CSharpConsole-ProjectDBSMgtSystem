using System.Collections.Generic;

namespace College
{
    /// <summary>
    /// Interface Definition: To list the class methods and properties required to process list objects
    /// </summary>
    interface IProcessList
    {
		//property declarations
		string PPSNumber { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
		string AddressLine1 { get; set; }
		string AddressLine2 { get; set; }
		string City { get; set; }
		string PostCode { get; set;}
		string ContactNumber { get; set; }
		string Email { get; set; }

        //method declarations
        List<object> InputMemberList();
		void UpdateMasterMemberList();
        void SearchMemberList(string searchTerm);
		void DisplayListMembers();
        void SaveMemberList();
        void RetrieveMemberList();
		void RetrieveSearchMemberList();
    }
}
