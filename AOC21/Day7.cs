using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21
{
    public class Day7
    {
        public static int SolvePart1(string input)
        {
            return Solve(input, (i) => i);
        }

        public static int SolvePart2(string input)
        {
            return Solve(input, (i) => i * (i + 1) / 2);
        }

        public static int Solve(string input, Func<int, int> fuelCalc)
        {
            List<int> positions = input
                .Split(",")
                .Select(s => int.Parse(s))
                .ToList();

            int minFuel = int.MaxValue;

            for (int i = 0; i <= positions.Max(); i++)
            {
                int totalFuel = 0;
                for (int j = 0; j < positions.Count; j++)
                {
                    totalFuel += fuelCalc(Math.Abs(positions[j] - i));
                }

                if (totalFuel < minFuel)
                {
                    minFuel = totalFuel;
                }
            }

            return minFuel;
        }
    }
}
