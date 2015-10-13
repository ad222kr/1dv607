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
    
    public abstract class BaseView
    {

        protected int GetMenuChoice(string prompt, int maxChoices)
        {    
            while (true)
            {
                Console.WriteLine(prompt);
                char line = Console.ReadKey().KeyChar;
                int key;

                if (!int.TryParse(line.ToString(), out key) || key <= 0 || key > maxChoices)
                {
                    ShowFeedbackMessage("\nNot a valid choice", true);
                }
                else
                {
                    return key;
                }
            }
        }

        protected int GetIntInputFromString()
        {
            while (true)
            {
                string input = Console.ReadLine();
                int key;
                if (int.TryParse(input, out key))
                {
                    return key;
                }
                ShowFeedbackMessage("Input must be an integer", true);
            }
        }

        public void ShowFeedbackMessage(string message, bool isError)
        {
            if (isError)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            } 
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Shows a message and continues on key pressed
        /// </summary>
        /// <param name="message"></param>

        public bool WantsToTryAgain()
        {
            Console.WriteLine("Press backspace to go back, any other key to try again");
            return Console.ReadKey(true).Key != ConsoleKey.Backspace;
        }
    }
}
