using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day3Tests
    {
        [TestMethod]
        public void Day3_Part1()
        {
            string input = Util.GetInput("Day3/Input.txt");

            int actual = Day3.SolvePart1(input);
            int expected = 1997414;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day3_Part2()
        {
            string input = Util.GetInput("Day3/Input.txt");

            int actual = Day3.SolvePart2(input);
            int expected = 1032597;

            Assert.AreEqual(actual, expected);
        }
    }
}
