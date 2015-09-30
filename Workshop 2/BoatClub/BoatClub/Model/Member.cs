using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Model
{
    public class Member
    {
        private string _firstName;
        private string _lastName;
        private string _socialSecurityNumber;
        private List<Boat> _boats;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Firstname cannot be empty");
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Lastname cannot be empty");
                }
                _lastName = value;
            }
        }
        public string SocialSecurityNumber 
        {
            get { return _socialSecurityNumber; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Social Security Number cannot be empty");
                }
                if (value.Length != 10 && value.Length != 12)
                {
                    throw new ArgumentOutOfRangeException("10 or 12 signs for social security number");
                }
                _socialSecurityNumber = value;
            }
        }

        public IReadOnlyCollection<Boat> Boats
        {
            get { return _boats; }
        }
        public int MemberID { get; set; }
        

        public Member(string firstName, string lastName, string socialSecurityNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
            _boats = new List<Boat>();
        }

        public void AddBoat(Boat boat)
        {
            //if (boat == null) return; // or throw exception?
            _boats.Add(boat);
        }
    }
}
