using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSerialization
{
    public interface ISerializer
    {
        string Serialize<T>(T[] data) where T : class;
    }
}
