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
            m_game.Subsribe(this);
            

        }

        public bool Play()
        {

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
                System.Threading.Thread.Sleep(1000);
                if (m_game.IsGameOver())
                {
                    m_view.DisplayGameOver(m_game.IsDealerWinner());
                }
            }
            
            return input != view.GameEvent.Quit;
        }

        public void CardDealt()
        {
            m_view.DisplayWelcomeMessage(); // Since it Console.Clears every time, want to keep welcome-msg with instructions all the time
            
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
            System.Threading.Thread.Sleep(1000);
            
            
            
        }
    }
}
