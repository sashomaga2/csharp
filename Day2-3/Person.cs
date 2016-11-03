using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLesson
{
    public class Person : IComparable<Person>
    {
        public static string DefaultName { get; } = "No name";
        public static int DefaultAge { get; } = 1;

        public Person()
        {
            Name = DefaultName;
            Age = DefaultAge;
        }

        public Person(string name, int age) : this(name)
        {
            if (age < 0)
            {
                throw new ArgumentException("Age can't be negative!");
            }
            Age = age;
        }

        public Person(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name can't be null or empty!");
            }

            Name = name;
            Age = 1;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            return Name.Length.CompareTo(other.Name.Length);
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }

        
    }
}
