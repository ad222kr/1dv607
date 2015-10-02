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
        protected MemberDAL _memberDAL;
        protected MemberRegistry _memberRegistry;

        public BaseController(MemberDAL memberDAL, MemberRegistry memberRegistry)
        {
            _memberDAL = memberDAL;
            _memberRegistry = memberRegistry;
        }

        public BaseController(MemberDAL memberDAL)
        {
            _memberDAL = memberDAL;
        }

        public BaseController()
        {

        }

        public abstract void Start();
        
    }
}
