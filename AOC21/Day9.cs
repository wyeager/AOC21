using System.Linq;

namespace AOC21
{
    public class Day9
    {
        public static int SolvePart1(string input)
        {
            int[][] grid = input
                .Split("\r\n")
                .Select(a => a
                    .Select(b => int.Parse(b.ToString()))
                    .ToArray())
                .ToArray();

            int result = 0;

            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[0].Length; col++)
                {
                    int point = grid[row][col];

                    if (row != 0)
                    {
                        int up = grid[row - 1][col];
                        if (point >= up) continue;
                    }

                    if (row != grid.Length - 1)
                    {
                        int down = grid[row + 1][col];
                        if (point >= down) continue;
                    }

                    if (col != 0)
                    {
                        int left = grid[row][col - 1];
                        if (point >= left) continue;
                    }

                    if (col != grid[0].Length - 1)
                    {
                        int right = grid[row][col + 1];
                        if (point >= right) continue;
                    }

                    result += point + 1;
                }
            }

            return result;
        }

        public static int SolvePart2(string input)
        {
            return 0;
        }
    }
}
