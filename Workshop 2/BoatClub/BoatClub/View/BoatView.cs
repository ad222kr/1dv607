using BoatClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    public class BoatView : BaseView
    {

        public void ShowDeleteBoat()
        {
            Console.Clear();
            Console.WriteLine("Delete a boat!");
            Console.Write("Enter ID of member that wants to delete a boat: ");
        }

        public void SetBoatDeletedSuccess()
        {
            Console.WriteLine("Boat deleted!");
            Console.ReadKey();
        }

        public void ShowRegisterBoat()
        {
            Console.Clear();
            Console.WriteLine("Register a new boat");
            Console.WriteLine("Enter ID of member that wants to register a boat: ");
        }

        public void SetBoatRegisteredSuccess()
        {
            Console.WriteLine("Boat registered!");
            Console.ReadKey();
        }

        public int GetMemberID()
        {   
            return GetIntInputFromString();
        }

        public Boat GetBoat()
        {
            var boat = new Boat();
            Console.Write("Enter boat length: ");
            boat.Length = GetIntInputFromString();
            Console.WriteLine("Please choose boat type");
            boat.Type = (BoatType)GetMenuChoice("1. Sailboat\n2. Kayak\n3. Motorsailer\n4. Other", 4);

            return boat;
        }

        public void ShowUpdateBoat()
        {
            Console.Clear();
            Console.WriteLine("Update a boat!");
            Console.WriteLine("Enter member ID of member that wants to update a boat");
        }

        public void SetBoatUpdatedSuccess()
        {
            Console.WriteLine("Boat updated!");

        }

        public int GetIndexOfBoat(Member member)
        {
            Console.Clear();
            foreach (var boat in member.Boats)
            {
                Console.WriteLine(String.Format("{0}, {1}, {2}", member.Boats.IndexOf(boat) + 1, boat.Type, boat.Length));
            }

            Console.Write("Please enter ID of boat: ");
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
