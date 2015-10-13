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
        private BoatController _boatController;
        private MemberController _memberController;

   
        public AppController(AppView appView, BoatController boatController, MemberController memberController)
        {
            _view = appView;
            _boatController = boatController;
            _memberController = memberController;
        }


        public void Start()
        {
            while (true)
            {

                _view.ShowDeleteBoat();
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
            _memberController.RegisterMember();
        }


        private void DeleteMember()
        {
            _memberController.DeleteMember();
        }


        private void ListMembers()
        {
            _memberController.ListMembers();
        }

        private void LookAtSpecificMember()
        {
            _memberController.DisplayMember();
        }

        private void UpdateMember()
        {
            _memberController.UpdateMember();
        }
        private void RegisterBoat()
        {
            _boatController.RegisterBoat();
        }

        private void UpdateBoat()
        {
            _boatController.UpdateBoat();
        }

        private void DeleteBoat()
        {
            _boatController.DeleteBoat();
        }

    }
}
