using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day7Tests
    {
        [TestMethod]
        public void Day7_Part1_ReturnsCorrect()
        {
            string input = Util.GetInput("Day7/Input.txt");

            int actual = Day7.SolvePart1(input);
            int expected = 341534;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day7_Part2_ReturnsCorrect()
        {
            string input = Util.GetInput("Day7/Input.txt");

            int actual = Day7.SolvePart2(input);
            int expected = 93397632;

            Assert.AreEqual(actual, expected);
        }
    }
}
