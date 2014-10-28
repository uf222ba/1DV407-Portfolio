using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BlackJack.view;

namespace BlackJack.controller
{
    class PlayGame : model.ICardDealedListener
    {
        private model.Game m_game;
        private view.IView m_view;
       
        public PlayGame(model.Game a_game, view.IView a_view)
        {
            m_game = a_game;
            m_view = a_view;
        }

        public bool Play()
        {
            DisplayInformation();

            int input = m_view.GetInput();

            switch (input)
            {
                case 'p':
                    m_game.NewGame();
                    break;
                case 'h':
                    m_game.Hit();
                    break;
                case 's':
                    m_game.Stand();
                    break;
                case 'q':
                    return false;
            }
                                                         
            //switch (m_view.GetEvent())
            //{
            //    case Event.Play:
            //        m_game.NewGame();
            //        break;
            //    case Event.Hit:
            //        m_game.Hit();
            //        break;
            //    case Event.Stand:
            //        m_game.Stand();
            //        break;
            //    case Event.Quit:
            //        return false;
            //}
            return true;
        } 

        public void CardDealed()
        {
            Thread.Sleep(2000); // Är det här själva fördröjningen ska ske?
        }
        private void DisplayInformation()
        {
            m_view.DisplayWelcomeMessage();          
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }
        }
    }
}
