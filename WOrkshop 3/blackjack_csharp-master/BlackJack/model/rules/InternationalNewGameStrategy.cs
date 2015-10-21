using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : BaseNewGameStrategy, INewGameStrategy
    {

        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            Card c;

            /*
            c = a_deck.GetCard();
            c.Show(true);
            a_player.DealCard(c);
            */
            DealCard(a_player, a_deck, true);

            /*
            c = a_deck.GetCard();
            c.Show(true);
            a_dealer.DealCard(c);
            */
            DealCard(a_dealer, a_deck, true);
            /*
             * 
            c = a_deck.GetCard();
            c.Show(true);
            a_player.DealCard(c);
            */

            DealCard(a_player, a_deck, true);
            return true;
        }
    }
}
