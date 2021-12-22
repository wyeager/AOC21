using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day18Tests
    {
        [TestMethod]
        public void Day18_Part1()
        {
            string input = Util.GetInput("Day18/Input.txt");

            long actual = Day18.SolvePart1(input);
            long expected = 4124;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day18_Part1Example()
        {
            string input = Util.GetInput("Day18/Example.txt");

            long actual = Day18.SolvePart1(input);
            long expected = 4140;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day18_Part2()
        {
            string input = Util.GetInput("Day18/Input.txt");

            long actual = Day18.SolvePart2(input);
            long expected = 4673;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day18_Part2Example()
        {
            string input = Util.GetInput("Day18/Example.txt");

            long actual = Day18.SolvePart2(input);
            long expected = 3993;

            Assert.AreEqual(actual, expected);
        }
    }
}
