using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AOC21
{
    public class Day17
    {
        public static long SolvePart1(string input)
        {
            var (maxY, _) = Solve(input);
            return maxY;
        }

        public static long SolvePart2(string input)
        {
            var (_, initialVelocitiesCount) = Solve(input);
            return initialVelocitiesCount;
        }


        public static (long, long) Solve(string input)
        {
            var targetArea = ParseInput(input);

            int overallMaxY = 0;
            var initialVelocities = new HashSet<(int, int)>();

            // I'm just choosing -150 and 1000 heuristically based on the puzzle input
            for (int xVelocity = 0; xVelocity < 1000; xVelocity++)
            {
                for (int yVelocity = -150; yVelocity < 1000; yVelocity++)
                {
                    var (hit, localMaxY) = ReachesTargetArea(targetArea, xVelocity, yVelocity);

                    if (hit)
                    {
                        initialVelocities.Add((xVelocity, yVelocity));
                        overallMaxY = Math.Max(localMaxY, overallMaxY);
                    }
                }
            }

            return (overallMaxY, initialVelocities.Count);
        }

        private static (bool, int) ReachesTargetArea((int, int, int, int) targetArea, int xVelocity, int yVelocity)
        {
            var (xMin, xMax, yMin, yMax) = targetArea;

            int x = 0;
            int y = 0;
            int maxY = 0;

            while (x <= xMax && y >= yMin)
            {
                x += xVelocity;
                y += yVelocity;

                maxY = Math.Max(y, maxY);

                xVelocity--;
                // drag only brings the xVelocity to 0, it should never become negative
                if (xVelocity < 0) xVelocity = 0;
                yVelocity--;

                // to be considered a hit the probe coordinates must be inside the target area after a descrete step
                if (x >= xMin && x <= xMax && y >= yMin && y <= yMax)
                {
                    return (true, maxY);
                }
            }

            return (false, maxY);
        }

        private static (int, int, int, int) ParseInput(string input)
        {
            var regex = new Regex(@"target area: x=(-?\d+)..(-?\d+), y=(-?\d+)..(-?\d+)", RegexOptions.Compiled);
            var match = regex.Match(input);

            int xMin = int.Parse(match.Groups[1].Value);
            int xMax = int.Parse(match.Groups[2].Value);
            int yMin = int.Parse(match.Groups[3].Value);
            int yMax = int.Parse(match.Groups[4].Value);

            return (xMin, xMax, yMin, yMax);
        }
    }
}
