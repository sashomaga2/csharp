using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesLesson.Exceptions;

namespace ClassesLesson.Education
{
    public class Task
    {
        private static List<string> usedNames;

        public Task(string name, float grade)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Task name can't be null or empty!");    
            }

            if (usedNames.Contains(name))
            {
                throw new TaskWithSameNameAlreadyExists($"Task name: {name}");
            }

            usedNames.Add(name);

            Name = name;
            Grade = grade;
            Created = DateTime.Now;
        }

        public float Grade { get; private set; }

        public string Name { get; private set; }

        public DateTime Created { get; private set; }  
    }
}
