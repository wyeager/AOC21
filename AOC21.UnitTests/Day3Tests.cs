using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day3Tests
    {
        [TestMethod]
        public void Day3_Part1_ReturnsCorrect()
        {
            string input = Util.GetInput("Day3/Input.txt");

            int actual = Day3.SolvePart1(input);
            int expected = 1997414;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day3_Part2_ReturnsCorrect()
        {
            string input = Util.GetInput("Day3/Input.txt");

            int actual = Day3.SolvePart2(input);
            int expected = 1032597;

            Assert.AreEqual(actual, expected);
        }
    }
}
