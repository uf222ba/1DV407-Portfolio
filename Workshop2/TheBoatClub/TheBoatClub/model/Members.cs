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
    class Members : ISerializable
    {
        private List<Member> m_members;

        public List<Member> MembersList
        {
            get { return m_members; }
            set { m_members = value; }
        }

        public Members()
        {
            m_members = new List<Member>();
        }
        public int getNewMemberNo()
        {
        // hitta det högsta medlemsnumret i listan
            List<int> tmp = new List<int>();

            foreach (var a_member in m_members)
            {
                tmp.Add(a_member.MemberNo);
            }

            tmp.Sort();
            return tmp.Last() + 1;
        }

        public Members(SerializationInfo a_info, StreamingContext a_ctext)
        {
            m_members = (List<Member>)a_info.GetValue("Members", typeof(List<Member>));
        }

        public void GetObjectData(SerializationInfo a_info, StreamingContext a_ctext)
        {
            a_info.AddValue("Members", m_members);
        }

    }
}