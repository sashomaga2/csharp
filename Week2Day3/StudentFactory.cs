using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Collections
{
    public class StudentFactory
    {
        public Student Create(string name)
        {
            return new Student(name);
        }
    }
}
