using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    class DeleteMemberView : MemberView
    {

        public override void Show()
        {
            Console.Clear();
            Console.WriteLine("Please enter the ID of the member to delete: ");
        }

        public override void ShowMessage()
        {
            Console.WriteLine("Member Deleted successfully!");
            Console.ReadKey();
        }
    }
}
