﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class PlayerWinnerStrategy : IWinnerStrategy
    {
        public bool IsDealerWinner(Dealer a_dealer, Player a_player, int g_maxScore)
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (a_dealer.CalcScore() > g_maxScore)
            {
                return false;
            }
            return !(a_player.CalcScore() >= a_dealer.CalcScore());
        }
    }
}
