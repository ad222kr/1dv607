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

        public override void Show()
        {
            Console.Clear();
            Console.WriteLine("Hej du vill skapa en ny medlem! Vad kul");
        }

        public void ShowConfirmMessage()
        {
            Console.Clear();
            Console.WriteLine("Grattis Niklas\n Tryck valfi tangen för att fortsätta");
            Console.ReadKey();
        }



        public Member GetMember()
        {
            var member = new Member();
            Console.Write("Förnamn: ");
            member.FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            member.LastName = Console.ReadLine();
            Console.Write("Social Security Number");
            member.SocialSecurityNumber = Console.ReadLine();

            return member;
        }
    }
}
