using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLesson.Exceptions
{
    public class CourseNotFound : Exception
    {
        public CourseNotFound()
        {
        }

        public CourseNotFound(string message) : base(message)
        {
        }

        public CourseNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CourseNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
