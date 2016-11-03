using ClassesLesson;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLesson
{
    public class PersonSorter
    {
        private List<Person> data;

        public string EndCommand { get; } = "quit";

        public int MinAge { get; } = 18;

        public PersonSorter()
        {
            data = new List<Person>();
        }

        public void Read(IReader reader)
        {
            while (true)
            {
                var input = reader.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }

                if (input == EndCommand)
                {
                    break;
                }

                var parts = input.Split(new [] { "//" }, StringSplitOptions.None);
                int age;
                
                if (int.TryParse(parts[1], out age) && age > MinAge)
                {
                    data.Add(new Person(parts[0], age));
                }
            }
        }

        public void Sort()
        {
            // IComparable<Person>
            data.Sort();
            // Linq
            //data = data.OrderBy(p => p.Name.Length).ToList();
        }

        public void Write(IWriter writer)
        {
            data.ForEach(p => writer.WriteLine(p.ToString()));
        }
    }
}
