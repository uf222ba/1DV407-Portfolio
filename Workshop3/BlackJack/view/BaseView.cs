using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    abstract class BaseView : IView
    {
        public abstract void DisplayWelcomeMessage();
            
        public abstract void DisplayCard(model.Card a_card);
        public abstract void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score);
        public abstract void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score);
        public abstract void DisplayGameOver(bool a_dealerIsWinner);

        public Event GetInput()
        {
            Event e;
            ConsoleKeyInfo keyPressed = Console.ReadKey();

            switch (keyPressed.Key.ToString())
            {
                case "P":
                    e = Event.Play;
                    break;
                case "H":
                     e = Event.Hit;
                    break;
                case "S":
                    e = Event.Stand;
                    break;
                case "Q":
                    e = Event.Quit;
                    break;
                default:
                    e = Event.Play;
                    break;
            }
            return e;
        }
    }
}
