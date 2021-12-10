using System.Collections.Generic;
using System.Linq;

namespace AOC21
{
    public class Day9
    {
        bool[,] visited;
        int rowLength;
        int colLength;
        int[][] grid;

        public int SolvePart1(string input)
        {
            grid = ParseGrid(input);

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

        public int SolvePart2(string input)
        {
            grid = ParseGrid(input);
            rowLength = grid.Length;
            colLength = grid[0].Length;
            visited = new bool[rowLength, colLength];

            var basinSizes = new List<int>();

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    int size = DFSUtil(i, j);
                    if (size > 0)
                    {
                        basinSizes.Add(size);
                    }
                }
            }

            int result = basinSizes
                .OrderByDescending(s => s)
                .Take(3)
                .Aggregate((acc, curr) => acc * curr);

            return result;
        }

        private static int[][] ParseGrid(string input) =>
            input
                .Split("\r\n")
                .Select(a => a
                    .Select(b => int.Parse(b.ToString()))
                    .ToArray())
                .ToArray();

        private int DFSUtil(int row, int col)
        {
            if (grid[row][col] == 9 || visited[row, col])
            {
                return 0;
            }

            // Mark the current node as visited
            visited[row, col] = true;

            // Recur for all the vertices
            // adjacent to this vertex
            var vList = new List<(int, int)> {
                (row + 1, col),
                (row - 1, col),
                (row, col + 1),
                (row, col - 1)
            };

            // count self
            int size = 1;
            foreach (var (r, c) in vList)
            {
                if (r < 0 || r >= rowLength || c < 0 || c >= colLength)
                {
                    continue;
                }

                if (!visited[r, c])
                {
                    // count all vertices this cell can reach (that haven't been visited or are 9)
                    size += DFSUtil(r, c);
                }
            }

            return size;
        }
    }
}
