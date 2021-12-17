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
        public static int SolvePart1(string input)
        {
            var (template, insertions) = ParseInput(input);

            for (int step = 0; step < 10; step++)
            {
                string newTemplate = template[0].ToString();

                for (int i = 0; i < template.Length - 1; i++)
                {
                    string key = $"{template[i]}{template[i + 1]}";
                    if (insertions.ContainsKey(key))
                    {
                        newTemplate += insertions[key] + template[i + 1];
                    }
                }

                template = newTemplate;
            }

            var occurrences = new Dictionary<char, int>();
            for (int i = 0; i < template.Length; i++)
            {
                if (!occurrences.TryAdd(template[i], 1))
                {
                    occurrences[template[i]]++;
                }
            }

            int min = int.MaxValue;
            int max = 0;
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
