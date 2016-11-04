using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLesson.Education
{
    public class CourseArgs
    {
        public int Capability { get; set; } = 10;

        public List<Student> Signed { get; set; } = new List<Student>();

        public string Name { get; set; }

        public int Duration { get; set; } = 5;
    }
}
