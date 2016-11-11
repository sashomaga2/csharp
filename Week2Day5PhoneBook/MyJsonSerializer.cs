using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace JSONSerialization
{
    public class MyJsonSerializer : ISerializer
    {
        public string Serialize<T>(T[] data) where T : class 
        {
            if (data == null)
            {
                throw new ArgumentException("Invalid serialization data");
            }

            try
            {
                //using (StreamWriter writer = File.CreateText("../../" + fileName)) //
                //{
                //    JsonSerializer serializer = new JsonSerializer();
                //    serializer.Serialize(writer, data);
                //}
                return JsonConvert.SerializeObject(data);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred during serialization", ex);
            }
        }
    }
}
