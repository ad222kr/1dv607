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
            var testMember = new Member("A", "S", "920616925311");
            var testMember2 = new Member("s", "ASD", "000000000110");
            var testMember3 = new Member("s", "ASD", "000000000111");
            testMember.MemberID = 2;
            testMember2.MemberID = 3;
            testMember3.MemberID = 78;
            _members.Add(testMember);
            _members.Add(testMember2);
            _members.Add(testMember3);
            
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

        internal static void AddMember(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
