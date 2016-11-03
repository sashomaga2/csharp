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
        private List<Person> list;

        public string EndCommand { get; } = "quit";

        public int MinAge { get; } = 18;

        public PersonSorter()
        {
            list = new List<Person>();
        }

        #region Methods

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

                SavePerson(input);
            }
        }

        private void SavePerson(string input)
        {
            var parts = input.Split(new[] {"//"}, StringSplitOptions.None);

            int age;
            if (int.TryParse(parts[1], out age) && age > MinAge)
            {
                list.Add(new Person(parts[0], age));
            }
        }


        public void Sort()
        {
            // IComparable<Person>
            list.Sort();
            // Linq
            //data = data.OrderBy(p => p.Name.Length).ToList();
        }

        public void Write(IWriter writer)
        {
            list.ForEach(p => writer.WriteLine(p.ToString()));
        }

        #endregion
    }
}
