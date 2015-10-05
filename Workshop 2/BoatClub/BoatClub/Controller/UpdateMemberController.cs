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

        public UpdateMemberController(UpdateMemberView view):base()
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

                    int optionKey = _view.GetUserOptionChoice();
                    UpdateMember(member, optionKey);
                    Service.SaveMemberRegistry(_memberRegistry);
                    _view.ShowSuccessMessage();
                    break;

                }
                catch (Exception e)
                {
                    _view.ShowFeedbackMessage(e.Message, true);

                }
            } while (Console.ReadKey().Key != ConsoleKey.Backspace);
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
