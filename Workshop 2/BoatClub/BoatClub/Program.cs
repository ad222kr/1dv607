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
            var memberView = new MemberView();
            var boatView = new BoatView();
            var memberController = new MemberController(memberView);
            var boatController = new BoatController(boatView);
            var appController = new AppController(appView, boatController, memberController);
            
            appController.Start();

        }
    }
}
