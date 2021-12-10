using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21
{
    public class Day10
    {
        public static int SolvePart1(string input)
        {
            List<string> lines = input
                .Split("\r\n")
                .ToList();

            var parens = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' },
                { '<', '>' },
            };

            var points = new Dictionary<char, int>
            {
                { ')', 3 },
                { ']', 57 },
                { '}', 1197 },
                { '>', 25137 },
            };

            int result = 0;
            foreach (string line in lines)
            {
                var openers = new Stack<char>();

                foreach (char c in line)
                {
                    if (parens.ContainsKey(c))
                    {
                        openers.Push(c);
                    }
                    else
                    {
                        char lastOpener = openers.Pop();

                        if (parens[lastOpener] != c)
                        {
                            result += points[c];
                            break;
                        }
                    }
                }
            }

            return result;
        }

        public static long SolvePart2(string input)
        {
            List<string> lines = input
                .Split("\r\n")
                .ToList();

            var parens = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' },
                { '<', '>' },
            };

            var points = new Dictionary<char, int>
            {
                { ')', 1 },
                { ']', 2 },
                { '}', 3 },
                { '>', 4 },
            };

            var scores = new List<long>();
            foreach (string line in lines)
            {
                var openers = new Stack<char>();
                bool corrupted = false;

                foreach (char c in line)
                {
                    if (parens.ContainsKey(c))
                    {
                        openers.Push(c);
                    }
                    else
                    {
                        char lastOpener = openers.Pop();

                        if (parens[lastOpener] != c)
                        {
                            corrupted = true;
                            break;
                        }
                    }
                }

                // skip corrupted lines
                if (!corrupted)
                {
                    long score = 0;
                    foreach (char c in openers)
                    {
                        score = (score * 5) + points[parens[c]];
                    }

                    scores.Add(score);
                }
            }

            scores.Sort();
            return scores[scores.Count / 2];
        }
    }
}
