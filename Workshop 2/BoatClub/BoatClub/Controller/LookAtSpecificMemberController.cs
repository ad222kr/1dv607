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

        public LookAtSpecificMemberController(MemberView view, MemberRegistry memberRegistry)
        {
            // TODO: Complete member initialization
            _view = view;
            _memberRegistry = memberRegistry;
        }
        public override void Start()
        {
            _view.Show();
            while (true)
            {
                int memberID = _view.GetMemberID();
                try
                {
                    var member = _memberRegistry.GetMemberByID(memberID);
                    _view.DisplayMember(member);
                    _view.ShowMessage();
                    break;
                }
                catch (Exception exception)
                {
                    _view.ShowFeedbackMessage(exception.Message, true);
                }      
            }  
        }

    }
}
