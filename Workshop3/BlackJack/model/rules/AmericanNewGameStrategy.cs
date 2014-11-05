﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : INewGameStrategy
    {
        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            Card c;

            a_dealer.Deal(a_player, true);
            a_dealer.Deal(a_dealer, true);
            a_dealer.Deal(a_player, true);
            a_dealer.Deal(a_dealer, false);
            
            return true;
        }
    }
}
