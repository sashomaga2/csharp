using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondWeek
{
    public class Sorter<T> : ISorter<T> where T : struct, IComparable<T>
    {
        public T[] Collection { get; private set; }

        public Sorter(T[] collection)
        {
            this.Collection = collection;
        }

        public virtual T[] Sort()
        {
            var sorted = (T[])Collection.Clone();
            Array.Sort(sorted);
            return sorted;
        }
    }
}
