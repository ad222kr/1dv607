using BoatClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    public class RegisterBoatView : BaseView
    {
        public override void Show()
        {
            Console.Clear();
            Console.WriteLine("Register a new boat");
        }

        

        public override void ShowMessage()
        {
            Console.WriteLine("Boat registered!");
            Console.ReadKey();
        }

        public int GetMemberID()
        {
            Console.WriteLine("Enter ID of member that wants to register a boat: ");
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

        
    }
}
