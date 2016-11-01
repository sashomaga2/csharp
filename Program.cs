using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                throw new InvalidEnumArgumentException("Input data is invalid!");
            }
            
            var data = ParseInput(input);
            var arr = InitMultyArray(data[0]);
            IncrementLastNestedArrayAtIndex(arr, data[1]);
            PrintArray(arr);
        }

        private static void IncrementLastNestedArrayAtIndex(long[][] arr, int index)
        {
            var lastArrIndex = arr[arr.Length - 1].Length;
            if (index > lastArrIndex || lastArrIndex < 0)
            {
                throw new ArgumentException("Second input is not valid!");
                
            }

            arr[arr.Length - 1][index]++;
        }

        public static int[] ParseInput(string input)
        {
            return input.Split(' ').Select(e =>
            {
                int el;
                int.TryParse(e, out el);
                return el;
            }).ToArray();
        }

        public static long[][] InitMultyArray(int size)
        {
            var arr = new long[size][];
            for (var i = 0; i < size; i++)
            {
                arr[i] = new long[size];
                for (var j = 0; j < size; j++)
                {
                    arr[i][j] = j + 1 + i * size;
                }
               
            }
            return arr;
        }

        public static void PrintArray(long[][] arr)
        {
            for (var x = 0; x < arr.Length; x++)
            {
                for (var y = 0; y < arr[0].Length; y++)
                {
                    Console.Write($"{arr[x][y]}" + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
