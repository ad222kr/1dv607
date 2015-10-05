using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Model
{
    public enum BoatType
    {
        Sailboat = 1,
        Kayak,
        Motorsailer,
        Other
    }
    [Serializable]
    public class Boat
    {
        private double _length;

        // TODO: Validation rules for boats
        public double Length 
        {
            get { return _length; } 
            set 
            {
                if (value < 0 || value > 50)
                {
                    throw new ArgumentOutOfRangeException("Length of the boat must be bigger than 0 and less than 50 meters");
                }
                _length = value;
            }
        }
        public BoatType Type { get; set; }

        public Boat()
        {

        }

        public Boat(double length, BoatType type)
        {
            Length = length;
            Type = type;
        }
    }
}
