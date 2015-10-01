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
        RegisterMember,
        DeleteMember,
        UpdateMember,
        LookAtSpecificMember,
        ListMembers,
        RegisterBoat,
        DeleteBoat,
        UpdateBoat,
        Quit
    }
    public enum EventType
    {
        Member,
        Boat
    }
    public abstract class BaseView
    {
        public abstract void Show();

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
    }
}
