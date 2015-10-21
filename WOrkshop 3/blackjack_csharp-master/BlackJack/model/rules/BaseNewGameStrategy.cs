using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    abstract class BaseNewGameStrategy
    {
        protected void DealCard(Player a_toGetCard, Deck a_deck, bool a_showCard)
        {
            var c = a_deck.GetCard();
            c.Show(a_showCard);
            a_toGetCard.DealCard(c);
        }
    }
}
