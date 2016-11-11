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
            var saver = new FileSaver();
            var parser = new HumanParser();
            var api = new PhoneBook(reader, saver, parser);
            api.Init();
            var data1 = api.Find("shmatkata");
            var json = api.Serialize(data1, SerializeType.Json);
            api.Save(json, @"../../test.json");
            var data2 = api.Find("Gancho");
            var xml = api.Serialize(Array.ConvertAll(data2, ih => (Human)ih), SerializeType.Xml);
            api.Save(xml, @"../../test.xml");
        }
    }
}
