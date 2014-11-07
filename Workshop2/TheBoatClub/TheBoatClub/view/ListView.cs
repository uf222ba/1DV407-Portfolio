using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBoatClub.view
{
    class ListView
    {
        model.Members m_members;
        int m_memberNo;

        public ListView(model.Members a_members)
        {
            m_members = a_members;
        }
        public void PrintMainMenu()
        {
            Console.WriteLine("Välj alternativ\n-----------------------------");
            Console.WriteLine(" k: Visa kompakt lista\n f: Visa fullständig lista\n v: Visa/redigera/ta bort medlemsuppgifter\n l: Lägg till ny medlem\n q: Avsluta");
        }
        public void PrintEditMenu()
        {
            Console.WriteLine("Välj alternativ för medlem\n-----------------------------");
            Console.WriteLine(" e: Ändra\n d: Ta bort\n l: Lägg till båt\n r: Ändra båt\n t: Ta bort båt\n q: Tillbaka");
        }

        private string GetKeyInput()
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            return keyPressed.Key.ToString();
        }

        private string GetInput()
        {
            return Console.ReadLine();
        }

        public string Start()
        {
            PrintMainMenu();
            return GetKeyInput();
        }

        public string PrintCompactList()
        {
            Console.Clear();
            Console.WriteLine("Kompakt lista över medlemmar");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Namn\t\t\tMedlemsnr\tAntal båtar");
            Console.WriteLine("---------------------------------------------------------------");
            foreach (var a_member in m_members.MembersList)
            {
                Console.WriteLine("{0}\t{1}\t{2}", a_member.Name, a_member.MemberNo, a_member.getNumberOfBoats());
            }
            Console.WriteLine("---------------------------------------------------------------\n");
            return Start();
        }

        public string PrintCompleteList()
        {
            Console.Clear();
            Console.WriteLine("Fullständig lista över medlemmar och deras båtar");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Namn\t\tPersonnr\tMedlemsnr\tAntal båtar");
            Console.WriteLine("---------------------------------------------------------------");
            foreach (var a_member in m_members.MembersList)
            {
                Console.WriteLine("{0}\t\t{1}\t{2}", a_member.Name, a_member.SocialSecNo, a_member.MemberNo);
                PrintBoats(a_member);
            }
            Console.WriteLine("---------------------------------------------------------------\n");
            return Start();
        }

        public string StartEditMember()
        {
            GetMemberToEdit();
            PrintEditMenu();           
            return GetKeyInput();
        }

        public void GetMemberToEdit()
        {
            Console.Clear();
            Console.Write("Välj medlem (ange medlemsnr): ");
            m_memberNo = int.Parse(GetInput());
            Console.WriteLine("\n---------------------------------------------------------------");
            Console.WriteLine("Medlemsnr:\t{0}", m_members.MembersList[m_memberNo].MemberNo);
            Console.WriteLine("Personnr:\t{0}", m_members.MembersList[m_memberNo].SocialSecNo);
            Console.WriteLine("Namn:\t\t{0}", m_members.MembersList[m_memberNo].Name);
            Console.WriteLine("\nRegistrerade båtar: ");
            PrintBoats(m_members.MembersList[m_memberNo]);
            Console.WriteLine("---------------------------------------------------------------\n");
        }

        private void PrintBoats(model.Member a_member)
        {
            List<model.Boat> a_boatList = a_member.getBoats();
            int i = 1;
            foreach (var a_boat in a_boatList)
            {
                Console.WriteLine("\t{0}. Båttyp: {1}\tLängd: {2}", i, a_boat.Type, a_boat.Length);
                i++;
            }
        }

        // Lägg till ny användare
        public void AddNewMember()
        {
            string name;
            string socialSecNo;
            m_memberNo = m_members.getNewMemberNo();
                        
            Console.WriteLine("Lägg till ny medlem");
            Console.WriteLine("---------------------------------------------------------------");
            Console.Write("Skriv in förnamn och efternamn: ");
            name = GetInput();
            Console.Write("Skriv in personnr: ");
            socialSecNo = GetInput();
            Console.Write("Ditt medlemsnr är {0}\n", m_memberNo);

            m_members.MembersList.Add(new model.Member(m_memberNo, socialSecNo, name));

        }

        // Metod för att Ta bort användaren
        public void DeleteMember()
        {
            m_members.MembersList.RemoveAt(m_memberNo);
        }
        
        // Metod för att Ändra medlemsuppgifter
        public void UpdateMember()
        {
            
        }

        // Metod för att lägga till båt
        public void AddNewBoat()    
        {
            string type;
            float length;

            Console.WriteLine("Lägg till ny båt");
            Console.WriteLine("---------------------------------------------------------------");
            Console.Write("Båttyp: ");
            type = GetInput();
            Console.Write("Ange båtens längd: ");
            length = float.Parse(GetInput());
            
            // Hitta rätt index i listan för att kunna lägga till båtar på rätt medlem
            //m_members.MembersList.Contains(new model.Member { MemberNo = m_memberNo });
            //(new model.Boat(type, length))
        }
               
        // Metod för att Ändra båt
        public void UppdateBoat()
        {
        
        }

        // Metod för att Ta bort båt
        public void DeleteBoat()    
        {

        }


       

    }
}
