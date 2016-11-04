using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesLesson.Education;
using ClassesLesson.Exceptions;

namespace ClassesLesson
{
    class Task2EntryPoint
    {
        static void Main_Task2(string[] args)
        {
            /* First Task */
            try
            {
                Person p1;
                p1 = new Person();
                Console.WriteLine(p1.ToString());
                p1 = new Person("Sasho");
                Console.WriteLine(p1.ToString());
                p1 = new Person("Sasho", 20);
                Console.WriteLine(p1.ToString());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Something went wrong: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something bad happaned: {0}", e.Message);
            }

            /* Second Task */
            try
            {
                var personSorter = new PersonSorter();
                var consoleIO = new ConsoleIO();

                personSorter.Read(consoleIO);
                personSorter.Sort();
                personSorter.Write(consoleIO);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Something went wrong: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something bad happaned: {0}", e.Message);
            }

            /* Third Task */
            try
            {
                var consoleIO = new ConsoleIO();
                var academy = new Academy(consoleIO, consoleIO);
                academy.Init();
            }
            catch (CourseNotFound e)
            {
                Console.WriteLine("Something went wrong: {0}", e.Message);
            }
            catch (PersonAgeException e)
            {
                Console.WriteLine("Something went wrong: {0}", e.Message);
            }
            catch (StudentIsBusy e)
            {
                Console.WriteLine("Something went wrong: {0}", e.Message);
            }
            catch (StudentNotFound e)
            {
                Console.WriteLine("Something went wrong: {0}", e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Something went wrong: {0}", e.Message);
            }
            catch (InvalidOperationException e)
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
