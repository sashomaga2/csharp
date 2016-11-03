using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLesson
{
    public class Academy
    {
        private Student[] _students;

        private Course[] _cources;

        private readonly string _exitCommand = "quit";

        private readonly string _inputDelimiter = "//";

        private readonly IReader _reader;

        private readonly IWriter _writer;

        public Academy(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public void Init()
        {
            SetCourcesCount();
            SetCoursesData();
            SetStudentsCount();
            SetStudentsData();
            StudentsSignToCourses();
            Print();
        }

        private void Print()
        {
            _cources.ToList().ForEach(c =>
            {
                _writer.WriteLine(c.ToString());
                c.GetSignedStudents().ForEach(s => _writer.WriteLine(s.ToString()));
            });
        }

        private void StudentsSignToCourses()
        {
            _writer.WriteLine("Students sign to courses formated: studentID//courseID");
            while (true)
            {
                var input = GetInputRow();

                if (input == _exitCommand)
                {
                    break;
                }

                AddStudentToCourse(input);
            }
        }

        private Student GetStudentById(int id)
        {
            var student = _students.SingleOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new InvalidOperationException("Student does not exist");
            }
            return student;
        }

        private Course GetCourseById(int id)
        {
            var course = _cources.SingleOrDefault(c => c.Id == id);
            if (course == null)
            {
                throw new InvalidOperationException("Course does not exist");
            }
            return course;
        }

        private void AddStudentToCourse(string input)
        {
            var parts = SplitInput(input, 2);
            var studentId = ParseIntSave(parts[0], "StudentId");
            var student = GetStudentById(studentId);
            var courseId = ParseIntSave(parts[1], "CourseId");
            var course = GetCourseById(courseId);
            
            if (student.CourseId == null)
            {
                course.Add(student);
                student.CourseId = courseId;
            }
            else
            {
                throw new InvalidOperationException($"Student {student.ToString()} already subscribed to course {student.CourseId}");
            }
        }

        private void SetStudentsData()
        {
            _writer.WriteLine("Enter students data formated name//age");
            for (var i = 0; i < _students.Length; i++)
            {
                var input = GetInputRow();
                var parts = SplitInput(input, 2);

                _students[i] = new Student(parts[0], ParseIntSave(parts[1], "Students Count"));
            }
        }

        private string[] SplitInput(string input, int expectedLength)
        {
            var parts = input.Split(new[] { _inputDelimiter }, StringSplitOptions.RemoveEmptyEntries);
            if (expectedLength != parts.Length)
            {
                throw new ArgumentException("Invalid input!");
            }
            return parts;
        }

        private void SetStudentsCount()
        {
            _writer.WriteLine("Enter students count: ");
            var input = GetInputRow();
            _students = new Student[ParseIntSave(input, "Students Count")];
        }

        private void SetCoursesData()
        {
            _writer.WriteLine("Enter course data formated courseName//duration//capacity");

            for (var i = 0; i < _cources.Length; i++)
            {
                var input = GetInputRow();
                var parts = SplitInput(input, 3);
                
                _cources[i] = new Course(new CourseArgs() { Name = parts[0],
                                                            Duration = ParseIntSave(parts[1], "Duration"),
                                                            Capability = ParseIntSave(parts[2], "Capability") });
            }
        }

        private int ParseIntSave(string str, string variable)
        {
            int num;
            if (!int.TryParse(str, out num))
            {
                throw new ArgumentException("{0} must be number!", variable);
            }
            return num;
        }

        private string GetInputRow()
        {
            var input = _reader.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input can't be null or empty");
            }
            return input;
        }

        private void SetCourcesCount()
        {
            _writer.WriteLine("Enter course count:");
            var input = GetInputRow();

            _cources = new Course[ParseIntSave(input, "Course count")];
        }
    }
}
