using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondWeek.Aritmetic
{
    public enum OperationType
    {
        Add,
        Subtract,
        Multiplay
    }

    public class Calculator
    {
        public int Add(int n1, int n2)
        {
            return n1 + n2;
        }

        public int Subtract(int n1, int n2)
        {
            return n1 - n2;
        }

        public int Multiplay(int n1, int n2)
        {
            return n1 * n2;
        }
    }
}
