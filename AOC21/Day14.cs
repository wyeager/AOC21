using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC21
{
    public class Day14
    {
        public static long SolvePart1(string input)
        {
            return Solve(input, 10);
        }

        public static long SolvePart2(string input)
        {
            return Solve(input, 40);
        }

        private static long Solve(string input, int steps)
        {
            var (template, insertions) = ParseInput(input);

            var pairOccurrences = new Dictionary<string, long>();
            var occurrences = new Dictionary<string, long>();

            // initialize occurrences dictionary
            for (int i = 0; i < template.Length; i++)
            {
                string s = template[i].ToString();
                if (!occurrences.TryAdd(s, 1))
                {
                    occurrences[s]++;
                }
            }

            // initialize pair occurrences dictionary
            for (int i = 0; i < template.Length - 1; i++)
            {
                string curr = template[i].ToString();
                string next = template[i + 1].ToString();
                string key = curr + next;

                if (!pairOccurrences.TryAdd(key, 1))
                {
                    pairOccurrences[key]++;
                }
            }

            for (int step = 0; step < steps; step++)
            {
                var newPairOccurences = new Dictionary<string, long>(pairOccurrences);

                foreach (var (pair, num) in pairOccurrences)
                {
                    if (insertions.ContainsKey(pair) && pairOccurrences[pair] > 0)
                    {
                        string newPair1 = $"{pair[0]}{insertions[pair]}";
                        string newPair2 = $"{insertions[pair]}{pair[1]}";

                        // the existing pairs get broken up by the insertions :^(
                        newPairOccurences[pair] -= num;

                        // but <num> new pairs get created
                        if (!newPairOccurences.TryAdd(newPair1, num))
                        {
                            newPairOccurences[newPair1] += num;
                        }

                        if (!newPairOccurences.TryAdd(newPair2, num))
                        {
                            newPairOccurences[newPair2] += num;
                        }

                        // increment the occurrences of the newly inserted characters
                        if (!occurrences.TryAdd(insertions[pair], num))
                        {
                            occurrences[insertions[pair]] += num;
                        }
                    }
                }

                pairOccurrences = newPairOccurences;
            }

            long min = long.MaxValue;
            long max = 0;
            foreach (var (_, num) in occurrences)
            {
                min = Math.Min(num, min);
                max = Math.Max(num, max);
            }

            return max - min;
        }

        private static (string, Dictionary<string, string>) ParseInput(string input)
        {
            var lines = input.Split("\r\n");

            string template = lines[0];

            var insertions = new Dictionary<string, string>();
            var regex = new Regex(@"(\w\w) -> (\w)", RegexOptions.Compiled);

            for (int i = 2; i < lines.Length; i++)
            {
                var match = regex.Match(lines[i]);

                string key = match.Groups[1].Value;
                string value = match.Groups[2].Value;

                insertions.Add(key, value);
            }

            return (template, insertions);
        }
    }
}
