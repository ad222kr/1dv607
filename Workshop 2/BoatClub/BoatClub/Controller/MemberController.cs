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
    public class MemberController : BaseController
    {
        private MemberView _view;
     
        public MemberController(MemberView view) :base()
        {
            _view = view;
        }

        public void DeleteMember()
        {
            _view.ShowDeleteMember();


            do
            {
                int memberID = _view.GetMemberID();
                if (_memberRegistry.DeleteMemberByID(memberID))
                {
                    Service.SaveMemberRegistry(_memberRegistry);
                    _view.SetMemberRegisteredSuccess();
                    break;
                }
                _view.ShowMemberDoesNotExistMessage();

            } while (_view.WantsToTryAgain());   
            
        }

        public void ListMembers()
        {
            _view.ShowListMembers();
            _view.DoesUserWantToSeeCompactList(_memberRegistry);
            _view.SetListMembersSuccess();
        }

        public void DisplayMember()
        {
            _view.ShowDisplayMember();

            do
            {

                try
                {
                    int memberID = _view.GetMemberID();
                    var member = _memberRegistry.GetMemberByID(memberID);
                    _view.DisplayMember(member);
                    _view.SetMemberViewSuccess();
                    break;
                }
                catch (Exception exception)
                {
                    _view.ShowFeedbackMessage(exception.Message, true);
                }
            } while (_view.WantsToTryAgain());
        }

        public void RegisterMember()
        {
            _view.ShowRegisterMember();
            do
            {
                try
                {

                    var member = _view.GetMember();
                    member.MemberID = _memberRegistry.GetUniqueMemberId();
                    _memberRegistry.SaveMember(member);
                    Service.SaveMemberRegistry(_memberRegistry);
                    _view.SetMemberRegisteredSuccess();
                    break;
                }
                catch (Exception e)
                {
                    _view.ShowFeedbackMessage(e.Message, true);
                }
            } while (_view.WantsToTryAgain());
        }

        public void UpdateMember()
        {
            _view.ShowUpdateMember();

            do
            {
                try
                {
                    int memberID = _view.GetMemberID();
                    var member = _memberRegistry.GetMemberByID(memberID);

                    int optionKey = _view.GetUserOptionChoice();
                    UpdateMember(member, optionKey);
                    Service.SaveMemberRegistry(_memberRegistry);
                    _view.SetUpdateMemberSuccess();
                    break;

                }
                catch (Exception e)
                {
                    _view.ShowFeedbackMessage(e.Message, true);

                }
            } while (_view.WantsToTryAgain());
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
