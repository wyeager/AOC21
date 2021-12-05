using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC21.UnitTests.Inputs
{
    [TestClass]
    public class Day5Tests
    {
        [TestMethod]
        public void Day5_Part1_ReturnsCorrect()
        {
            string input = Util.GetInput("Day5/Input.txt");

            int actual = Day5.SolvePart1(input);
            int expected = 0;

            Assert.AreEqual(actual, expected);
        }
    }
}
