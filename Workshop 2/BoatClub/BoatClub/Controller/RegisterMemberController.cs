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
        
        
        public RegisterMemberView View { get; private set; }

        public RegisterMemberController(RegisterMemberView view, MemberDAL memberDAL, MemberRegistry memberRegistry)
            :base(memberDAL, memberRegistry)
        {
            View = view;
        }

        public override void Start()
        {
            View.Show();
            var member = View.GetMember();
            member.MemberID = _memberRegistry.GetUniqueMemberId();
            _memberRegistry.SaveMember(member);
            _memberDAL.Save(_memberRegistry);
            View.ShowMessage();
        }

    }
}
