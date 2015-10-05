using BoatClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    public class UpdateBoatView : BaseView
    {
        public override void Show()
        {
            Console.Clear();
            Console.WriteLine("Update a boat!");
        }

        public override void ShowSuccessMessage()
        {
            Console.WriteLine("Boat updated!");

        }

        public int GetMemberID()
        {
            Console.WriteLine("Enter member ID of member that wants to update a boat");
            return GetIntInputFromString();
        }

        public int GetIndexOfBoat(Member member)
        {
            Console.Clear();
            foreach (var boat in member.Boats)
            {
                Console.WriteLine(String.Format("{0}, {1}, {2}", member.Boats.IndexOf(boat) + 1, boat.Type, boat.Length));
            }

            Console.Write("Enter number of boat to update: ");
            int index = GetIntInputFromString();

            return index - 1;
        }

        public int GetUserOptionChoice()
        {
            Console.Clear();
            return GetMenuChoice("1. Change length\n2. Change type", 2);
        }

        public double GetBoatLength()
        {
            Console.Clear();
            Console.Write("Enter new boat length: ");
            return GetIntInputFromString();
        }

        public BoatType GetBoatType()
        {
            Console.Clear();
            return (BoatType)GetMenuChoice("1. Sailboat\n2. Kayak\n3. Motorsailer\n4. Other", 4);
        }
    }
}
