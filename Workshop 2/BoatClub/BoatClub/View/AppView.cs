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

        public AppView()
        {
            _menuChoices = new List<Event> { Event.ManageMember, Event.ManageBoat };
        }

        public override void Show()
        {
            Console.Clear();
            Console.WriteLine(title);
            Console.WriteLine(BuildMenuChoiceString());
        }

        public override Event GetEvent()
        {
            int key = GetMenuChoice(chooseMessage, _menuChoices.Count);
  
            switch (key)
            {
                case 1:
                    return Event.ManageMember;
                case 2:
                    return Event.ManageBoat;
                default:
                    return Event.None;
            }
        }
    }
}
