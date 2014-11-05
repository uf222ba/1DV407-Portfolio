using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            model.Game g = new model.Game();
            view.IView v = new view.SwedishView(); 
            controller.PlayGame ctrl = new controller.PlayGame(g, v);

            g.RegisterSubscriber(ctrl);
            while (ctrl.Play());
        }
    }
}
