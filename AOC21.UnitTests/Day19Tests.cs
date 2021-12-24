using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day19Tests
    {
        [TestMethod]
        public void Day19_Part1()
        {
            string input = Util.GetInput("Day19/Input.txt");

            long actual = Day19.SolvePart1(input);
            long expected = 0;

            Assert.AreEqual(actual, expected);
        }
    }
}
