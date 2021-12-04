using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21
{
    public class Day4
    {
        public static int SolvePart1(string input)
        {
            var (order, boards, index) = ParseInput(input);

            int turns = 1;

            foreach (int num in order)
            {
                // a number is not guaranteed to be present in any boards, so use TryGetValue
                if (index.TryGetValue(num, out var numLocations))
                {
                    foreach (var (boardNum, row, col) in numLocations)
                    {
                        boards[boardNum][row][col].Marked = true;

                        // do not bother checking for winners until the 5th turn
                        if (turns >= 5 && BoardIsWinner(boards[boardNum]))
                        {
                            return num * SumUnmarked(boards[boardNum]);
                        }
                    }
                }

                turns++;
            }

            throw new Exception("No winner found");
        }

        public static int SolvePart2(string input)
        {
            var (order, boards, index) = ParseInput(input);

            int turns = 1;
            var winners = new HashSet<int>();

            foreach (int num in order)
            {
                // a number is not guaranteed to be present in any boards, so use TryGetValue
                if (index.TryGetValue(num, out var numLocations))
                {
                    foreach (var (boardNum, row, col) in numLocations)
                    {
                        boards[boardNum][row][col].Marked = true;

                        // do not bother checking for winners until the 5th turn
                        // also don't bother rechecking past winners
                        if (turns >= 5 && !winners.Contains(boardNum) && BoardIsWinner(boards[boardNum]))
                        {
                            if (winners.Count == boards.Count - 1)
                            {
                                return num * SumUnmarked(boards[boardNum]);
                            }

                            winners.Add(boardNum);
                        }
                    }
                }

                turns++;
            }

            throw new Exception("No winner found");
        }

        private static int SumUnmarked(Cell[][] board) =>
            board.Aggregate(0, (outerSum, row) => outerSum + row
                .Where(cell => !cell.Marked)
                .Aggregate(0, (innerSum, cell) => innerSum + cell.Num));

        private static bool BoardIsWinner(Cell[][] board)
        {
            // check rows
            foreach (var row in board)
            {
                if (row.All(cell => cell.Marked))
                {
                    return true;
                }
            }

            // check columns
            for (int i = 0; i < board[0].Length; i++)
            {
                bool allMarked = true;
                for (int j = 0; j < board.Length; j++)
                {
                    if (!board[j][i].Marked)
                    {
                        allMarked = false;
                    }
                }

                if (allMarked)
                {
                    return true;
                }
            }

            return false;
        }

        private static (List<int>, List<Cell[][]>, Dictionary<int, List<(int, int, int)>>) ParseInput(string input)
        {
            List<string> bingo = input
                .Split("\r\n")
                .ToList();

            List<int> order = bingo
                .First()
                .Split(",")
                .Select(s => int.Parse(s))
                .ToList();

            var boards = new List<Cell[][]>();

            var currentBoard = new Cell[5][];
            int currentBoardRowIdx = 0;

            var index = new Dictionary<int, List<(int, int, int)>>();

            for (int i = 2; i < bingo.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(bingo[i]))
                {
                    boards.Add(currentBoard);
                    currentBoard = new Cell[5][];
                    currentBoardRowIdx = 0;
                }
                else
                {
                    var row = bingo[i]
                        .Split(" ")
                        .Where(s => !string.IsNullOrWhiteSpace(s)) // work around for fixed width instead of single space delimited
                        .Select(s => new Cell { Num = int.Parse(s), Marked = false })
                        .ToArray();

                    // create index to easily look up location of numbers as they get called
                    // a number location is a tuple of board num, row num and col num
                    for (int j = 0; j < row.Length; j++)
                    {
                        int num = row[j].Num;
                        var numberLocation = (boards.Count, currentBoardRowIdx, j);

                        if (!index.TryAdd(num, new List<(int, int, int)> { numberLocation }))
                        {
                            index[num].Add(numberLocation);
                        }
                    }

                    currentBoard[currentBoardRowIdx] = row;
                    currentBoardRowIdx++;
                }
            }

            // add final board
            boards.Add(currentBoard);

            return (order, boards, index);
        }

        public class Cell
        {
            public int Num { get; set; }
            public bool Marked { get; set; }
        }
    }
}
