using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.Controller;
using BoatClub.View;
namespace BoatClub
{
    class Program
    {
        static void Main(string[] args)
        {
            var appView = new AppView();
            var appController = new AppController(appView);
            
            appController.Start();
            
            

        }
    }
}
