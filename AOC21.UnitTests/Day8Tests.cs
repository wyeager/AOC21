using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day8Tests
    {
        [TestMethod]
        public void Day8_Part1_ReturnsCorrect()
        {
            string input = Util.GetInput("Day8/Input.txt");

            int actual = Day8.SolvePart1(input);
            int expected = 261;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day8_Part2_ReturnsCorrect()
        {
            string input = Util.GetInput("Day8/Input.txt");

            int actual = Day8.SolvePart2(input);
            int expected = 987553;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day8_Part2Example_ReturnsCorrect()
        {
            string input = Util.GetInput("Day8/Example.txt");

            int actual = Day8.SolvePart2(input);
            int expected = 61229;

            Assert.AreEqual(actual, expected);
        }
    }
}
