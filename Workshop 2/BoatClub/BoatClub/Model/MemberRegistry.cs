using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Model
{
    [Serializable]
    public class MemberRegistry
    {
        private List<Member> _members;

        public IEnumerable<Member> Members
        {
            get { return _members.AsReadOnly(); }
        }
        public MemberRegistry()
        {
            _members = new List<Member>();
                   
        }
        

        public void SaveMember(Member member)
        {
            _members.Add(member);
        }

        public int GetUniqueMemberId()
        {
            var tempMembers = _members.OrderBy(x => x.MemberID).ToArray();
            int id = tempMembers[tempMembers.Length - 1].MemberID + 1;
            return id;


        }
    }
}
