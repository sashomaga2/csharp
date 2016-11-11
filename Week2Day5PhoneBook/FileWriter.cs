using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSerialization
{
    public class FileSaver : ISaver
    {
        public void Save(string path, string text)
        {
            File.WriteAllText(path, text);
        }
    }
}
