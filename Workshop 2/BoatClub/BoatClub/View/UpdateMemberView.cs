using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    class UpdateMemberView : MemberView
    {
        public override void Show()
        {
            Console.Clear();
            Console.WriteLine("Enter ID of member to update: ");
        }

        public override void ShowSuccessMessage()
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
