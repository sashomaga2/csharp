using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondWeek.Interfaces;

namespace SecondWeek
{
    class Program
    {
        static void Main_old(string[] args)
        {
            // BUBLE 
            // SELECTION
            try
            {
                var consoleIO = new ConsoleIO();
                var api = new Api(consoleIO, consoleIO);

                IReader reader = new ConsoleIO();
                IWriter w = new ConsoleIO();

                reader.ReadLine();

                var  r = (IReader)w;
                r.ReadLine();



                api.Start<float>();

                
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong: {0}", e.Message);
            }

        }
    }
}
