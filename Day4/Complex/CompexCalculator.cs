using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassesLesson.Complex
{
    public class CompexCalculator
    {
        private readonly IReader _reader;

        private readonly IWriter _writer;

        private readonly string _inputDelimiter = " ";

        private Command[] _commands;

        public CompexCalculator(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;

            InitCommands();
        }

        public void Start()
        {
            while (true)
            {
                _writer.WriteLine("Enter two complex numbers formated {real} {imaginary}:");
                var c1 = ReadComplexNumber();
                var c2 = ReadComplexNumber();
                _writer.WriteLine("Enter command:");
                var command = ReadCommand();

                if (command.Action == Action.Exit)
                {
                    break;
                }

                var result = ProcessCommand(c1, c2, command);

                _writer.WriteLine(result.ToString());
            }

        }

        #region Private Methods

        private void InitCommands()
        {
            _commands = new []
            {
                new Command("add", Action.Add),
                new Command("subtract", Action.Subtract),
                new Command("exit", Action.Exit)
            };
        }

        private Complex ProcessCommand(Complex c1, Complex c2, Command command)
        {
            return command.Action == Action.Add ? c1 + c2 : c1 - c2;
        }

        private Complex ReadComplexNumber()
        {
            var input = ReadHelper.GetInputRow(_reader);
            var parts = ReadHelper.SplitInput(input, 2, _inputDelimiter);
            return new Complex(ReadHelper.ParseIntSave(parts[0], "Complex number real part"),
                                ReadHelper.ParseIntSave(parts[1], "Complex number imaginary part"));
        }

        private Command ReadCommand()
        {
            var input = ReadHelper.GetInputRow(_reader);
            var command = _commands.FirstOrDefault(c => c.Name.Equals(input, StringComparison.CurrentCultureIgnoreCase));
            if (command == null)
            {
                throw new ArgumentException("Input must be valid command!");
            }

            return command;
        }

        #endregion

    }
}
