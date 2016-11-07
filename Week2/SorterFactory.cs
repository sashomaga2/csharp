using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondWeek
{
    public class SorterFactory
    {
        public Sorter<T> Create<T>(SortType sortType, T[] collection) where T : struct, IComparable<T>
        {
            if (sortType == SortType.Buble)
            {
                return new BubleSorter<T>(collection);
            }

            if (sortType == SortType.Selection)
            {
                return new SelectionSorter<T>(collection);
            }

            throw new InvalidOperationException("Not supported type!");
        }
    }
}
