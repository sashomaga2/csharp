using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondWeek
{
    public class SelectionSorter<T> : Sorter<T> where T : struct, IComparable<T>
    {
        public SelectionSorter(T[] collection) : base(collection)
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
