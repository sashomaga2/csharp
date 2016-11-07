using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondWeek.Interfaces;

namespace SecondWeek.Aritmetic
{
    public delegate int MyDel(int n1, int n2);

    public class Program
    {
        static void Main()
        {
            var consoleIO = new ConsoleIO();

            var parts = EnterNumbers(consoleIO, consoleIO);

            var operation = EnterOperation(consoleIO, consoleIO);

            var del = MapOperationToFunc(operation);

            //var calc = new Calculator();
            //MyDel handler = calc.Add;
            //handler += calc.Subtract;
            //handler += calc.Multiplay;

            consoleIO.WriteLine($"Result {del(parts[0], parts[1])}");
        }

        private static Func<int, int, int> MapOperationToFunc(OperationType operation)
        {
            Func<int, int, int> func = null;
            var calculator = new Calculator();

            switch (operation)
            {
                case OperationType.Add:
                    func = calculator.Add;
                break;
                case OperationType.Subtract:
                    func = calculator.Subtract;
                break;
                case OperationType.Multiplay:
                    func = calculator.Multiplay;
                break;
            }

            return func;
        }

        private static OperationType EnterOperation(IReader reader, IWriter writer)
        {
            writer.WriteLine("Enter operation: ");
            var input = ReadHelper.GetInputRow(reader);
            OperationType operation;
            switch (input)
            {
                case "+":
                   operation = OperationType.Add;
                break;
                case "-":
                   operation = OperationType.Subtract;
                break;
                case "*":
                   operation = OperationType.Multiplay;
                break;
                default:
                    throw new ArgumentException();

            }

            return operation;
        }

        static int[] EnterNumbers(IReader reader, IWriter writer)
        {
            writer.WriteLine("Enter 2 numbers: ");
            var input = ReadHelper.GetInputRow(reader);
            return ReadHelper.SplitInput(input, 2, " ").Select(e => ReadHelper.ParseIntSave(e, "Number")).ToArray();     
        } 

        
    }
}
