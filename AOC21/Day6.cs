using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AOC21
{
    public class Day6
    {
        public static BigInteger SolvePart1(string input)
        {
            return Solve(input, 80);
        }

        public static BigInteger SolvePart2(string input)
        {
            return Solve(input, 256);
        }

        public static BigInteger Solve(string input, int days)
        {
            var fishes = input
                .Split(",")
                .Select(s => int.Parse(s))
                .GroupBy(s => s)
                .ToDictionary(
                    group => group.Key,
                    group => new BigInteger(group.Count()));

            for (int i = 0; i <= 8; i++)
            {
                // fill all fish days with 0 if they were not present in the puzzle input
                fishes.TryAdd(i, 0);
            }

            for (int day = 1; day <= days; day++)
            {
                var overwritten = fishes[8];
                for (int fishDay = 7; fishDay >= 0; fishDay--)
                {
                    var tempOverwritten = fishes[fishDay];
                    fishes[fishDay] = overwritten;
                    overwritten = tempOverwritten;

                    if (fishDay == 0)
                    {
                        fishes[8] = overwritten;
                        fishes[6] += overwritten;
                    }
                }
            }

            return fishes.Aggregate(new BigInteger(0), (acc, curr) => acc += curr.Value);
        }
    }
}
