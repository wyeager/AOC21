using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day11Tests
    {
        [TestMethod]
        public void Day11_Part1()
        {
            string input = Util.GetInput("Day11/Input.txt");
            var day11 = new Day11();

            int actual = day11.SolvePart1(input);
            int expected = 1686;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day11_Part2()
        {
            string input = Util.GetInput("Day11/Input.txt");
            var day11 = new Day11();

            int actual = day11.SolvePart2(input);
            int expected = 360;

            Assert.AreEqual(actual, expected);
        }
    }
}
