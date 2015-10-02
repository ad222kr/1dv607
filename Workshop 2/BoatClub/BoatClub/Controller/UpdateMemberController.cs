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
    class UpdateMemberController : BaseController
    {
        private UpdateMemberView _view;

        public UpdateMemberController(UpdateMemberView view, MemberRegistry memberRegistry, MemberDAL memberDAL)
        {
            // TODO: Complete member initialization
            _view = view;
            _memberRegistry = memberRegistry;
            _memberDAL = memberDAL;
        }

        public override void Start()
        {
            _view.Show();
            int memberID = _view.GetMemberID();
            while (true)
            {
                try
                {
                    var member = _memberRegistry.GetMemberByID(memberID);

                    int optionKey = _view.GetUserOptionChoice();
                    UpdateMember(member, optionKey);
                    _memberDAL.Save(_memberRegistry); 
                    
                    break;  
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message, true);
                } 
            }
        }

        private void UpdateMember(Member member, int key)
        {
            switch (key)
            {
                case 1:
                    member.FirstName = _view.GetFirstName();
                    break;
                case 2:
                    member.LastName = _view.GetLastName();
                    break;
                case 3:
                    member.SocialSecurityNumber = _view.GetSocialSecurityNumber();
                    break;

            }
        }

    }
}
