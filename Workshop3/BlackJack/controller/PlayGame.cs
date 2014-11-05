using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.view;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame : model.ICardDealtListener
    {
        model.Game m_game;
        view.IView m_view;

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            m_game = a_game;
            m_view = a_view;
        }

        public bool Play()
        {
            m_view.DisplayWelcomeMessage();
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }

            Event input = m_view.GetInput();

            switch (input)
            {
                case Event.Play:
                    m_game.NewGame();
                    break;
                case Event.Hit:
                    m_game.Hit();
                    break;
                case Event.Stand:
                    m_game.Stand();
                    break;
            }

            return input != Event.Quit;
        }

        public void CardDealt() // Anrop från metoden DealCard i klassen Player i modellen
        {
            Thread.Sleep(2000);
        }
    }
}
