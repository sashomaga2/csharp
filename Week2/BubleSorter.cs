using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondWeek
{
    public class BubleSorter<T> : Sorter<T> where T : struct, IComparable<T>
    {
        public BubleSorter(T[] collection) : base(collection)
        {

        }

        public override T[] Sort()
        {
            var sorted = (T[])Collection.Clone();
            Array.Sort(sorted);
            return sorted;
        }
    }
}
