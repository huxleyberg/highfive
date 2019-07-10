using System;
using System.Collections.Generic;
using System.Linq;

namespace highfive
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jagged_arr = new int[][]
            {
                new int[] { 1, 91 },
                new int[] { 1, 92 },
                new int[] { 2, 93 },
                new int[] { 2, 97 },
                new int[] { 1, 60 },
                new int[] { 2, 77 },
                new int[] { 1, 65 },
                new int[] { 1,87 },
                new int[] { 1,100 },
                new int[] { 2,100 },
                new int[] { 2,76 }
            };




            int[][] result = HighFive(jagged_arr);
        }
        static int[][] HighFive(int[][] items)
        {
            IDictionary<int, List<int>> studentScores = new Dictionary<int, List<int>>();

            for (int x = 0; x < items.Length; x++)
            {
                int id = items[x][0];
                int score = items[x][1];

                if (studentScores.ContainsKey(id))
                {

                    List<int> scores = new List<int>();
                    studentScores.TryGetValue(id, out scores);
                    scores.Add(score);
                }
                else
                {
                    List<int> courseScore = new List<int>();
                    courseScore.Add(score);
                    studentScores.Add(id, courseScore);
                }
            }

            int[][] studentAvgScores = new int[studentScores.Keys.Count][];
            int position = 0;
            foreach (var item in studentScores)
            {
                int studentId = item.Key;
                List<int> scores = item.Value;

                int avg = AverageScore(scores);

                studentAvgScores[position] = new int[] { studentId, avg };
                position++;
            }


            return studentAvgScores;

        }
        static int AverageScore(List<int> scores)
        {
            scores.Sort();
            scores.Reverse();
            scores = scores.Take(5).ToList();
            int sum = scores.Sum();

            int result = sum / 5;

            return result;
        }
    }
}
