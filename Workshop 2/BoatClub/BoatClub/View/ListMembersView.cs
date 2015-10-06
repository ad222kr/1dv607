using BoatClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    class ListMembersView : BaseView
    {

        public override void Show()
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

        public override void ShowSuccessMessage()
        {
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
        }
    }
}
