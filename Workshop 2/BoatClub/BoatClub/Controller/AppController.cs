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
        private AppView _view;
   
        public AppController(AppView appView)
        {
            _view = appView;
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
            var controller = new RegisterMemberController(view);
            controller.Start();
        }


        private void DeleteMember()
        {
            var view = new DeleteMemberView();
            var controller = new DeleteMemberController(view);
            controller.Start();
        }


        private void ListMembers()
        {
            var view = new ListMembersView();
            var controller = new ListMembersController(view);
            controller.Start();
        }

        private void LookAtSpecificMember()
        {
            var view = new MemberView();
            var controller = new LookAtSpecificMemberController(view);
            controller.Start();
        }

        private void UpdateMember()
        {
            var view = new UpdateMemberView();
            var controller = new UpdateMemberController(view);
            controller.Start();
        }
        private void RegisterBoat()
        {
            var view = new RegisterBoatView();
            var controller = new RegisterBoatController(view);
            controller.Start();
        }

        private void UpdateBoat()
        {
            throw new NotImplementedException();
        }

        private void DeleteBoat()
        {
            var view = new DeleteBoatView();
            var controller = new DeleteBoatController(view);
            controller.Start();
        }



        internal bool Quit()
        {
            throw new NotImplementedException();
        }
    }
}
