using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Model
{
    /// <summary>
    /// Class that holds the members. Changes occur here, but when 
    /// saving/deleting/updating member/boat this class gets serialized
    /// and saved to a text-file in binary for a simple persistance-storage.
    /// </summary>
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
            return _members.Max(x => x.MemberID) + 1;
        }

        public bool DeleteMemberByID(int memberID)
        {
            var member = _members.Find(x => x.MemberID == memberID);
            if (member == null)
            {
                return false;
            }
            _members.Remove(member);
            return true;
        }

        public Member GetMemberByID(int memberID)
        {
            var member = _members.Find(x => x.MemberID == memberID);
            if (member == null)
            {
                throw new ApplicationException("That member doesnt exist");
            }

            return member;

        }
    }
}
