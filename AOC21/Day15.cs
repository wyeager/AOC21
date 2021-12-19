using DotNetty.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC21
{
    public class Day15
    {
        public static int SolvePart1(string input)
        {
            return Solve(input, false);
        }

        public static int SolvePart2(string input)
        {
            return Solve(input, true);
        }

        public static int Solve(string input, bool part2)
        {
            int[][] grid = ParseInput(input);

            if (part2)
            {
                grid = MakeGridLarger(grid);
            }

            var risks = new Dictionary<(int, int), int>();
            var visited = new HashSet<(int, int)>();
            var priorityQueue = new PriorityQueue<Cave>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    risks.Add((i, j), int.MaxValue);
                }
            }

            risks[(0, 0)] = 0;
            priorityQueue.Enqueue(new Cave { Row = 0, Col = 0, Risk = 0 });

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    // pick min distance vertex to be processed next
                    var cave = priorityQueue.Dequeue();
                    var (row, col) = (cave.Row, cave.Col);

                    visited.Add((row, col));

                    var adjacentVertices = new List<(int, int)> {
                        (row + 1, col),
                        (row - 1, col),
                        (row, col + 1),
                        (row, col - 1)
                    };

                    foreach (var (r, c) in adjacentVertices)
                    {
                        // don't go out of bounds
                        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length)
                        {
                            continue;
                        }

                        if (!visited.Contains((r, c)) &&
                            risks[(row, col)] + grid[r][c] < risks[(r, c)])
                        {
                            risks[(r, c)] = risks[(row, col)] + grid[r][c];
                            priorityQueue.Enqueue(new Cave
                            {
                                Row = r,
                                Col = c,
                                Risk = risks[(row, col)] + grid[r][c]
                            });
                        }
                    }
                }
            }

            return risks[(grid.Length - 1, grid[0].Length - 1)];
        }

        private static int[][] MakeGridLarger(int[][] grid)
        {
            var newGrid = new int[grid.Length * 5][];

            for (int i = 0; i < grid.Length * 5; i++)
            {
                newGrid[i] = new int[grid[0].Length * 5];
            }

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        int newValue;
                        if ((grid[i][j] + k) > 9)
                        {
                            newValue = ((grid[i][j] + k) % 10) + 1;
                        }
                        else
                        {
                            newValue = grid[i][j] + k;
                        }

                        int newRowCoordinate = i + k * grid.Length;
                        newGrid[newRowCoordinate][j] = newValue;
                    }
                }
            }

            for (int i = 0; i < newGrid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        int newValue;
                        if ((newGrid[i][j] + k) > 9)
                        {
                            newValue = ((newGrid[i][j] + k) % 10) + 1;
                        } else
                        {
                            newValue = newGrid[i][j] + k;
                        }

                        int newColCoordinate = j + k * grid.Length;
                        newGrid[i][newColCoordinate] = newValue;
                    }
                }
            }

            return newGrid;
        }

        private static int[][] ParseInput(string input) =>
            input
                .Split("\r\n")
                .Select(s => s
                    .ToCharArray()
                    .Select(c => int.Parse(c.ToString()))
                    .ToArray())
                .ToArray();

        class Cave : IComparable
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public int Risk { get; set; }

            public int CompareTo(object obj)
            {
                Cave c = (Cave)obj;
                return Risk - c.Risk;
            }
        }
    }
}
