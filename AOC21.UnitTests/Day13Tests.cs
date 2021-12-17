using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day13Tests
    {
        [TestMethod]
        public void Day13_Part1_ReturnsCorrect()
        {
            string input = Util.GetInput("Day13/Input.txt");

            int actual = Day13.SolvePart1(input);
            int expected = 781;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day13_Part1Example_ReturnsCorrect()
        {
            string input = Util.GetInput("Day13/Example.txt");

            int actual = Day13.SolvePart1(input);
            int expected = 17;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day13_Part2_ReturnsCorrect()
        {
            string input = Util.GetInput("Day13/Input.txt");

            string actual = Day13.SolvePart2(input);
            string expected = @"
###..####.###...##...##....##.###..###..
#..#.#....#..#.#..#.#..#....#.#..#.#..#.
#..#.###..#..#.#....#.......#.#..#.###..
###..#....###..#....#.##....#.###..#..#.
#....#....#.#..#..#.#..#.#..#.#....#..#.
#....####.#..#..##...###..##..#....###..
";

            Assert.AreEqual(actual.Trim(), expected.Trim());
        }
    }
}
