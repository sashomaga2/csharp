using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLesson
{
    public class Course
    {
        private static int _count;

        private readonly List<Student> _signed;

        public Course(CourseArgs args)
        {
            if(string.IsNullOrEmpty(args.Name))
            {
              throw new ArgumentException("Course must have name!");  
            }

            _signed = args.Signed;
            Id = _count++;
            Name = args.Name;
            Capacity = args.Capability;
            Duration = args.Duration;
        }

        #region Props

        public int Id { get; private set; }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Duration { get; private set; }   

        #endregion

        #region Methods
        
        public void Add(Student student)
        {
            if (_signed.Count >= Capacity)
            {
                throw new CourseFullException($"Course {Name} is already full!");
            }

            _signed.Add(student);
        }

        public void Remove(Student student)
        {
            _signed.Remove(student);
        }

        public bool Exists(string name)
        {
            return _signed.Any(s => s.Name == name);
        }

        public override string ToString()
        {
            return Name;
        }

        public List<Student> GetSignedStudents()
        {
            return _signed;
        }

        #endregion
    }
}
