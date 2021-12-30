using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day21Tests
    {
        [TestMethod]
        public void Day21_Part1()
        {
            string input = Util.GetInput("Day21/Input.txt");

            long actual = Day21.SolvePart1(input);
            long expected = 551901;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day21_Part1Example()
        {
            string input = Util.GetInput("Day21/Example.txt");

            long actual = Day21.SolvePart1(input);
            long expected = 739785;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day21_Part2()
        {
            string input = Util.GetInput("Day21/Input.txt");
            var day21 = new Day21();

            long actual = day21.SolvePart2(input);
            long expected = 272847859601291;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day21_Part2Example()
        {
            string input = Util.GetInput("Day21/Example.txt");
            var day21 = new Day21();

            long actual = day21.SolvePart2(input);
            long expected = 444356092776315;

            Assert.AreEqual(actual, expected);
        }
    }
}
