using BoatClub.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Controller
{
    public class DeleteBoatController : BaseController
    {
        private DeleteBoatView _view;

        public DeleteBoatController(DeleteBoatView view) :base() 
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
                    var index = _view.GetIndexOfBoat(member);
                    member.RemoveBoatByIndex(index);
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
    }
}
