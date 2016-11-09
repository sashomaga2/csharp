using ClassesLesson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Collections
{
    public class Api
    {
        private Dictionary<string, int> data = new Dictionary<string, int>();

        private string path = "data.txt";

        private IReader reader;

        public Api(IReader reader)
        {
            this.reader = reader;
        }

        public void Start()
        {
            ReadAndParseInput();
            Print();
        }

        private void Print()
        {
            data.OrderByDescending(i => i.Value)
                .ToList()
                .ForEach(e => Console.WriteLine($"word:{e.Key}, contains:{e.Value}"));
        }

        private void ParseLine(string line)
        {
            var parts = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in parts)
            {
                if (data.ContainsKey(word))
                {
                    data[word]++;
                }
                else
                {
                    data.Add(word, 1);
                }
            }
        }

        void ReadAndParseInput()
        {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    ParseLine(line);
                }   
        }
    }
}
