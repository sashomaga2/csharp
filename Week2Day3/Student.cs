using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Collections
{
    [Serializable]
    public class Student : ICloneable
    {
        static int count = 0;

        public Student()
        {
            Id = count++;
            Name = "Default";
        }

        public Student(string name)
        {
            Id = count++;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
