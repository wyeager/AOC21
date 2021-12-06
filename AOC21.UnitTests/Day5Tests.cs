using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day5Tests
    {
        [TestMethod]
        public void Day5_Part1_ReturnsCorrect()
        {
            string input = Util.GetInput("Day5/Input.txt");

            int actual = Day5.SolvePart1(input);
            int expected = 5373;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day5_Part1Description_ReturnsCorrect()
        {
            string input = Util.GetInput("Day5/Example.txt");

            int actual = Day5.SolvePart1(input);
            int expected = 5;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day5_Part2_ReturnsCorrect()
        {
            string input = Util.GetInput("Day5/Input.txt");

            int actual = Day5.SolvePart2(input);
            int expected = 21514;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day5_Part2Description_ReturnsCorrect()
        {
            string input = Util.GetInput("Day5/Example.txt");

            int actual = Day5.SolvePart2(input);
            int expected = 12;

            Assert.AreEqual(actual, expected);
        }
    }
}
