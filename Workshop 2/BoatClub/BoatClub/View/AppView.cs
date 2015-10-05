using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    
    public class AppView : BaseView
    {
        private const string title = "Welcome to Happy Pirates";
        private const string chooseMessage = "What do you want to do?";

        private List<MenuItem> _menuChoices;

        public AppView()
        {
            _menuChoices = new List<MenuItem> 
            {
                new MenuItem(Event.RegisterMember, "Register Member"),
                new MenuItem(Event.DeleteMember, "Delete Member"),
                new MenuItem(Event.UpdateMember, "Update Member"),
                new MenuItem(Event.LookAtSpecificMember, "Look at specific member"),
                new MenuItem(Event.ListMembers, "List all members"),
                new MenuItem(Event.RegisterBoat, "Register boat"),
                new MenuItem(Event.DeleteBoat, "Delete boat"),
                new MenuItem(Event.UpdateBoat, "Update boat")
            };
        }

        public override void Show()
        {
            ShowSuccessMessage();
        }

        public Event GetEvent()
        {


            int key = GetMenuChoice(chooseMessage, _menuChoices.Count);

            switch (key)
            {
                case 1:
                    return Event.RegisterMember;
                case 2:
                    return Event.DeleteMember;
                case 3:
                    return Event.UpdateMember;
                case 4:
                    return Event.LookAtSpecificMember;
                case 5: 
                    return Event.ListMembers;
                case 6:
                    return Event.RegisterBoat;
                case 7:
                    return Event.DeleteBoat;
                case 8:
                    return Event.UpdateBoat;
                default:
                    return Event.None;
            }
        }

        private string BuildMenuChoiceString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var choice in _menuChoices)
            {
                sb.Append(String.Format("{0}. {1}\n", _menuChoices.IndexOf(choice) + 1, choice.EventName));
            }

            return sb.ToString();
        }

        public override void ShowSuccessMessage()
        {
            Console.Clear();
            Console.WriteLine(title);
            Console.WriteLine(BuildMenuChoiceString());
        }
    }
}
