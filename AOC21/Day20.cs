using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC21
{
    public class Day20
    {
        public static long SolvePart1(string input)
        {
            return Solve(input, 2);
        }

        public static long SolvePart2(string input)
        {
            return Solve(input, 50);
        }

        private static long Solve(string input, int steps)
        {
            var (enhancer, inputImage) = ParseInput(input);

            var outputImage = new bool[inputImage.GetLength(0) + 2, inputImage.GetLength(1) + 2];

            for (int i = 0; i < steps; i++)
            {
                Enhance(enhancer, inputImage, outputImage, i);

                inputImage = outputImage;

                outputImage = new bool[inputImage.GetLength(0) + 2, inputImage.GetLength(1) + 2];
            }

            int litPixels = 0;
            foreach (bool pixel in inputImage)
            {
                litPixels += pixel ? 1 : 0;
            }

            return litPixels;
        }

        private static void Print(bool[,] image)
        {
            for (int row = 0; row < image.GetLength(0); row++)
            {
                for (int col = 0; col < image.GetLength(1); col++)
                {
                    System.Diagnostics.Debug.Write(image[row, col] ? "#" : ".");
                }

                System.Diagnostics.Debug.WriteLine("");
            }

            System.Diagnostics.Debug.WriteLine("");
        }

        private static void Enhance(List<bool> enhancer, bool[,] inputImage, bool[,] outputImage, int stepNum)
        {
            int rowLength = outputImage.GetLength(0);
            int colLength = outputImage.GetLength(1);
            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    int index = GetIndex(inputImage, rowLength, colLength, row, col, enhancer, stepNum);

                    outputImage[row, col] = enhancer[index];
                }
            }
        }

        private static int GetIndex(
            bool[,] inputImage,
            int rowLength,
            int colLength,
            int row,
            int col,
            List<bool> enhancer,
            int stepNum)
        {
            var directions = new (int, int)[] {
                (-1, -1), (-1, 0), (-1, 1),
                (0, -1), (0, 0), (0, 1),
                (1, -1), (1, 0), (1, 1)
            };

            string indexStr = "";
            foreach (var (rowDir, colDir) in directions)
            {
                int r = row + rowDir;
                int c = col + colDir;

                if (r <= 0 || r >= rowLength - 1 || c <= 0 || c >= colLength - 1)
                {
                    indexStr += enhancer[0] && stepNum % 2 != 0 ? "1" : "0";
                } else
                {
                    indexStr += inputImage[r - 1, c - 1] ? "1" : "0";
                }
            }

            return Convert.ToInt32(indexStr, 2);
        }

        private static (List<bool>, bool[,]) ParseInput(string input)
        {
            List<string> lines = input
                .Split("\r\n")
                .ToList();

            List<bool> enhancer = lines[0]
                .Select(c => c == '#')
                .ToList();

            var image = new bool[lines.Count - 2, lines[2].Length];

            lines = lines.Skip(2).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    image[i, j] = lines[i][j] == '#';
                }
            }

            return (enhancer, image);
        }
    }
}
