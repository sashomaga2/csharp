using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondWeek
{
    public interface ISorter<T> where T : struct, IComparable<T>
    {
        T[] Collection { get; }

        T[] Sort();
    }
}
