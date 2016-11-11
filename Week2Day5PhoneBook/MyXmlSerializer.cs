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
        public string Serialize<T>(T[] data) where T : class
        {
            if (data == null)
            {
                throw new ArgumentException("Invalid serialization data");
            }

            try
            {
                //var xmlSerializer = new XmlSerializer(typeof(T[]));
                //var output = "";

                //using (var writer = XmlWriter.Create(output)) //"../../" + fileName
                //{
                //    xmlSerializer.Serialize(writer, data);
                //    return writer.ToString();
                //}

                XmlSerializer serializer = new XmlSerializer(typeof(T[]));

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
                settings.Indent = false;
                settings.OmitXmlDeclaration = false;


                using (StringWriter textWriter = new StringWriter())
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                    {
                        serializer.Serialize(xmlWriter, data);
                    }
                    return textWriter.ToString();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred during serialization", ex);
            }
        }
    }
}
