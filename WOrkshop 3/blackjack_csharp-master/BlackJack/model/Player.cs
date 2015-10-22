using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Player : ISubject
    {
        private List<Card> m_hand = new List<Card>();
        private List<IBlackJackObserver> m_observer = new List<IBlackJackObserver>();

        public void DealCard(Card a_card)
        {
            m_hand.Add(a_card);
            System.Threading.Thread.Sleep(2000);
            Notify();
        }

        public IEnumerable<Card> GetHand()
        {
            return m_hand.Cast<Card>();
        }

        public void ClearHand()
        {
            m_hand.Clear();
        }

        public void ShowHand()
        {
            foreach (Card c in GetHand())
            {
                c.Show(true);
            }
        }

        public int CalcScore()
        {
            int[] cardScores = new int[(int)model.Card.Value.Count]
                {2, 3, 4, 5, 6, 7, 8, 9, 10, 10 ,10 ,10, 11};
            int score = 0;

            foreach(Card c in GetHand()) {
                if (c.GetValue() != Card.Value.Hidden)
                {
                    score += cardScores[(int)c.GetValue()];
                }
            }

            if (score > 21)
            {
                foreach (Card c in GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace && score > 21)
                    {
                        score -= 10;
                    }
                }
            }

            return score;
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
