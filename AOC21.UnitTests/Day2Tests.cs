using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day2Tests
    {
        [TestMethod]
        public void Day2_Part1()
        {
            string input = Util.GetInput("Day2/Input.txt");

            int actual = Day2.SolvePart1(input);
            int expected = 1815044;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day2_Part2()
        {
            string input = Util.GetInput("Day2/Input.txt");

            int actual = Day2.SolvePart2(input);
            int expected = 1739283308;

            Assert.AreEqual(actual, expected);
        }
    }
}
