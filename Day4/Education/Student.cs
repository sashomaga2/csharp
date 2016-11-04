using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;

namespace ClassesLesson.Education
{
    public class Student : Person
    {
        private static int _count;

        private List<Task> _tasks = new List<Task>();

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

        public void AddTask(Task task)
        {
            _tasks.Add(task);
        }

        public float GetAverageGrade()
        {
            return _tasks.Average(t => t.Grade);
        }

        public int GetTasksCount()
        {
            return _tasks.Count();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}