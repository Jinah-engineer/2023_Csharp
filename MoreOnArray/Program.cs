using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreOnArray
{
    class Program
    {
        private static bool CheckPassed(int score)
        {
            return score >= 60;
        }

        private static void Print(int value)
        {
            Console.Write($"{ value} ");
        }

        static void Main(string[] args)
        {
            int[] scores = new int[] { 80, 74, 81, 90, 34 };

            foreach (int score in scores)
            {
                Console.Write($"{score} ");
                Console.WriteLine();

                Array.Sort(scores);
                Array.ForEach<int>(scores, new Action<int>(Print));
                Console.WriteLine();

                Console.WriteLine($"Number of demensions : {scores.Rank}");

                Console.WriteLine($"Binary Search : 81 is at " + $"{Array.BinarySearch<int>(scores, 81)}");

                Console.WriteLine($"Linear Search : 90 is at " + $"{Array.IndexOf(scores, 90)}");

                /// TrueForAll 메소드는 배열과 함께 조건을 검사하는 메소드를 매개변수로 받습니다.
                Console.WriteLine($"Everyone passed ? : " + $"{Array.TrueForAll<int>(scores, CheckPassed)}");
            }
        }
    }
}
