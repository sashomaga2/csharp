using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLesson
{
    public static class ReadHelper
    {
        public static string[] SplitInput(string input, int expectedLength, string delimiter)
        {
            var parts = input.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
            if (expectedLength != parts.Length)
            {
                throw new ArgumentException("Invalid input!");
            }
            return parts;
        }

        public static int ParseIntSave(string str, string variable)
        {
            int num;
            if (!int.TryParse(str, out num))
            {
                throw new ArgumentException("{0} must be number!", variable);
            }
            return num;
        }

        public static float ParseFloatSave(string str, string variable)
        {
            float num;
            if (!float.TryParse(str, out num))
            {
                throw new ArgumentException("{0} must be number!", variable);
            }
            return num;
        }

        public static string GetInputRow(IReader reader)
        {
            var input = reader.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input can't be null or empty");
            }
            return input;
        }
    }
}
