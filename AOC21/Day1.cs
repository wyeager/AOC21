using System.Collections.Generic;
using System.Linq;

namespace AOC21
{
    public class Day1
    {
        public static int SolvePart1(string input)
        {
            List<int> depths = ParseInput(input);

            int increases = 0;
            for (int i = 1; i < depths.Count; i++)
            {
                if (depths[i] > depths[i - 1])
                {
                    increases++;
                }
            }

            return increases;
        }

        public static int SolvePart2(string input)
        {
            List<int> depths = ParseInput(input);

            int increases = 0;
            int previous = depths[0] + depths[1] + depths[2];
            for (int i = 3; i < depths.Count; i++)
            {
                int current = depths[i] + depths[i - 1] + depths[i - 2];

                if (current > previous)
                {
                    increases++;
                }

                previous = current;
            }

            return increases;
        }

        private static List<int> ParseInput(string input) =>
            input
                .Split("\r\n")
                .Select(s => int.Parse(s))
                .ToList();
    }
}
