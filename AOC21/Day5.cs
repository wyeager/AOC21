using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC21
{
    public class Day5
    {
        private static readonly Regex regex = new Regex(@"(\d+),(\d+) -> (\d+),(\d+)", RegexOptions.Compiled);

        public static int SolvePart1(string input)
        {
            return Solve(input, false);
        }

        public static int SolvePart2(string input)
        {
            return Solve(input, true);
        }

        public static int Solve(string input, bool includeDiagonals)
        {
            var lines = ParseInput(input, includeDiagonals);

            int maxX = lines.Aggregate(0, (acc, curr) => Math.Max(Math.Max(curr.Start.X, curr.End.X), acc));
            int maxY = lines.Aggregate(0, (acc, curr) => Math.Max(Math.Max(curr.Start.Y, curr.End.Y), acc));

            var grid = new int[maxX + 1, maxY + 1];

            foreach (var line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    int x = line.Start.X;
                    int y = line.Start.Y;

                    if (line.Start.X < line.End.X)
                    {
                        x = line.Start.X + i;
                    }
                    else if (line.Start.X > line.End.X)
                    {
                        x = line.Start.X - i;
                    }

                    if (line.Start.Y < line.End.Y)
                    {
                        y = line.Start.Y + i;
                    }
                    else if (line.Start.Y > line.End.Y)
                    {
                        y = line.Start.Y - i;
                    }

                    grid[x, y]++;
                }
            }

            int result = 0;

            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    if (grid[x, y] > 1)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        private static List<Line> ParseInput(string input, bool includeDiagonals) =>
            input
                .Split("\r\n")
                .Select(s =>
                {
                    var match = regex.Match(s);

                    int startX = int.Parse(match.Groups[1].Value);
                    int startY = int.Parse(match.Groups[2].Value);
                    int endX = int.Parse(match.Groups[3].Value);
                    int endY = int.Parse(match.Groups[4].Value);

                    var start = new Point(startX, startY);
                    var end = new Point(endX, endY);

                    return new Line(start, end);
                })
                .Where(line => includeDiagonals || (!includeDiagonals && !line.IsDiagonal()))
                .ToList();
            
        

        private class Line
        {
            public Point Start { get; set; }
            public Point End { get; set; }
            public int Length { get; set; }

            public Line(Point start, Point end)
            {
                Start = start;
                End = end;

                if (Start.X == End.X)
                {
                    Length = Math.Abs(End.Y - Start.Y) + 1;
                }
                else
                {
                    Length = Math.Abs(End.X - Start.X) + 1;
                }
            }

            public bool IsDiagonal()
            {
                return Start.X != End.X && Start.Y != End.Y;
            }
        }

        private class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
