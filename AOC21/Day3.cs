using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            List<string> report2 = input
                .Split("\r\n")
                .ToList();

            var zeroesPerCol = new int[report[0].Length];

            int numCols = report[0].Length;

            for (int i = 0; i < numCols; i++)
            {
                if (report.Count == 1) break;

                int zeroes = 0;

                for (int j = 0; j < report.Count; j++)
                {
                    if (report[j][i] == '0')
                    {
                        zeroes++;
                    }
                }

                char bit = zeroes <= report.Count / 2 ? '1' : '0';

                report = report.Where(n => n[i] == bit).ToList();
            }

            for (int i = 0; i < numCols; i++)
            {
                if (report2.Count == 1) break;

                int zeroes = 0;

                for (int j = 0; j < report2.Count; j++)
                {
                    if (report2[j][i] == '0')
                    {
                        zeroes++;
                    }
                }

                char bit = zeroes > report2.Count / 2 ? '1' : '0';

                report2 = report2.Where(n => n[i] == bit).ToList();
            }

            int oxygen = Convert.ToInt32(report[0], 2);
            int co2 = Convert.ToInt32(report2[0], 2);

            return oxygen * co2;
        }
    }
}
