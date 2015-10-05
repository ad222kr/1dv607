using BoatClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    public class DeleteBoatView : BaseView
    {

        public override void Show()
        {
            Console.WriteLine("Delete a boat!");
        }

        public override void ShowSuccessMessage()
        {
            Console.WriteLine("Boat deleted!");
            Console.ReadKey();
        }

       
        public int GetMemberID()
        {
            Console.Write("Enter ID of member that wants to delete a boat: ");
            return GetIntInputFromString();
        }

        public int GetIndexOfBoat(Member member)
        {
            foreach (var boat in member.Boats)
            {
                Console.WriteLine(String.Format("{0}, {1}, {2}", member.Boats.IndexOf(boat) + 1, boat.Type, boat.Length));
            }

            Console.Write("Enter number of boat to delete: ");
            int index = GetIntInputFromString();

            return index - 1;
        }
    }
}
