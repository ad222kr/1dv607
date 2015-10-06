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
     
        public DeleteMemberController(DeleteMemberView view) :base()
        {
            _view = view;
        }

        public override void Start()
        {
            _view.Show();


            do
            {
                int memberID = _view.GetMemberID();
                if (_memberRegistry.DeleteMemberByID(memberID))
                {
                    Service.SaveMemberRegistry(_memberRegistry);
                    _view.ShowSuccessMessage();
                    break;
                }
                _view.ShowMemberDoesNotExistMessage();

            } while (_view.WantsToTryAgain());   
            
            
   
        }
    }
}
