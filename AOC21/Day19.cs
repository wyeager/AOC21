using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC21
{
    public class Day19
    {
        public static long SolvePart1(string input)
        {
            List<Scanner> scanners = ParseInput(input);
            return 0;
        }

        private static List<Scanner> ParseInput(string input)
        {
            List<string> lines = input.Split("\r\n").ToList();
            var scanners = new List<Scanner>();
            var regex = new Regex(@"(-?\d+),(-?\d+),(-?\d+)", RegexOptions.Compiled);

            var scanner = new Scanner();
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    scanners.Add(scanner);
                    scanner = new Scanner();
                }
                else if (!line.StartsWith("--- scanner"))
                {
                    // 497,-409,-534
                    var match = regex.Match(line);

                    var beacon = new Beacon
                    {
                        X = int.Parse(match.Groups[1].Value),
                        Y = int.Parse(match.Groups[2].Value),
                        Z = int.Parse(match.Groups[3].Value)
                    };

                    scanner.Beacons.Add(beacon);
                }
            }

            scanners.Add(scanner);

            return scanners;
        }

        private class Scanner
        {
            public List<Beacon> Beacons { get; set; } = new List<Beacon>();
        }

        private class Beacon
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
        }
    }
}
