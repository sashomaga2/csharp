//using ClassesLesson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSerialization
{
    public class FileReader : IReader, IDisposable
    {
        private StreamReader sr;

        public FileReader(string path)
        {
            sr = new StreamReader(path);
        }

        public void Dispose()
        {
            sr.Dispose();
        }

        public string ReadLine()
        {
            return sr.ReadLine();
        }
        
    }
}
