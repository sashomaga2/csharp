using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLesson.Exceptions
{
    public class TaskWithSameNameAlreadyExists : Exception
    {
        public TaskWithSameNameAlreadyExists()
        {
        }

        public TaskWithSameNameAlreadyExists(string message) : base(message)
        {
        }

        public TaskWithSameNameAlreadyExists(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TaskWithSameNameAlreadyExists(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
