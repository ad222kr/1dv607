using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    public enum Event
    {
        None,
        ManageMember,
        RegisterMember,
        DeleteMember,
        UpdateMember,
        LookAtSpecificMember,
        ListMembersVerbose,
        ListMembersCompact,
        ManageBoat,
        RegisterBoat,
        DeleteBoat,
        UpdateBoat,
        GoBack,
        GoToMainMenu

    }
    public abstract class BaseView
    {
        protected const string chooseMessage = "What do you want to do?";

        protected List<Event> _menuChoices;

        public abstract void Show();
        public abstract Event GetEvent();

        protected int GetMenuChoice(string prompt, int maxChoices)
        {    
            while (true)
            {
                Console.WriteLine(prompt);
                char line = Console.ReadKey().KeyChar;
                int key;

                if (!int.TryParse(line.ToString(), out key) || key <= 0 || key > maxChoices)
                {
                    ShowErrorMessage("\nNot a valid choice");
                }
                else
                {
                    return key;
                }
            }
        }

        protected void ShowErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        protected string BuildMenuChoiceString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Event choice in _menuChoices)
            {
                // http://stackoverflow.com/a/5021570
                string withSpaces = string.Concat(choice.ToString().Select
                    (x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
                sb.Append(String.Format("{0}. {1}\n", _menuChoices.IndexOf(choice) + 1, withSpaces));
            }

            return sb.ToString();
        }
    }
}
