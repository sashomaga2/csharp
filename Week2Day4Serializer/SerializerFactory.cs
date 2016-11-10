using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSerialization
{
    public enum SerializeType { Json, Xml }

    public static class SerializerFactory
    {
        public static ISerializer Create(SerializeType type)
        {
            if (type == SerializeType.Json)
            {
                return new MyJsonSerializer();
            }
            
            return new MyXmlSerializer();
        }
    }
}
