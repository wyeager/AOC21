using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day9Tests
    {
        [TestMethod]
        public void Day9_Part1_ReturnsCorrect()
        {
            string input = Util.GetInput("Day9/Input.txt");
            var day9 = new Day9();

            int actual = day9.SolvePart1(input);
            int expected = 448;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day9_Part2_ReturnsCorrect()
        {
            string input = Util.GetInput("Day9/Input.txt");
            var day9 = new Day9();

            int actual = day9.SolvePart2(input);
            int expected = 1417248;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day9_Part2Example_ReturnsCorrect()
        {
            string input = Util.GetInput("Day9/Example.txt");
            var day9 = new Day9();

            int actual = day9.SolvePart2(input);
            int expected = 1134;

            Assert.AreEqual(actual, expected);
        }
    }
}
