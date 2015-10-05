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
    public abstract class BaseController
    {

        protected Service _service;
        protected MemberRegistry _memberRegistry;

        protected Service Service { get { return _service ?? (_service = new Service()); } }

        public BaseController()
        {
            _memberRegistry = Service.LoadMemberRegistry();
        }


        public abstract void Start();
        
    }
}
