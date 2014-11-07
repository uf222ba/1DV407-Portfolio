using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBoatClub.controller
{
    class EditList
    {
        //model.Members m_members;
        view.ListView m_list;
        public EditList(view.ListView a_list)
        {
            //m_members = a_members;
            m_list = a_list;
        }

        public bool MainMenu()
        {
            string keyPressed;
            keyPressed = m_list.Start();

            switch(keyPressed)
            {
                case "K":
                    keyPressed = m_list.PrintCompactList();
                    break;
                case "F":
                    keyPressed = m_list.PrintCompleteList();
                    break;
                case "V":
                    // Välj medlem här
                    m_list.StartEditMember();
                    EditMenu();
                    break;
                case "L":
                    //Lägg till ny medlem;
                    m_list.AddNewMember();
                    break;
            }
            return keyPressed != "Q";
        }

        public void EditMenu()
        {
            string keyPressed;
            keyPressed = m_list.StartEditMember();
            
            switch (keyPressed)
            {
                case "E":   //Ändra medlem
                    
                    break;  
                case "D":   //Ta bort medlem
                    m_list.DeleteMember();
                    break; 
                case "L":   //Lägg till båt
                    
                    break;
                case "B":   //Ändra  båt
                    
                    break;
                case "T":   //Ändra  båt

                    break;
            }
        }
    }
}
