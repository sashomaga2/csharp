using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Day2
{
    //public delegate void ChangeDelegate();

    public class ChangeTracker
    {
        public ChangeTracker()
        {
            List = new List<int>();
        }

        public List<int> List { get; set; }

        public event Action<int> OnChange;

        public void Add(int element)
        {
            List.Add(element);
            OnChange(element);
        }
    }
}
