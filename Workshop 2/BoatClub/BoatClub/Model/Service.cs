using BoatClub.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Model
{
    /// <summary>
    /// Service-class that handles communication between MemberDAL and
    /// the classes that wants to call upon its services
    /// </summary>
    public class Service
    {
        private MemberDAL _memberDAL;

        public MemberDAL MemberDAL { get { return _memberDAL ?? (_memberDAL = new MemberDAL()); } }

        public void SaveMemberRegistry(MemberRegistry memberRegistry) 
        {
            MemberDAL.Save(memberRegistry);
        }

        public MemberRegistry LoadMemberRegistry()
        {
            return MemberDAL.Load();
        }

    }
}
