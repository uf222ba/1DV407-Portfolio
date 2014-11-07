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
    class Serializer
    {
        public void SerializeObject(string a_filename, Members a_objectToSerialize)
        {
            Stream a_stream = File.Open(a_filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(a_stream, a_objectToSerialize);
            a_stream.Close();
        }

        public Members DeSerializeObject(string a_filename)
        {
            Members a_objectToSerialize;
            Stream a_stream = File.Open(a_filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            a_objectToSerialize = (Members)bFormatter.Deserialize(a_stream);
            a_stream.Close();
            return a_objectToSerialize;
        }
    }
}
