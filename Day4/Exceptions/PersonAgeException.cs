using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLesson.Exceptions
{
    public class PersonAgeException : Exception
    {
        public PersonAgeException()
        {
        }

        public PersonAgeException(string message) : base(message)
        {
        }

        public PersonAgeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PersonAgeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
