using BoatClub.Model;
using BoatClub.Model.DAL;
using BoatClub.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Controller
{
    class RegisterMemberController : BaseController
    {


        private RegisterMemberView _view;
        

        public RegisterMemberController(RegisterMemberView view): base()
        {
            // TODO: Complete member initialization
            _view = view;
            _memberRegistry = _service.LoadMemberRegistry();
        }

        public override void Start()
        {
            _view.Show();
            do
            {
                try
                {

                    var member = _view.GetMember();
                    member.MemberID = _memberRegistry.GetUniqueMemberId();
                    _memberRegistry.SaveMember(member);
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
