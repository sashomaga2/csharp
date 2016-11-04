using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ClassesLesson.Exceptions;

namespace ClassesLesson.Education
{
    public class Academy
    {
        private Student[] _students;

        private Course[] _cources;

        //TODO use command
        private readonly string _exitCommand = "quit";

        private readonly string _inputDelimiter = "//";

        private readonly int _gradeLimit = 95;

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
            SetTasksData();
            PrintOutput();
        }

        private void PrintOutput()
        {
            var studentsOutput = _students.Select( s => new { Name = s.Name, AverageGrade = s.GetAverageGrade() })
                                    .Where(s => s.AverageGrade > _gradeLimit)
                                    .OrderBy(s => s.Name)
                                    .ThenBy(s => s.AverageGrade)
                                    .Select(s => $"{s.Name} + {s.AverageGrade}")
                                    .ToList();

            PrintList(studentsOutput);

            var courseOutput = (from s in _students
                           join c in _cources
                           on s.CourseId equals c.Id
                           where s.GetAverageGrade() > _gradeLimit
                           group c by s.GetTasksCount() into g
                           select new { tasksCount = g.Key, course = g.ToList().First() } into gr
                           orderby gr.course.Name, gr.tasksCount
                           select gr.course.Name).Take(3).ToList();

            PrintList(courseOutput);
        }

        private void PrintList(List<string> list)
        {
            list.ForEach(l => _writer.WriteLine(l));
        }

        private void SetTasksData()
        {
            _writer.WriteLine("Enter tasks data: studentID//courseID//taskName//score");
            while (true)
            {
                var input = ReadHelper.GetInputRow(_reader);

                if (input == _exitCommand)
                {
                    break;
                }

                DoSetTasksData(input);
            }
        }

        private void DoSetTasksData(string input)
        {
            //studentId courseId taskName//score
            var parts = ReadHelper.SplitInput(input, 4, _inputDelimiter);
            var studentId = ReadHelper.ParseIntSave(parts[0], "StudentId");
            var student = GetStudentById(studentId);
            var courseId = ReadHelper.ParseIntSave(parts[1], "CourseId");

            if(student.CourseId != courseId)
            {
                // TODO custom exception
                throw new InvalidOperationException($"Student with id: {studentId} is not sign to course with id: {courseId}");
            }

            student.AddTask(new Task(parts[2], ReadHelper.ParseFloatSave(parts[3], "Task Id")));
        }

        private Student GetStudentById(int id)
        {
            var student = _students.SingleOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new StudentNotFound($"Student with {id} does not exists!");
            }
            return student;
        }

        private Course GetCourseById(int id)
        {
            var course = _cources.SingleOrDefault(c => c.Id == id);
            if (course == null)
            {
                throw new CourseNotFound($"Course with {id} does not exists!");
            }
            return course;
        }

        private void SignStudentToCourse(Student student, int courseId)
        {
            var course = GetCourseById(courseId);
            
            if (student.CourseId == null)
            {
                course.Add(student);
                student.CourseId = courseId;
            }
            else
            {
                throw new StudentIsBusy($"Student {student.ToString()} already subscribed to course {student.CourseId}");
            }
        }

        private void SetStudentsData()
        {
            _writer.WriteLine("Enter students data formated name//courseId");
            for (var i = 0; i < _students.Length; i++)
            {
                var input = ReadHelper.GetInputRow(_reader);
                var parts = ReadHelper.SplitInput(input, 2, _inputDelimiter);

                var student = new Student(parts[0]);
                _students[i] = student;
                SignStudentToCourse(student, ReadHelper.ParseIntSave(parts[1], "CourseId"));
            }
        }

        private void SetStudentsCount()
        {
            _writer.WriteLine("Enter students count: ");
            var input = ReadHelper.GetInputRow(_reader);
            _students = new Student[ReadHelper.ParseIntSave(input, "Students Count")];
        }

        private void SetCoursesData()
        {
            _writer.WriteLine("Enter course data formated courseName//duration//capacity");

            for (var i = 0; i < _cources.Length; i++)
            {
                var input = ReadHelper.GetInputRow(_reader);
                var parts = ReadHelper.SplitInput(input, 3, _inputDelimiter);
                
                _cources[i] = new Course(new CourseArgs() { Name = parts[0],
                                                            Duration = ReadHelper.ParseIntSave(parts[1], "Duration"),
                                                            Capability = ReadHelper.ParseIntSave(parts[2], "Capability") });
            }
        }

        private void SetCourcesCount()
        {
            _writer.WriteLine("Enter course count:");
            var input = ReadHelper.GetInputRow(_reader);

            _cources = new Course[ReadHelper.ParseIntSave(input, "Course count")];
        }
    }
}
