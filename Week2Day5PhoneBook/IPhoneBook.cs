using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSerialization
{
    public interface IPhoneBook
    {
        IHuman[] Find(string name);

        IHuman[] Find(string name, string town);

        string Serialize(IHuman[] humans, SerializeType type);

        void Save(string @string, string fileName);

        void Add(IHuman human);
    }
}
