using BoatClub.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Controller
{
    public class RegisterBoatController : BaseController
    {
        private RegisterBoatView _view;

        public RegisterBoatController(RegisterBoatView view) :base()
        {
            _view = view;
        }

        public override void Start()
        {
            _view.Show();

            do
            {
                try
                {
                    int memberID = _view.GetMemberID();
                    var member = _memberRegistry.GetMemberByID(memberID);
                    var boat = _view.GetBoat();
                    member.AddBoat(boat);
                    Service.SaveMemberRegistry(_memberRegistry);
                    _view.ShowSuccessMessage();

                    break;
                }
                catch (Exception e)
                {
                    _view.ShowFeedbackMessage(e.Message, true);
                }


            } while (Console.ReadKey().Key != ConsoleKey.Backspace);

        }
    }
}
