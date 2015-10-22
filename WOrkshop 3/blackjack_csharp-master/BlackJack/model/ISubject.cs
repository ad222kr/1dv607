using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    interface ISubject
    {
        void Subsribe(IBlackJackObserver a_observer);
        void Unsubscribe(IBlackJackObserver a_observer);
        void Notify();
    }
}
