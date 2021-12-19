using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day15Tests
    {
        [TestMethod]
        public void Day15_Part1_ReturnsCorrect()
        {
            string input = Util.GetInput("Day15/Input.txt");

            long actual = Day15.SolvePart1(input);
            long expected = 472;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day15_Part1Example_ReturnsCorrect()
        {
            string input = Util.GetInput("Day15/Example.txt");

            long actual = Day15.SolvePart1(input);
            long expected = 40;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day15_Part2Example_ReturnsCorrect()
        {
            string input = Util.GetInput("Day15/Example.txt");

            long actual = Day15.SolvePart2(input);
            long expected = 315;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day15_Part2_ReturnsCorrect()
        {
            string input = Util.GetInput("Day15/Input.txt");

            long actual = Day15.SolvePart2(input);
            long expected = 2851;

            Assert.AreEqual(actual, expected);
        }
    }
}
