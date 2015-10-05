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
        public ListMembersView _view;

        public ListMembersController(ListMembersView view)
            :base()
        {
            _view = view;
        }
        public override void Start()
        {
            _view.Show();
            _view.DoesUserWantToSeeCompactList(_memberRegistry);
            _view.ShowMessage();
        }
    }
}
