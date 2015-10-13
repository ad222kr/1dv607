using BoatClub.Model;
using BoatClub.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Controller
{
    public class BoatController : BaseController
    {
        private BoatView _view;

        public BoatController(BoatView view) :base()
        {
            _view = view;
        }

        public void RegisterBoat()
        {
            _view.ShowRegisterBoat();

            do
            {
                try
                {
                    int memberID = _view.GetMemberID();
                    var member = _memberRegistry.GetMemberByID(memberID);
                    var boat = _view.GetBoat();
                    member.AddBoat(boat);
                    Service.SaveMemberRegistry(_memberRegistry);
                    _view.SetBoatRegisteredSuccess();

                    break;
                }
                catch (Exception e)
                {
                    _view.ShowFeedbackMessage(e.Message, true);
                }


            } while (_view.WantsToTryAgain());

        }

        public void DeleteBoat()
        {
            _view.ShowDeleteBoat();

            do
            {
                try
                {
                    int memberID = _view.GetMemberID();
                    var member = _memberRegistry.GetMemberByID(memberID);
                    var index = _view.GetIndexOfBoat(member);
                    member.RemoveBoatByIndex(index);
                    Service.SaveMemberRegistry(_memberRegistry);
                    _view.SetBoatDeletedSuccess();
                    break;

                }
                catch (Exception e)
                {
                    _view.ShowFeedbackMessage(e.Message, true);
                }
            } while (_view.WantsToTryAgain());
        }

        public void UpdateBoat()
        {
            _view.ShowUpdateBoat();

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
                    _view.SetBoatUpdatedSuccess();
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
