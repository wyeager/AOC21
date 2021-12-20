using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day17Tests
    {
        [TestMethod]
        public void Day17_Part1()
        {
            string input = Util.GetInput("Day17/Input.txt");

            var actual = Day17.SolvePart1(input);
            long expected = 10296;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day17_Part1Example()
        {
            string input = Util.GetInput("Day17/Example.txt");

            var actual = Day17.SolvePart1(input);
            long expected = 45;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day17_Part2()
        {
            string input = Util.GetInput("Day17/Input.txt");

            var actual = Day17.SolvePart2(input);
            long expected = 2371;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day17_Part2Example()
        {
            string input = Util.GetInput("Day17/Example.txt");

            var actual = Day17.SolvePart2(input);
            long expected = 112;

            Assert.AreEqual(actual, expected);
        }
    }
}
