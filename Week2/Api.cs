using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondWeek.Interfaces;

namespace SecondWeek
{
    public enum SortType { Selection, Buble }

    public class Api
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        public Api(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public void Start<T>() where T : struct, IComparable<T>
        {
            var arr = EnterArray<T>();
            var sortType = ChooseSortType();
            var sorter = new SorterFactory().Create<T>(sortType, arr);
            // Compare works
            arr[0].CompareTo(arr[1]);
            PrintArray(sorter.Sort());
        }

        private SortType ChooseSortType()
        {
            _writer.WriteLine("Enter sort type: 1 - for buble 2 - selection");
            var sortType = _reader.ReadLine();
            SortType type;
            switch (sortType)
            {
                case "1":
                    type = SortType.Buble;
                    break;
                case "2":
                    type = SortType.Selection;
                    break;
                default:
                    throw new ArgumentException("Not valid sort type!");
            }

            return type;
        }

        private void PrintArray<T>(T[] sorted)
        {
            _writer.WriteLine(string.Join(",", sorted));
        }

        private T[] EnterArray<T>()
        {
            _writer.WriteLine("Enter array separated by commas:");
            var input = ReadHelper.GetInputRow(_reader);
            return input
                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(e => (T)Convert.ChangeType(e, typeof(T)))
                .ToArray();
        }
    }
}
