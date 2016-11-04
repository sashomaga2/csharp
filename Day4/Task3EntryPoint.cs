using ClassesLesson.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLesson
{
    public class Task3EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                var consoleIO = new ConsoleIO();
                var calc = new CompexCalculator(consoleIO, consoleIO);

                calc.Start();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Something went wrong: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something bad happaned: {0}", e.Message);
            }
        }
    }
}
