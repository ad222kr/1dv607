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
        private MemberDAL _memberDAL;
        private MemberRegistry _memberRegistry;
        public AppView AppView { get; private set; }
        private MemberDAL MemberDAL { get { return _memberDAL ?? (_memberDAL = new MemberDAL()); } }
        public AppController(AppView appView)
        {
            AppView = appView;
            _memberDAL = new MemberDAL();
            _memberRegistry = _memberDAL.Load();

        }


        public override void Start()
        {



            while (true)
            {
                AppView.Show();
                Event e = AppView.GetEvent();
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
            throw new NotImplementedException();
        }


        private void ListMembers()
        {
            foreach (var m in _memberRegistry.Members)
            {
                Console.WriteLine(String.Format("{0} - {1}", m.FirstName, m.LastName));
            }
        }

        private void LookAtSpecificMember()
        {
            throw new NotImplementedException();
        }

        private void UpdateMember()
        {
            throw new NotImplementedException();
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
