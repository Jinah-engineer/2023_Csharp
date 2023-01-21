using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDelegate
{
    /// [1] 대리자
    delegate int Compare<T>(T a, T b);

    class Program
    {
        /// [2] Ascend Order Method
        static int AscendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b);
        }

        /// [3] Descend Order Method
        static int DescendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) * -1; // -1을 곱하면 자신보다 큰 경우 1 | 같으면 0 | 작은 경우 -1을 반환합니다. 
        }

        /// [4] Bubble Sort Method
        static void BubbleSort<T>(T[] DataSet, Compare<T> Comparer)
        {
            int i = 0;
            int j = 0;
            T temp;

            for (i = 0; i < DataSet.Length - 1; i++)
            {
                for (j = 0; j < DataSet.Length - (i + 1); j++)
                {
                    if (Comparer(DataSet[j], DataSet[j + 1]) > 0)
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int[] array = { 3, 7, 4, 2, 10 };

            Console.WriteLine("Sorting ascending...");

            BubbleSort<int>(array, new Compare<int>(AscendCompare));

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{ array[i]}");
            }

            string[] array2 = { "abc", "def", "ghi", "jkl", "mno" };

            Console.WriteLine("\nSorting Descending...");

            BubbleSort<string>(array2, new Compare<string>(DescendCompare));

            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write($"{array2[i]}");
            }

            Console.WriteLine();
        }
    }
}
