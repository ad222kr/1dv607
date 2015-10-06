using BoatClub.Model;
using BoatClub.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Controller
{
    class LookAtSpecificMemberController : BaseController
    {
        private MemberView _view;

        public LookAtSpecificMemberController(MemberView view) :base()
        {
            // TODO: Complete member initialization
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
                    _view.DisplayMember(member);
                    _view.ShowSuccessMessage();
                    break;
                }
                catch (Exception exception)
                {
                    _view.ShowFeedbackMessage(exception.Message, true);
                }
            } while (_view.WantsToTryAgain());
        }

    }
}
