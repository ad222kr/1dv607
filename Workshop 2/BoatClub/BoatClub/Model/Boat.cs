using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Model
{
    public enum BoatType
    {
        Sailboat,
        Kayak,
        Motorsailer,
        Other
    }
    [Serializable]
    public class Boat
    {
        public double Length { get; set; }
        public BoatType Type { get; set; }

        public Boat(double length, BoatType type)
        {
            Length = length;
            Type = type;
        }
    }
}
