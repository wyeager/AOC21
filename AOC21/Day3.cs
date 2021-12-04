using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC21
{
    public class Day3
    {
        public static int SolvePart1(string input)
        {
            List<string> report = input
                .Split("\r\n")
                .ToList();

            var zeroesPerCol = new int[report[0].Length];

            for (int i = 0; i < report.Count; i++)
            {
                for (int j = 0; j < report[i].Length; j++)
                {
                    if (report[i][j] == '0')
                    {
                        zeroesPerCol[j]++;
                    }
                }
            }

            string gamma = "";
            string epsilon = "";

            foreach (var zeroes in zeroesPerCol)
            {
                gamma += zeroes > report.Count / 2 ? "0" : "1";
                epsilon += zeroes > report.Count / 2 ? "1" : "0";
            }

            int gammaDecimal = Convert.ToInt32(gamma, 2);
            int epsilonDecimal = Convert.ToInt32(epsilon, 2);

            return gammaDecimal * epsilonDecimal;
        }

        public static int SolvePart2(string input)
        {
            List<string> report = input
                .Split("\r\n")
                .ToList();

            int oxygen = GetRating(report, (zeroes, half) => zeroes <= half);
            int co2 = GetRating(report, (zeroes, half) => zeroes > half);

            return oxygen * co2;
        }

        private static int GetRating(List<string> report, Func<int, int, bool> comparison)
        {
            int numCols = report[0].Length;

            for (int i = 0; i < numCols; i++)
            {
                if (report.Count == 1) break;

                int zeroes = 0;

                for (int j = 0; j < report.Count; j++)
                {
                    // iterate through columns first by swapping j with i
                    if (report[j][i] == '0')
                    {
                        zeroes++;
                    }
                }

                int half = report.Count / 2;
                char bit = comparison(zeroes, half) ? '1' : '0';

                report = report.Where(n => n[i] == bit).ToList();
            }

            return Convert.ToInt32(report[0], 2);
        }
    }
}
