using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.View;

namespace BoatClub.Controller
{
    // TODO: come up with better name?
    public class AppController : BaseController
    {
       

        public override void ManageEventChoice(Event appEvent)
        {
            switch (appEvent)
            {
                case Event.ManageMember:
                    ManageMember();
                    break;

                case Event.ManageBoat:
                    ManageBoat();
                    break;
            }
        }

        public void ManageMember()
        {
            var view = new ManageMemberView();
            var controller = new MemberController();
            controller.Start(view);
        }

        public void ManageBoat()
        {
            Console.Clear();
            Console.WriteLine("Manage Boat Pressed");
        }
    }
}
