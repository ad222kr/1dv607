using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class DealerWinsOnEqualScoreStrategy : IEqualScoreWinStrategy
    {
        public bool DealerWins(int a_dealerScore, int a_playerScore)
        {
            return a_dealerScore >= a_playerScore;
        }
    }
}
