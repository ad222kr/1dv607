﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player, ISubject
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;
        private List<IBlackJackObserver> m_observer = new List<IBlackJackObserver>();

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IEqualScoreWinStrategy m_equalScoreWinRule;


        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_equalScoreWinRule = a_rulesFactory.GetEqualScoreRule();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                DealCard(a_player, true);
                return true;
            }
            return false;
        }

        public bool Stand()
        {
            if (m_deck == null) return false;
            ShowHand();
            foreach (var card in GetHand())
            {
                card.Show(true);
            }
            
            while (m_hitRule.DoHit(this))
            {
                DealCard(this, true);
            }
            return true;
        }


        public bool IsDealerWinner(Player a_player)
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (CalcScore() > g_maxScore)
            {
                return false;
            }
            return m_equalScoreWinRule.DealerWins(CalcScore(), a_player.CalcScore());
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        public void DealCard(Player a_toGetCard, bool a_showCard)
        {
            var c = m_deck.GetCard();
            c.Show(a_showCard);
            a_toGetCard.DealCard(c);
            Notify();
        }
        public void Subsribe(IBlackJackObserver a_observer)
        {
            m_observer.Add(a_observer);
        }

        public void Unsubscribe(IBlackJackObserver a_observer)
        {
            m_observer.Remove(a_observer);
        }

        public void Notify()
        {
            m_observer.ForEach(x => x.CardDealt());
        }
    }
}
