using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Day2
{
    class Program
    {
        public static void Main()
        {
            

            var list = new GenericList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            //list.Add(9);

            //list.Remove(9);
            //list.Add(10);
            //list.Add(11);
            //list.Add(12);
            //list.Add(13);

            list.Insert(7, 5);


            Console.WriteLine(string.Join(",", list));
            //list.Clear();

            List<int> l = new List<int>();
            //l.Insert(10, 5);
            
        }
        
    }
}
