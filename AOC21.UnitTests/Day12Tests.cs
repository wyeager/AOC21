using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day12Tests
    {
        [TestMethod]
        public void Day12_Part1()
        {
            string input = Util.GetInput("Day12/Input.txt");
            var day12 = new Day12();

            int actual = day12.SolvePart1(input);
            int expected = 5104;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day12_Part1Example1()
        {
            string input = Util.GetInput("Day12/Example1.txt");
            var day12 = new Day12();

            int actual = day12.SolvePart1(input);
            int expected = 10;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day12_Part2Example1()
        {
            string input = Util.GetInput("Day12/Example1.txt");
            var day12 = new Day12();

            int actual = day12.SolvePart2(input);
            int expected = 36;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day12_Part2()
        {
            string input = Util.GetInput("Day12/Input.txt");
            var day12 = new Day12();

            int actual = day12.SolvePart2(input);
            int expected = 149220;

            Assert.AreEqual(actual, expected);
        }
    }
}
