using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TheBoatClub.model
{

    [Serializable()]
    public class ObjectToSerialize : ISerializable
    {
        private List<Member> members;
        
        public List<Member> Members
        {
            get { return members; }
            set { members = value; }
        }

        public ObjectToSerialize()
        {
        }
    }
}
