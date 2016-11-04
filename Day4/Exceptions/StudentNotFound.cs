using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLesson.Exceptions
{
    public class StudentNotFound : Exception
    {
        public StudentNotFound()
        {
        }

        public StudentNotFound(string message) : base(message)
        {
        }

        public StudentNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StudentNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
