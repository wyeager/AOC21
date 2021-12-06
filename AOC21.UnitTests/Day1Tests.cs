using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day1Tests
    {
        [TestMethod]
        public void Day1_Part1_ReturnsCorrect()
        {
            string input = Util.GetInput("Day1/Input.txt");

            int actual = Day1.SolvePart1(input);
            int expected = 1713;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day1_Part2_ReturnsCorrect()
        {
            string input = Util.GetInput("Day1/Input.txt");

            int actual = Day1.SolvePart2(input);
            int expected = 1734;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day1_Part2_Description_ReturnsCorrect()
        {
            string input = Util.GetInput("Day1/Part2Example.txt");

            int actual = Day1.SolvePart2(input);
            int expected = 5;

            Assert.AreEqual(actual, expected);
        }
    }
}
