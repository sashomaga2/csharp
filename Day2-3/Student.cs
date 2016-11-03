using System.Diagnostics.PerformanceData;

namespace ClassesLesson
{
    public class Student : Person
    {
        private static int _count;

        public Student() 
        {
            SetId();
        }

        public Student(string name) : base(name) 
        {
            SetId();
        }

        public Student(string name, int age) : base(name, age)
        {
            SetId();
        }

        private void SetId()
        {
            Id = _count++;
        }

        public int? CourseId { get; set; }

        public int Id { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}