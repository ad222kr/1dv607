using BoatClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    public class MemberView : BaseView
    {
        public void ShowRegisterMember()
        {
            Console.Clear();
            Console.WriteLine("Hej du vill skapa en ny medlem! Vad kul");
        }

        public Member GetMember()
        {
            var member = new Member();
            Console.Write("Förnamn: ");
            member.FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            member.LastName = Console.ReadLine();
            Console.Write("Social Security Number: ");
            member.SocialSecurityNumber = Console.ReadLine();
            return member;
        }

        public void ShowDisplayMember()
        {
            Console.Clear();
            Console.WriteLine("Please enter a member ID to view a member");
        }

        public void SetMemberRegisteredSuccess()
        {
            Console.WriteLine("Member registered!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void SetMemberViewSuccess()
        {
            Console.ReadKey();
        }

        public void ShowMemberDoesNotExistMessage()
        {
            ShowFeedbackMessage("Member does not exist", true);
        }

        public int GetMemberID()
        {
            return GetIntInputFromString();
        }

        public void DisplayMember(Member member)
        {
            Console.WriteLine(String.Format("Name: {0} {1}", member.FirstName, member.LastName));
            Console.WriteLine(String.Format("Social security number: {0}", member.SocialSecurityNumber));
            Console.WriteLine(String.Format("Member ID: {0}", member.MemberID));
            Console.WriteLine("BOATS: ");

            foreach (var boat in member.Boats)
            {
                Console.WriteLine("Type: {0}. Length: {1}", boat.Type.ToString(), boat.Length.ToString());
            }
        }

        public void ShowDeleteMember()
        {
            Console.Clear();
            Console.WriteLine("Please enter the ID of the member to delete: ");
        }

        public void SetDeleteMemberSuccess()
        {
            Console.WriteLine("Member Deleted successfully!");
            Console.ReadKey();
        }

        public void ShowListMembers()
        {
            Console.Clear();
            Console.WriteLine("What type of list do you want to see?");
        }

        public void DoesUserWantToSeeCompactList(MemberRegistry memberRegistry)
        {
            int key = GetMenuChoice("1. Compact list.\n2. Verbose list", 2);
            if (key == 1)
            {
                ShowCompactList(memberRegistry);
            }
            else if (key == 2)
            {
                ShowVerboseList(memberRegistry);
            }
        }

        private void ShowVerboseList(MemberRegistry memberRegistry)
        {
            //TODO: FORMATTING OF STRINGS
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine(String.Format("{0,-15} {1,-15} {2,-22} {3,-8}", "Firstname", "Lastname", "Social Security Number", "Member ID"));
            Console.ResetColor();
            Console.WriteLine();
            foreach (var member in memberRegistry.Members)
            {
                Console.WriteLine(String.Format("{0,-15} {1,-15} {2,-22} {3,-8}", member.FirstName, member.LastName, member.SocialSecurityNumber, member.MemberID));

                if (member.Boats.Count > 0)
                {

                    Console.WriteLine("{0,10}", "Boats");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(String.Format("     {0,-15} {1,-5}", "Type", "Length"));
                    Console.ResetColor();
                    foreach (var boat in member.Boats)
                    {
                        Console.WriteLine(String.Format("     {0,-15} {1,-5}", boat.Type, boat.Length));
                    }
                }
                Console.WriteLine();


            }
        }

        private void ShowCompactList(MemberRegistry memberRegistry)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine(String.Format("{0,-15} {1,-15} {2,-15} {3,-8}", "Firstname", "Lastname", "Member ID", "Number of boats"));
            Console.ResetColor();
            Console.WriteLine();


            foreach (var member in memberRegistry.Members)
            {
                Console.WriteLine(String.Format("{0,-15} {1,-15} {2,-15} {3,-8}", member.FirstName, member.LastName, member.MemberID, member.Boats.Count));
            }
        }

        public void SetListMembersSuccess()
        {
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
        }

        public void ShowUpdateMember()
        {
            Console.Clear();
            Console.WriteLine("Enter ID of member to update: ");
        }

        public void SetUpdateMemberSuccess()
        {
            Console.WriteLine("Update successful, press any key to continue");
            Console.ReadKey();
        }

        public int GetUserOptionChoice()
        {
            return GetMenuChoice("1. Change first name\n2. Change last name\n3. Change social security number", 3);
        }

        public string GetFirstName()
        {
            Console.Clear();
            Console.Write("Enter new first name: ");
            return Console.ReadLine();
        }

        public string GetLastName()
        {
            Console.Clear();
            Console.Write("Enter new last name: ");
            return Console.ReadLine();
        }

        public string GetSocialSecurityNumber()
        {
            Console.Clear();
            Console.Write("Enter new social security number: ");
            return Console.ReadLine();
        }
    }
}
