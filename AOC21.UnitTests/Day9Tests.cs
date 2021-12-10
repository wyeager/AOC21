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

            int actual = Day9.SolvePart1(input);
            int expected = 448;

            Assert.AreEqual(actual, expected);
        }
    }
}
