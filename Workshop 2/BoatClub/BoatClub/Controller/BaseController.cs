using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.View;

namespace BoatClub.Controller
{
    public abstract class BaseController
    {
        public void Start(BaseView view)
        {
            view.Show();
            Event e = view.GetEvent();
            ManageEventChoice(e);
        }

        public abstract void ManageEventChoice(Event appEvent);
    }
}
