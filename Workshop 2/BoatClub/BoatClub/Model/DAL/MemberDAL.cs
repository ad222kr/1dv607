using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BoatClub.Model.DAL
{
    public class MemberDAL
    {
        private static readonly string fileName = "members.bin";
        private static readonly string path = "../../data/";

        public void Save(MemberRegistry memberRegistry)
        {
            Serialize(memberRegistry);    
        }

        public MemberRegistry Load()
        {
            return Deserialize<MemberRegistry>();
        }

        private void Serialize<T>(T objectToSerialize)
        {
            using (Stream stream = File.Open(path + fileName, FileMode.Create)) 
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToSerialize);
            }
        }

        private T Deserialize<T>()
        {
            
            using (Stream stream = File.Open(path + fileName, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
            

        }
        
    }
}
