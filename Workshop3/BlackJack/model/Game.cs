using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Game
    {
        private List<ICardDealedListener> m_subscriber; // Observer
        private model.Dealer m_dealer;
        private model.Player m_player;

        public Game()
        {
            m_dealer = new Dealer(new rules.RulesFactory());
            m_player = new Player();
            m_subscriber = new List<ICardDealedListener>();   //Observer
        }

        public void Register(ICardDealedListener a_subscriber)   //Observer
        {
            m_subscriber.Add(a_subscriber);
        }
                
        public bool IsGameOver()
        { 
            return m_dealer.IsGameOver();
        }

        public bool IsDealerWinner()
        {
            return m_dealer.IsDealerWinner(m_player);
        }

        public bool NewGame()
        {
            return m_dealer.NewGame(m_player);
        }

        public bool Hit()
        {
            m_subscriber.ForEach(delegate()) {
            
            }
            return m_dealer.Hit(m_player);
        }

        /// <summary>
        /// Stand är implementerad i ws 3
        /// </summary>
        /// <returns></returns>
        public bool Stand()
        {
            return m_dealer.Stand();
        }

        public IEnumerable<Card> GetDealerHand()
        { 
            return m_dealer.GetHand();
        }

        public IEnumerable<Card> GetPlayerHand()
        {
            return m_player.GetHand();
        }

        public int GetDealerScore()
        {
            return m_dealer.CalcScore();
        }

        public int GetPlayerScore()
        {
            return m_player.CalcScore();
        }
    }
}
