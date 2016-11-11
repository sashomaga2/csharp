using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSerialization
{
    public class ObjectValidator
    {
        public void NullObjectCheck(object obj, string errorMessage)
        {
            if (obj == null)
            {
                throw new NullReferenceException(errorMessage);
            }
        }
    }
}
