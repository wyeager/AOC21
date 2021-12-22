using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC21
{
    public class Day18
    {
        public static long SolvePart1(string input) =>
            ParseInput(input)
                .Aggregate((acc, curr) => Reduce(new Pair(acc, curr)))
                .Magnitude();

        public static long SolvePart2(string input)
        {
            List<IPair> pairs = ParseInput(input);

            long max = 0;
            for (int i = 0; i < pairs.Count; i++)
            {
                for (int j = i + 1; j < pairs.Count; j++)
                {
                    long magnitude1 = Reduce(new Pair(pairs[i].Copy(), pairs[j].Copy())).Magnitude();
                    long magnitude2 = Reduce(new Pair(pairs[j].Copy(), pairs[i].Copy())).Magnitude();

                    max = Math.Max(max, magnitude1);
                    max = Math.Max(max, magnitude2);
                }
            }

            return max;
        }

        private static List<IPair> ParseInput(string input) =>
            input
                .Split("\r\n")
                .Select(line => ParsePair(line).Item1)
                .ToList();

        private static IPair Reduce(IPair pair)
        {
            bool explode = true;
            bool split = true;

            while (explode || split)
            {
                (explode, _, _) = pair.Explode(1);
                if (explode) continue;
                (split, _) = pair.Split();
            }

            return pair;
        }

        private static (IPair, string) ParsePair(string line)
        {
            if (int.TryParse(line[0].ToString(), out int number))
            {
                // consume number
                return (new RegularNumber(number), line[1..]);
            }

            var pair = new Pair();

            // consume [
            (pair.Left, line) = ParsePair(line[1..]);
            // consume ,
            (pair.Right, line) = ParsePair(line[1..]);

            // consume ]
            return (pair, line[1..]);
        }

        private interface IPair
        {
            public IPair Copy();
            public long Magnitude();
            public (bool, int, int) Explode(int height);
            public (bool, int) Split();
            public void AddRegularNumber(int number, bool left);
        }

        private class RegularNumber : IPair
        {
            public int Val { get; set; }

            public RegularNumber(int val)
            {
                Val = val;
            }

            public IPair Copy()
            {
                return new RegularNumber(Val);
            }

            public long Magnitude()
            {
                return Val;
            }

            public (bool, int, int) Explode(int height)
            {
                return (false, -1, -1);
            }

            public void AddRegularNumber(int number, bool left)
            {
                Val += number;
            }

            public (bool, int) Split()
            {
                return Val > 9 ? (true, Val) : (false, -1);
            }
        }

        private class Pair : IPair
        {
            public IPair Left { get; set; }
            public IPair Right { get; set; }

            public Pair() { }

            public Pair(IPair left, IPair right)
            {
                Left = left;
                Right = right;
            }

            public IPair Copy()
            {
                return new Pair(Left.Copy(), Right.Copy());
            }

            public long Magnitude()
            {
                return 3 * Left.Magnitude() + 2 * Right.Magnitude();
            }

            public (bool, int, int) Explode(int height)
            {
                if (height == 5)
                {
                    return (true, ((RegularNumber)Left).Val, ((RegularNumber)Right).Val);
                }

                bool exploded;
                int leftVal;
                int rightVal;

                (exploded, leftVal, rightVal) = Left.Explode(height + 1);

                if (exploded && leftVal >= 0 && rightVal >= 0)
                {
                    Left = new RegularNumber(0);
                }

                if (exploded && rightVal >= 0)
                {
                    Right.AddRegularNumber(rightVal, true);
                }

                if (exploded)
                {
                    return (true, leftVal, -1);
                }

                (exploded, leftVal, rightVal) = Right.Explode(height + 1);

                if (exploded && leftVal >= 0 && rightVal >= 0)
                {
                    Right = new RegularNumber(0);
                }

                if (exploded && leftVal >= 0)
                {
                    Left.AddRegularNumber(leftVal, false);
                }

                if (exploded)
                {
                    return (true, -1, rightVal);
                }

                return (false, -1, -1);
            }

            public (bool, int) Split()
            {
                bool split;
                int val;

                (split, val) = Left.Split();

                if (split)
                {
                    if (val < 0)
                    {
                        return (true, -1);
                    } else
                    {
                        var leftVal = new RegularNumber(val / 2);
                        var rightVal = new RegularNumber(val % 2 == 0 ? val / 2 : val / 2 + 1);
                        Left = new Pair(leftVal, rightVal);
                        return (true, -1);
                    }
                }

                (split, val) = Right.Split();

                if (split)
                {
                    if (val < 0)
                    {
                        return (true, -1);
                    }
                    else
                    {
                        var leftVal = new RegularNumber(val / 2);
                        var rightVal = new RegularNumber(val % 2 == 0 ? val / 2 : val / 2 + 1);
                        Right = new Pair(leftVal, rightVal);
                        return (true, -1);
                    }
                }

                return (false, -1);
            }

            public void AddRegularNumber(int number, bool left)
            {
                if (left)
                {
                    Left.AddRegularNumber(number, left);
                } else
                {
                    Right.AddRegularNumber(number, left);
                }
            }
        }
    }
}
