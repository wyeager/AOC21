using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day20Tests
    {
        [TestMethod]
        public void Day20_Part1()
        {
            string input = Util.GetInput("Day20/Input.txt");

            long actual = Day20.SolvePart1(input);
            long expected = 5275;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day20_Part1Example()
        {
            string input = Util.GetInput("Day20/Example.txt");

            long actual = Day20.SolvePart1(input);
            long expected = 35;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day20_Part2()
        {
            string input = Util.GetInput("Day20/Input.txt");

            long actual = Day20.SolvePart2(input);
            long expected = 16482;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day20_Part2Example()
        {
            string input = Util.GetInput("Day20/Example.txt");

            long actual = Day20.SolvePart2(input);
            long expected = 3351;

            Assert.AreEqual(actual, expected);
        }
    }
}
