using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC21
{
    public class Day21
    {
        public static long SolvePart1(string input)
        {
            var (player1Pos, player2Pos) = ParseInput(input);
            int player1Score = 0;
            int player2Score = 0;
            bool player1Turn = true;
            var die = new DeterministicDie();

            while (true)
            {
                var (roll1, roll2, roll3) = (die.Roll(), die.Roll(), die.Roll());

                if (player1Turn)
                {
                    player1Pos = AdvancePosition(roll1 + roll2 + roll3, player1Pos);
                    // add 1 to score since I'm 0 indexing the positions to make mod math a little easier
                    player1Score += player1Pos + 1;
                }
                else
                {
                    player2Pos = AdvancePosition(roll1 + roll2 + roll3, player2Pos);
                    player2Score += player2Pos + 1;
                }

                player1Turn = !player1Turn;

                if (player1Score >= 1000)
                {
                    return player2Score * die.TotalRolls;
                }

                if (player2Score >= 1000)
                {
                    return player1Score * die.TotalRolls;
                }
            }
        }

        public long SolvePart2(string input)
        {
            var (player1Pos, player2Pos) = ParseInput(input);
            Part2Helper(player1Pos, player2Pos, 0, 0, true, 1);
            long max = Math.Max(Player1Wins, Player2Wins);
            return max;
        }

        private long Player1Wins = 0;
        private long Player2Wins = 0;
        private readonly (int, int)[] DistinctRollSums = new (int, int)[] { (3, 1), (4, 3), (5, 6), (6, 7), (7, 6), (8, 3), (9, 1) };

        private void Part2Helper(int player1Pos, int player2Pos, int player1Score, int player2Score, bool player1Turn, long universes)
        {
            if (player1Score >= 21)
            {
                Player1Wins += universes;
                return;
            }

            if (player2Score >= 21)
            {
                Player2Wins += universes;
                return;
            }

            if (player1Turn)
            {
                foreach (var (roll, times) in DistinctRollSums)
                {
                    int newPos = AdvancePosition(roll, player1Pos);
                    int score = player1Score + newPos + 1;
                    Part2Helper(newPos, player2Pos, score, player2Score, !player1Turn, universes * times);
                }
            }
            else
            {
                foreach (var (roll, times) in DistinctRollSums)
                {
                    int newPos = AdvancePosition(roll, player2Pos);
                    int score = player2Score + newPos + 1;
                    Part2Helper(player1Pos, newPos, player1Score, score, !player1Turn, universes * times);
                }
            }
        }

        private static int AdvancePosition(int amount, int playerPosition)
        {
            return (playerPosition + amount) % 10;
        }

        private static (int, int) ParseInput(string input)
        {
            var regex = new Regex(@"Player \d starting position: (\d+)", RegexOptions.Compiled);

            var positions = input
                .Split("\r\n")
                .Select(s => int.Parse(regex.Match(s).Groups[1].Value))
                .ToList();

            return (positions[0] - 1, positions[1] - 1);
        }

        private class DeterministicDie
        {
            private int NextValue { get; set; } = 0;
            public int TotalRolls { get; private set; } = 0;

            public int Roll()
            {
                TotalRolls++;

                int temp = NextValue;

                NextValue = (NextValue + 1) % 100;

                return temp + 1;
            }
        }
    }
}
