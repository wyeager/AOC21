using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21
{
    public class Day8
    {
        public static int SolvePart1(string input)
        {
            var digits = input
                .Split("\r\n")
                .Select(s => s
                    .Split("|")[1]
                    .Trim()
                    .Split(" ")
                    .ToList())
                .ToList();

            int result = 0;

            foreach (var line in digits)
            {
                foreach (var digit in line)
                {
                    if (digit.Length == 2 ||
                        digit.Length == 3 ||
                        digit.Length == 4 ||
                        digit.Length == 7)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        public static int SolvePart2(string input)
        {
            var entries = input
                .Split("\r\n")
                .Select(s =>
                    // signalPatterns
                    (s
                        .Split("|")[0]
                        .Trim()
                        .Split(" ")
                        .Select(c => new HashSet<char>(c))
                        ,
                    // outputValues
                    s
                        .Split("|")[1]
                        .Trim()
                        .Split(" ")
                        .Select(c => new HashSet<char>(c))))
                .ToList();

            int result = 0;
            for (int i = 0; i < entries.Count; i++)
            {
                var (signalPatterns, outputValues) = entries[i];

                var zero = new HashSet<char>();
                var one = signalPatterns.Where(s => s.Count == 2).First();
                var two = new HashSet<char>();
                var three = new HashSet<char>();
                var four = signalPatterns.Where(s => s.Count == 4).First();
                var five = new HashSet<char>();
                var six = new HashSet<char>();
                var seven = signalPatterns.Where(s => s.Count == 3).First();
                var eight = signalPatterns.Where(s => s.Count == 7).First();
                var nine = new HashSet<char>();

                var length5s = signalPatterns.Where(s => s.Count == 5);
                var length6s = signalPatterns.Where(s => s.Count == 6);

                foreach (var length5 in length5s)
                {
                    if (length5.Except(four).Count() == 3)
                    {
                        two = length5;
                    }
                    else if (length5.Except(one).Count() == 3)
                    {
                        three = length5;
                    }
                    else
                    {
                        five = length5;
                    }
                }

                foreach (var length6 in length6s)
                {
                    if (length6.Except(four).Count() == 2)
                    {
                        nine = length6;
                    }
                    else if (length6.Except(one).Count() == 5)
                    {
                        six = length6;
                    } else
                    {
                        zero = length6;
                    }
                }

                var decoder = new Dictionary<HashSet<char>, int>(HashSet<char>.CreateSetComparer())
                {
                    { zero, 0 },
                    { one, 1 },
                    { two, 2 },
                    { three, 3 },
                    { four, 4 },
                    { five, 5 },
                    { six, 6 },
                    { seven, 7 },
                    { eight, 8 },
                    { nine, 9 },
                };

                int multiplier = 1000;
                int num = 0;

                foreach (var val in outputValues)
                {
                    num += decoder[val] * multiplier;
                    multiplier /= 10;
                }

                result += num;
            }

            return result;
        }
    }
}
