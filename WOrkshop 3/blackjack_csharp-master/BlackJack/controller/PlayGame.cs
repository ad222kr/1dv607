using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame : model.IBlackJackObserver
    {
        private model.Game m_game;
        private view.IView m_view;

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            m_game = a_game;
            m_view = a_view;
            m_view.DisplayWelcomeMessage();
        }

        public bool Play()
        {
            m_game.Dealer.Subsribe(this);
            m_game.Player.Subsribe(this);
            
            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
                return false; // Else it loops 3 times and prints "Dealer/Player is winner" 3 times    
            }

            view.GameEvent input = m_view.GetInput();

            if (input == view.GameEvent.NewGame)
            {
                m_game.NewGame();
            }
            else if (input == view.GameEvent.Hit)
            {
                m_game.Hit();
            }
            else if (input == view.GameEvent.Stand)
            {
                m_game.Stand();
            }

            return input != view.GameEvent.Quit;
        }

        public void CardDealt()
        {
            m_view.DisplayWelcomeMessage(); // Since it Console.Clears every time, want to keep welcome-msg with instructions all the time
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
        }
    }
}
