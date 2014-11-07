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
    class Boat : ISerializable
    {
        private string m_type;
        private float m_length;
        
        public Boat()
        {
        }

        public Boat(string a_type, float a_length)
        {
            m_type = a_type;
            m_length = a_length;
        }

        public string Type
        {
            get
            {
                return m_type;
            }
            set
            {
                m_type = value;
            }
        }

        public float Length
        {
            get
            {
                return m_length;
            }
            set
            {
                m_length = value;
            }
        }
         public Boat(SerializationInfo a_info, StreamingContext a_ctext)
        {
            m_type = (string)a_info.GetValue("Type", typeof(string));
            m_length = (float)a_info.GetValue("Length", typeof(float));
        }

        public void GetObjectData(SerializationInfo a_info, StreamingContext a_ctxt)
        {
            a_info.AddValue("Type", m_type);
            a_info.AddValue("Length", m_length);
        }
    }
}
