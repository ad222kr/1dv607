using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    class ManageMemberView: BaseView
    {
        private const string title = "Member management area";

        public ManageMemberView()
        {
            _menuChoices = new List<Event>
            {
                Event.RegisterMember,
                Event.UpdateMember,
                Event.DeleteMember,
                Event.LookAtSpecificMember,
                Event.ListMembersCompact,
                Event.ListMembersVerbose,
            };
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
                    return Event.RegisterMember;
                case 2:
                    return Event.UpdateMember;
                case 3:
                    return Event.DeleteMember;
                case 4:
                    return Event.LookAtSpecificMember;
                case 5: 
                    return Event.ListMembersCompact;
                case 6:
                    return Event.ListMembersVerbose;
                default:
                    return Event.None;
            }
        }
    }
}
