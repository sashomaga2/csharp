using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day3Collections;
using Newtonsoft.Json;

namespace JSONSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new FileReader("phones.txt");
            var api = new Api(reader);
            api.Init();
            api.Serialize("shmatkata", "test.json", SerializeType.Json);
            api.Serialize("Gancho", "test.xml", SerializeType.Xml);
        }
    }
}
