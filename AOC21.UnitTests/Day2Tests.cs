using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day2Tests
    {
        [TestMethod]
        public void Day2_Part1_ReturnsCorrect()
        {
            string input = Util.GetInput("Day2/Input.txt");

            // Act
            int actual = Day2.SolvePart1(input);

            int expected = 1815044;

            // Asset
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day2_Part2_ReturnsCorrect()
        {
            string input = Util.GetInput("Day2/Input.txt");

            // Act
            int actual = Day2.SolvePart2(input);

            int expected = 1739283308;

            // Asset
            Assert.AreEqual(actual, expected);
        }
    }
}
