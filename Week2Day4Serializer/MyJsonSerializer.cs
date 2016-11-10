using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace JSONSerialization
{
    public class MyJsonSerializer : ISerializer
    {
        public void Serialize<T>(T[] data, string fileName) where T : class 
        {
            if (data == null || string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Invalid serialization data");
            }

            try
            {
                using (StreamWriter file = File.CreateText("../../" + fileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, data);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred during serialization", ex);
            }
        }
    }
}
