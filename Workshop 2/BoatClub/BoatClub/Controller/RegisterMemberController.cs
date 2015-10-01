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
        private MemberDAL _memberDAL;
        public MemberRegistry _memberRegistry;
        
        public RegisterMemberView View { get; private set; }

        public RegisterMemberController(RegisterMemberView view, MemberDAL memberDAL, MemberRegistry memberRegistry) 
        {
            View = view;
            _memberDAL = memberDAL;
            _memberRegistry = memberRegistry;
        }

        public override void Start()
        {
            View.Show();
            var member = View.GetMember();
            Console.WriteLine(member.FirstName);
            member.MemberID = _memberRegistry.GetUniqueMemberId();


            _memberRegistry.SaveMember(member);
            _memberDAL.Save(_memberRegistry);
            View.ShowConfirmMessage();
        }

    }
}
