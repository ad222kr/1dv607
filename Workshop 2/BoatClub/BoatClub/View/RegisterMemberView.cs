using BoatClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    class RegisterMemberView : BaseView
    {
        private static readonly string confirmMessage = "Member registration successful!.";

        public override void Show()
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

        public override void ShowSuccessMessage()
        {
            Console.WriteLine(confirmMessage);
            Console.ReadKey();
        }
    }
}
