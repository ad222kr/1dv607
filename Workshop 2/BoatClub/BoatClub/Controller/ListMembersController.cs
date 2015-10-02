using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.View;
using BoatClub.Model.DAL;
using BoatClub.Model;

namespace BoatClub.Controller
{
    class ListMembersController : BaseController
    {
        public ListMembersView View { get; private set; }

        public ListMembersController(ListMembersView view)
            :base()
        {
            View = view;
        }
        public override void Start()
        {
            View.Show();
            View.DoesUserWantToSeeCompactList();
            View.ShowMessage();
        }
    }
}
