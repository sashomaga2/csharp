using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLesson
{
    public class CourseFullException : Exception
    {
        public CourseFullException()
        {
        }

        public CourseFullException(string message) : base(message)
        {
        }

        public CourseFullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CourseFullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
