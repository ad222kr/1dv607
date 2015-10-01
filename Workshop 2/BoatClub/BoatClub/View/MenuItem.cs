using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    /// <summary>
    /// Encapsulates an Event and holds its name for presentation
    /// </summary>
    class MenuItem
    {
        private Event _event;
        private string _eventName;

        public Event Event { get { return _event; } }
        public String EventName { get { return _eventName; } }

        public MenuItem(Event ev, string eventName)
        {
            _event = ev;
            _eventName = eventName;
        }
    }
}
