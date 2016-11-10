using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSerialization
{
    public interface ISerializer
    {
        void Serialize<T>(T[] data, string fileName) where T : class;
    }
}
