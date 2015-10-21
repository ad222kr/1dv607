using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class SoftSeventeenHitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(Player a_dealer)
        {
            if (a_dealer.CalcScore() == g_hitLimit)
            {
                return DealerHasAceInHand(a_dealer.GetHand());
            }
            return a_dealer.CalcScore() < g_hitLimit;

        }

        private bool DealerHasAceInHand(IEnumerable<Card> a_hand)
        {
            foreach (var card in a_hand)
            {
                if (card.GetValue() == BlackJack.model.Card.Value.Ace)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
