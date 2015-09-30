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
    public class MemberController : BaseController
    {
        private MemberRegistry _memberRegistry;
        private MemberDAL _memberDAL;
        public MemberController()
        {
            _memberRegistry = new MemberRegistry();
        }

        public override void ManageEventChoice(View.Event appEvent)
        {
            switch (appEvent)
            {
                case Event.RegisterMember:
                    Console.Clear();
                    Console.WriteLine("Register Member");
                    break;
                case Event.DeleteMember:
                    Console.Clear();
                    Console.WriteLine("Delete Member");
                    break;
                case Event.UpdateMember:
                    Console.Clear();
                    Console.WriteLine("Update Member");
                    break;
                case Event.LookAtSpecificMember:
                    Console.Clear();
                    Console.WriteLine("Look at specific member");
                    break;
                case Event.ListMembersVerbose:
                    Console.Clear();
                    Console.WriteLine("List verbose");
                    break;
                case Event.ListMembersCompact:
                    Console.Clear();
                    Console.WriteLine("List compact");
                    break;
            }
        }

        private void RegisterMember()
        {
            var view = new RegisterMemberView();
            view.Show();
            var member = view.GetMember();
            _memberRegistry.Authenticate(member);
            _memberRegistry.SaveMember(member);
            _memberDAL.SaveMember(member);



        }
    }
}
