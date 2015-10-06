using BoatClub.Model;
using BoatClub.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Controller
{
    public class UpdateBoatController : BaseController
    {
        private UpdateBoatView _view;

        public UpdateBoatController(UpdateBoatView view)
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
                    int index = _view.GetIndexOfBoat(member);
                    var boat = member.GetBoatByIndex(index);

                    int optionKey = _view.GetUserOptionChoice();
                    UpdateBoat(boat, optionKey);
                    Service.SaveMemberRegistry(_memberRegistry);
                    _view.ShowSuccessMessage();
                    break;

                }
                catch (Exception e)
                {
                    _view.ShowFeedbackMessage(e.Message, true);
                }
            } while (_view.WantsToTryAgain());
        }

        private void UpdateBoat(Boat boat, int optionKey)
        {
            switch (optionKey)
            {
                case 1:
                    boat.Length = _view.GetBoatLength();
                    break;
                case 2:
                    boat.Type = _view.GetBoatType();
                    break;
            }
        }
    }
}
