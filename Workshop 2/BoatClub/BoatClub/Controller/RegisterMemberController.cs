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


        public RegisterMemberView _view;

        public RegisterMemberController(RegisterMemberView view, MemberDAL memberDAL, MemberRegistry memberRegistry)
            :base(memberDAL, memberRegistry)
        {
            _view = view;
        }

        public override void Start()
        {
            _view.Show();
            while (true)
            {
                try
                {

                    var member = _view.GetMember();
                    member.MemberID = _memberRegistry.GetUniqueMemberId();
                    _memberRegistry.SaveMember(member);
                    _memberDAL.Save(_memberRegistry);
                    _view.ShowMessage();
                    break;
                }
                catch (Exception e)
                {
                    _view.ShowFeedbackMessage(e.Message, true);
                } 
            }
        }

    }
}
