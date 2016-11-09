using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Collections
{
    public class Comperer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(Student obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
