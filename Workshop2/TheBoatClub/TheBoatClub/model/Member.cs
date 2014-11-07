using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace TheBoatClub.model
{
    [Serializable()]
    class Member : ISerializable
    {
        private int m_memberNo;
        private string m_socialSecNo;
        private string m_name;
        private List<Boat> m_boats;

        public Member()
        {
        }
        
        public Member(int a_memberNo, string a_socialSecNo, string a_name)
        {
            m_memberNo = a_memberNo;
            m_socialSecNo = a_socialSecNo;
            m_name = a_name;
            m_boats = new List<Boat>();
        }

        public int MemberNo
        {
            get
            {
                return m_memberNo;
            }
            set
            {
                m_memberNo = value;
            }
        }
        public string SocialSecNo
        {
            get
            {
                return m_socialSecNo;
            }
            set
            {
                m_socialSecNo = value;
            }
        }

        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }
      
        public List<Boat> getBoats()
        {
            return m_boats;
        }
        
        public void addBoat(string a_type, float a_length)
        {
            m_boats.Add(new Boat(a_type, a_length));
        }

        public int getNumberOfBoats()
        {
            return m_boats.Count;
        }

        public Member(SerializationInfo a_info, StreamingContext a_ctext)
        {
            m_memberNo = (int)a_info.GetValue("MemberNo", typeof(int));
            m_socialSecNo = (string)a_info.GetValue("SocialSecNo", typeof(string));
            m_name = (string)a_info.GetValue("Name", typeof(string));       
        }

        public void GetObjectData(SerializationInfo a_info, StreamingContext a_ctxt)
        {
            a_info.AddValue("MemberNo", m_memberNo);
            a_info.AddValue("SocialSecNo", m_socialSecNo);
            a_info.AddValue("Name", m_socialSecNo);
        }

    }
}
