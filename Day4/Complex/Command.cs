using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLesson.Complex
{
    public enum Action { Add, Subtract, Exit }

    public class Command
    {
        public Command(string name, Action action)
        {
            Name = name;
            Action = action;
        }

        public string Name { get; set; }

        public Action Action { get; set; }
    }
}
