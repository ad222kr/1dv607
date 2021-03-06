﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Model
{
    [Serializable]
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
                _firstName = value;
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

        public ReadOnlyCollection<Boat> Boats
        {
            get { return _boats.AsReadOnly(); }
        }
        public int MemberID { get; set; }
        

        public Member(string firstName, string lastName, string socialSecurityNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
            _boats = new List<Boat>();
        }

        public Member()
        {
            _boats = new List<Boat>();
        }

        public void AddBoat(Boat boat)
        {
            _boats.Add(boat);
        }

        public void RemoveBoatByIndex(int index)
        {
            _boats.RemoveAt(index);
        }

        public Boat GetBoatByIndex(int index)
        {
            return _boats.ElementAt(index);
        }
    }
}
