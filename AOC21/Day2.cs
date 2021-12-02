using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC21
{
    public class Day2
    {
        public static int SolvePart1(string input)
        {
            int horizontal = 0;
            int depth = 0;

            List<Direction> directions = ParseInput(input);

            foreach (var direction in directions)
            {
                switch (direction.DirectionType)
                {
                    case DirectionType.FORWARD:
                        horizontal += direction.Amount;
                        break;
                    case DirectionType.UP:
                        depth -= direction.Amount;
                        break;
                    case DirectionType.DOWN:
                        depth += direction.Amount;
                        break;
                    default:
                        throw new Exception("Unrecognized direction type");
                }
            }

            return horizontal * depth;
        }

        public static int SolvePart2(string input)
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            List<Direction> directions = ParseInput(input);

            foreach (var direction in directions)
            {
                switch (direction.DirectionType)
                {
                    case DirectionType.FORWARD:
                        horizontal += direction.Amount;
                        depth += aim * direction.Amount;
                        break;
                    case DirectionType.UP:
                        aim -= direction.Amount;
                        break;
                    case DirectionType.DOWN:
                        aim += direction.Amount;
                        break;
                    default:
                        throw new Exception("Unrecognized direction type");
                }
            }

            return horizontal * depth;
        }

        private static List<Direction> ParseInput(string input) =>
            input
                .Split("\r\n")
                .Select(s =>
                {
                    var instruction = s.Split(" ");

                    var directionType = instruction[0] switch
                    {
                        "forward" => DirectionType.FORWARD,
                        "up" => DirectionType.UP,
                        "down" => DirectionType.DOWN,
                        _ => throw new Exception("Unrecognized direction type")
                    };

                    int amount = int.Parse(instruction[1]);

                    return new Direction
                    {
                        DirectionType = directionType,
                        Amount = amount
                    };
                })
                .ToList();
        

        private class Direction
        {
            public DirectionType DirectionType { get; set; }
            public int Amount { get; set; }
        }

        private enum DirectionType
        {
            FORWARD,
            UP,
            DOWN
        }
    }
}
