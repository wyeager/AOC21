using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21
{
    public class Day11
    {
        Octopus[][] octopi;

        public int SolvePart1(string input)
        {
            octopi = ParseGrid(input);

            int totalFlashes = 0;
            for (int i = 1; i <= 100; i++)
            {
                totalFlashes += Step();
            }

            return totalFlashes;
        }

        public int SolvePart2(string input)
        {
            octopi = ParseGrid(input);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            int step = 1;
            while (stopwatch.Elapsed.TotalSeconds < 20)
            {
                int flashes = Step();
                if (flashes == 100)
                {
                    return step;
                }

                step++;
            }

            throw new Exception("No simultaneous flashes found in 20 seconds");
        }

        private int Step()
        {
            // STEP 1: increase all energy levels by 1
            for (int row = 0; row < octopi.Length; row++)
            {
                for (int col = 0; col < octopi[0].Length; col++)
                {
                    octopi[row][col].Energy++;
                }
            }

            // STEP 2: all greater than 9s flash
            for (int row = 0; row < octopi.Length; row++)
            {
                for (int col = 0; col < octopi[0].Length; col++)
                {
                    Octopus octopus = octopi[row][col];
                    if (octopus.Energy > 9)
                    {
                        octopus.Flash();
                    }
                }
            }

            // STEP 3: reset and count flashes
            int flashes = 0;
            for (int row = 0; row < octopi.Length; row++)
            {
                for (int col = 0; col < octopi[0].Length; col++)
                {
                    flashes += octopi[row][col].Reset();
                }
            }

            return flashes;
        }

        private Octopus[][] ParseGrid(string input) =>
            input
                .Split("\r\n")
                .Select((a, row) => a
                    .Select((b, col) => new Octopus {
                        Solution = this,
                        Row = row,
                        Col = col,
                        Energy = int.Parse(b.ToString()),
                        Flashed = false
                    })
                    .ToArray())
                .ToArray();

        private class Octopus
        {
            // reference to parent class for accessing octopi 2D array
            public Day11 Solution { get; set; }
            public int Row { get; set; }
            public int Col { get; set; }
            public int Energy { get; set; }
            public bool Flashed { get; set; }

            public void Flash()
            {
                if (Flashed) return;
                Flashed = true;

                // get surrounding octopi
                var surrounding = new List<(int, int)> {
                    (Row + 1, Col), // down
                    (Row - 1, Col), // up
                    (Row, Col + 1), // right
                    (Row, Col - 1), // left

                    // diagonals
                    (Row - 1, Col - 1), // top left
                    (Row + 1, Col - 1), // bottom left
                    (Row - 1, Col + 1), // top right
                    (Row + 1, Col + 1), // bottom right
                };

                // increase surrounding octopi energy levels and potentially cause them to flash
                foreach (var (row, col) in surrounding)
                {
                    // make sure not to try to access an octopus in a position outside of the grid
                    if (row < 0 || row >= Solution.octopi.Length || 
                        col < 0 || col >= Solution.octopi[0].Length)
                    {
                        continue;
                    }

                    Solution.octopi[row][col].ReceiveFlash();
                }
            }

            public void ReceiveFlash()
            {
                if (Flashed) return;

                Energy++;

                if (Energy > 9)
                {
                    Flash();
                }
            }

            public int Reset()
            {
                if (Flashed)
                {
                    Flashed = false;
                    Energy = 0;

                    return 1;
                }

                return 0;
            }
        }
    }
}
