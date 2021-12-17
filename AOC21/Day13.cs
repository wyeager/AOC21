using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AOC21
{
    public class Day13
    {
        public static int SolvePart1(string input)
        {
            var (part1, _) = Solve(input, true);
            return part1;
        }

        public static string SolvePart2(string input)
        {
            var (_, part2) = Solve(input, false);
            return part2;
        }

        public static (int, string) Solve(string input, bool part1)
        {
            var (grid, instructions) = ParseInput(input);

            int rowLength = grid.GetLength(0);
            int colLength = grid.GetLength(1);
            foreach (var (dimension, num) in instructions)
            {
                if (dimension == 'x')
                {
                    for (int row = 0; row < rowLength; row++)
                    {
                        for (int col = num + 1; col < colLength; col++)
                        {
                            int mirrorCol = num - (col - num);
                            if (grid[row, col] && mirrorCol >= 0)
                            {
                                grid[row, mirrorCol] = true;
                            }
                        }
                    }

                    colLength = num;
                }
                else
                {
                    for (int row = num + 1; row < grid.GetLength(0); row++)
                    {
                        for (int col = 0; col < grid.GetLength(1); col++)
                        {
                            int mirrorRow = num - (row - num);
                            if (grid[row, col] && mirrorRow >= 0)
                            {
                                grid[mirrorRow, col] = true;
                            }
                        }
                    }

                    rowLength = num;
                }

                // if part1 quit loop after one iteration
                if (part1) break;
            }

            int part1Result = 0;
            string part2Result = "";
            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    if (grid[row, col])
                    {
                        part1Result++;
                        if (!part1) part2Result += "#";
                    } else
                    {
                        if (!part1) part2Result += ".";
                    }
                }
                if (!part1) part2Result += "\r\n";
            }

            return (part1Result, part2Result);
        }

        private static (bool[,], List<(char, int)>) ParseInput(string input)
        {
            var lines = input.Split("\r\n");
            var points = new List<(int, int)>();
            var instructions = new List<(char, int)>();

            int maxRow = 0;
            int maxCol = 0;
            var regex = new Regex(@"fold along (x|y)=(\d+)", RegexOptions.Compiled);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var match = regex.Match(line);

                if (match.Success)
                {
                    char dimension = char.Parse(match.Groups[1].Value);
                    int num = int.Parse(match.Groups[2].Value);

                    instructions.Add((dimension, num));
                } else
                {
                    int col = int.Parse(line.Split(",")[0]);
                    int row = int.Parse(line.Split(",")[1]);

                    maxRow = Math.Max(maxRow, row);
                    maxCol = Math.Max(maxCol, col);

                    points.Add((row, col));
                }
            }

            var grid = new bool[maxRow + 1, maxCol + 1];

            foreach (var (row, col) in points)
            {
                grid[row, col] = true;
            }

            return (grid, instructions);
        }
    }
}
