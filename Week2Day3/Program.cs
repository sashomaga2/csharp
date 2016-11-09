using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Day3Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //var reader = new FileReader("data.txt");
            //var api = new Api(reader);
            //api.Start();


            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Catalog",
                    new XElement("Book", "book1"),
                    new XElement("Book", "book2"),
                    new XElement("Book", "book3"),
                    new XElement("Book", "book4")
                )
                );

            var data = GetData();

            var xmlserializer = new XmlSerializer(typeof(Student[]));
            string output = "";
            var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create("../../xmlBook.xml"))
            {
                
                xmlserializer.Serialize(writer, data);
                
                
                //Console.WriteLine(stringWriter.ToString()); 
            }

            doc.Save("../../xml.xml");
        }

        private static Student[] GetData()
        {
            var factory = new StudentFactory();
            return new Student[]
            {
                factory.Create("Pesho"),
                factory.Create("Gosho")
            };
        }
    }
}
