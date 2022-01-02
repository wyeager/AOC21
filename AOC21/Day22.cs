using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC21
{
    public class Day22
    {
        public static long SolvePart1(string input)
        {
            List<Instruction> instructions = ParseInput(input);

            var grid = new bool[101, 101, 101];

            foreach (var instruction in instructions)
            {
                for (int x = Math.Max(-50, instruction.XRange.Start); x <= Math.Min(50, instruction.XRange.End); x++)
                {
                    for (int y = Math.Max(-50, instruction.YRange.Start); y <= Math.Min(50, instruction.YRange.End); y++)
                    {
                        for (int z = Math.Max(-50, instruction.ZRange.Start); z <= Math.Min(50, instruction.ZRange.End); z++)
                        {
                            grid[x + 50, y + 50, z + 50] = instruction.On;
                        }
                    }
                }
            }

            int cubesTurnedOn = 0;
            for (int x = 0; x < 101; x++)
            {
                for (int y = 0; y < 101; y++)
                {
                    for (int z = 0; z < 101; z++)
                    {
                        cubesTurnedOn += grid[x, y, z] ? 1 : 0;
                    }
                }
            }

            return cubesTurnedOn;
        }

        // basically stole solution from this guy: https://github.com/viceroypenguin/adventofcode/blob/master/2021/day22.original.cs
        public static long SolvePart2(string input)
        {
            List<Instruction> instructions = ParseInput(input);

            var cuboids = new List<Instruction>();

            long cubesTurnedOn = 0;
            foreach (var instruction in instructions)
            {
                cuboids.AddRange(
                    cuboids
                        .Select(b2 => Overlap(instruction, b2))
                        .Where(o => o.IsValid())
                        .ToList());

                if (instruction.On)
                {
                    cuboids.Add(instruction);
                }
            }

            cubesTurnedOn = cuboids.Sum(b => b.GetVolume() * (b.On ? 1 : -1));

            return cubesTurnedOn;
        }

        private static List<Instruction> ParseInput(string input)
        {
            var regex = new Regex(@"(on|off) x=(-?\d+)..(-?\d+),y=(-?\d+)..(-?\d+),z=(-?\d+)..(-?\d+)", RegexOptions.Compiled);

            return input
                .Split("\r\n")
                .Select(s =>
                {
                    var match = regex.Match(s);

                    bool on = match.Groups[1].Value == "on";

                    int xStart = int.Parse(match.Groups[2].Value);
                    int xEnd = int.Parse(match.Groups[3].Value);

                    int yStart = int.Parse(match.Groups[4].Value);
                    int yEnd = int.Parse(match.Groups[5].Value);

                    int zStart = int.Parse(match.Groups[6].Value);
                    int zEnd = int.Parse(match.Groups[7].Value);

                    return new Instruction
                    {
                        XRange = new Range(xStart, xEnd),
                        YRange = new Range(yStart, yEnd),
                        ZRange = new Range(zStart, zEnd),
                        On = on
                    };
                })
                .ToList();
        }

        private static Instruction Overlap(
            Instruction instruction1,
            Instruction instruction2) =>
            new()
            {
                On = !instruction2.On,
                XRange = new Range(Math.Max(instruction1.XRange.Start, instruction2.XRange.Start), Math.Min(instruction1.XRange.End, instruction2.XRange.End)),
                YRange = new Range(Math.Max(instruction1.YRange.Start, instruction2.YRange.Start), Math.Min(instruction1.YRange.End, instruction2.YRange.End)),
                ZRange = new Range(Math.Max(instruction1.ZRange.Start, instruction2.ZRange.Start), Math.Min(instruction1.ZRange.End, instruction2.ZRange.End))
            };
    }

    public class Range
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Range(int start, int end)
        {
            Start = start;
            End = end;
        }
    }

    public class Instruction
    {
        public Range XRange { get; set; }
        public Range YRange { get; set; }
        public Range ZRange { get; set; }
        public bool On { get; set; }

        public bool IsValid()
        {
            return XRange.Start <= XRange.End && YRange.Start <= YRange.End && ZRange.Start <= ZRange.End;
        }

        public long GetVolume()
        {
            return (XRange.End - XRange.Start + 1L) * (YRange.End - YRange.Start + 1) * (ZRange.End - ZRange.Start + 1);
        }
    }
}
