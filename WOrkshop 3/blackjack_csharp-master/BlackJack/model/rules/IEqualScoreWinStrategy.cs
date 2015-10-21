using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface IEqualScoreWinStrategy
    {
        bool DealerWins(int a_dealerScore, int a_playerScore);
    }
}
