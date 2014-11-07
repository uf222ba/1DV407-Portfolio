using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TheBoatClub
{
    class Program
    {
        static void Main(string[] args)
        {
            model.Members m = new model.Members();
            
            // Lägger till medlemmar i listan eftersom jag inte fått till serialiseringen av listan till fil.
            m.MembersList.Add(new model.Member(0, "531029", "Pelle Svensson"));
            m.MembersList.Add(new model.Member(1, "750513", "Anna Nilsson"));
            m.MembersList[0].addBoat("Eka", 2);
            m.MembersList[0].addBoat("Segelbåt", 4);
            m.MembersList[1].addBoat("Motorbåt", 8);
            view.ListView v = new view.ListView(m);          
            controller.EditList ctrl = new controller.EditList(v);
            
            while(ctrl.MainMenu());         
        }
        
    }
}
