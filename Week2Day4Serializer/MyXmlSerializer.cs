using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace JSONSerialization
{
    public class MyXmlSerializer : ISerializer
    {
        public void Serialize<T>(T[] data, string fileName) where T : class
        {
            if (data == null || string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Invalid serialization data");
            }

            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T[]));

                using (var writer = XmlWriter.Create("../../" + fileName))
                {
                    xmlSerializer.Serialize(writer, data);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred during serialization", ex);
            }
        }
    }
}
