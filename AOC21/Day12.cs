using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC21
{
    public class Day12
    {
        readonly Dictionary<string, List<string>> AdjacencyList = new Dictionary<string, List<string>>();

        public int SolvePart1(string input)
        {
            ParseInput(input);

            var paths = DFS(
                "start",
                new List<string> { "start" },
                (cave, path) => !path.Contains(cave) || IsUpper(cave));

            return paths.Count;
        }

        public int SolvePart2(string input)
        {
            ParseInput(input);

            var paths = DFS(
                "start",
                new List<string> { "start" },
                (cave, path) => !path.Contains(cave) || IsUpper(cave) || !AlreadyContainsTwoSmallCaves(path));

            return paths.Count;
        }

        private List<List<string>> DFS(string start, List<string> path, Func<string, List<string>, bool> canAdd)
        {
            // can never visit end twice
            if (start == "end") return new List<List<string>>() { new List<string>(path) };

            var result = new List<List<string>>();

            foreach (var cave in AdjacencyList[start])
            {
                // can never visit start twice
                if (cave == "start")
                {
                    continue;
                }

                if (canAdd(cave, path))
                {
                    result.AddRange(DFS(cave, new List<string>(path) { cave }, canAdd));
                }
            }

            return result;
        }

        private static bool IsUpper(string str) =>
            str.All(c => char.IsUpper(c));

        private static bool AlreadyContainsTwoSmallCaves(List<string> path) =>
            path
                .Where(cave => cave != "start" && cave != "end" && !IsUpper(cave))
                .GroupBy(cave => cave)
                .ToDictionary(
                    grouping => grouping.Key,
                    grouping => grouping.ToList())
                .Values
                .Any(val => val.Count > 1);

        private void ParseInput(string input)
        {
            var lines = input
                .Split("\r\n");

            foreach (var line in lines)
            {
                var start = line.Split("-")[0];
                var end = line.Split("-")[1];

                // add path from start to end vertex
                if (!AdjacencyList.TryAdd(start, new List<string> { end }))
                {
                    AdjacencyList[start].Add(end);
                }

                // also add path from end to start vertex since the graph is not directed
                if (!AdjacencyList.TryAdd(end, new List<string> { start }))
                {
                    AdjacencyList[end].Add(start);
                }
            }
        }
    }
}
