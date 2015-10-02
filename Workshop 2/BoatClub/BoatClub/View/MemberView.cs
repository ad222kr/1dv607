using BoatClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    class MemberView : BaseView
    {
        public override void Show()
        {
            Console.Clear();
            Console.WriteLine("Please enter a member ID to view a member");
        }

        public override void ShowMessage()
        {
            Console.WriteLine("Press any key to continue");
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
                Console.WriteLine("Type: {0}. Length: {1}", boat.Length, boat.Type.ToString());
            }
        }
    }
}
