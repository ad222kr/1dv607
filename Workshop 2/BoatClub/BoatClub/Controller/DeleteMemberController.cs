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
    class DeleteMemberController : BaseController
    {
        private DeleteMemberView _view;
     

        public DeleteMemberController(DeleteMemberView view, MemberDAL memberDAL, MemberRegistry memberRegistry)
            :base(memberDAL, memberRegistry)
        {
            _memberRegistry = _memberRegistry;
        }
        public override void Start()
        {
            _view.Show();
            int memberID = _view.GetMemberID();
            _memberRegistry.DeleteMemberByID(memberID);
        }
    }
}
