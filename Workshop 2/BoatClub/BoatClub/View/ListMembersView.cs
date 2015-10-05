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
            foreach (var member in memberRegistry.Members)
            {
                Console.WriteLine(String.Format("{0} {1} {2} {3}", member.FirstName, member.LastName, member.SocialSecurityNumber, member.MemberID));
                foreach (var boats in member.Boats)
                {
                    Console.WriteLine(String.Format("{0} {1}", boats.Type, boats.Length));
                }

            }
        }

        private void ShowCompactList(MemberRegistry memberRegistry)
        {
            //TODO: FORMATTING OF STRINGS
            Console.Clear();
            foreach (var member in memberRegistry.Members)
            {
                Console.WriteLine(String.Format("{0} {1} {2} {3}", member.FirstName, member.LastName, member.MemberID, member.Boats.Count));
            }
        }

        public override void ShowMessage()
        {
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
        }
    }
}
