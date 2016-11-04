using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLesson.Exceptions
{
    public class StudentIsBusy : Exception
    {
        public StudentIsBusy()
        {
        }

        public StudentIsBusy(string message) : base(message)
        {
        }

        public StudentIsBusy(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StudentIsBusy(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
