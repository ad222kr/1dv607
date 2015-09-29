using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.Model;
namespace BoatClub
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new Member("Alex", "Hejsan", "9206169253");
            var boats = m.Boats;

            Console.WriteLine(m.Boats);
            

        }
    }
}
