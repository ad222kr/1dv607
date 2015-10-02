using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.View;
using BoatClub.Model;
using BoatClub.Model.DAL;

namespace BoatClub.Controller
{
    // TODO: come up with better name?
    public class AppController : BaseController
    {
        public AppView _view;
        private MemberDAL MemberDAL { get { return _memberDAL ?? (_memberDAL = new MemberDAL()); } }
        public AppController(AppView appView)
        {
            _view = appView;
            new MemberRegistry();
            _memberDAL = new MemberDAL();
            _memberRegistry = _memberDAL.Load();
        }


        public override void Start()
        {
            while (true)
            {
                _view.Show();
                Event e = _view.GetEvent();
                ManageEventChoice(e); 
            }
        }

        public void ManageEventChoice(Event appEvent)
        {
            switch (appEvent)
            {
                case Event.RegisterMember:
                    RegisterMember();
                    break;
                case Event.DeleteMember:
                    DeleteMember();
                    break;
                case Event.UpdateMember:
                    UpdateMember();
                    break;
                case Event.LookAtSpecificMember:
                    LookAtSpecificMember();
                    break;
                case Event.ListMembers:
                    ListMembers();
                    break;
                case Event.RegisterBoat:
                    RegisterBoat();
                    break;
                case Event.DeleteBoat:
                    DeleteBoat();
                    break;
                case Event.UpdateBoat:
                    UpdateBoat();
                    break;
                case Event.Quit:
                    Environment.Exit(0); // fugly
                    break;
            }
        }

        private void RegisterMember()
        {
            var view = new RegisterMemberView();
            var controller = new RegisterMemberController(view, MemberDAL, _memberRegistry);
            controller.Start();
        }


        private void DeleteMember()
        {
            var view = new DeleteMemberView();
            var controller = new DeleteMemberController(view, MemberDAL, _memberRegistry);
            controller.Start();
        }


        private void ListMembers()
        {
            var view = new ListMembersView(_memberRegistry);
            var controller = new ListMembersController(view);
            controller.Start();
        }

        private void LookAtSpecificMember()
        {
            var view = new MemberView();
            var controller = new LookAtSpecificMemberController(view, _memberRegistry);
            controller.Start();
        }

        private void UpdateMember()
        {
            var view = new UpdateMemberView();
            var controller = new UpdateMemberController(view, _memberRegistry, _memberDAL);
            controller.Start();
        }
        private void RegisterBoat()
        {
            throw new NotImplementedException();
        }

        private void UpdateBoat()
        {
            throw new NotImplementedException();
        }

        private void DeleteBoat()
        {
            throw new NotImplementedException();
        }



        internal bool Quit()
        {
            throw new NotImplementedException();
        }
    }
}
