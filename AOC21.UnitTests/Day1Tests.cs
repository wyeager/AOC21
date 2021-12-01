using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day1Tests
    {
        [TestMethod]
        public void Day1_Part1_ReturnsCorrect()
        {
            string input = Util.GetInput("Day1/Input.txt");

            // Act
            int actual = Day1.SolvePart1(input);

            int expected = 1713;

            // Asset
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day1_Part2_ReturnsCorrect()
        {
            string input = Util.GetInput("Day1/Input.txt");

            // Act
            int actual = Day1.SolvePart2(input);

            int expected = 1734;

            // Asset
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day1_Part2_Description_ReturnsCorrect()
        {
            string input = Util.GetInput(@"Day1/Part2Description.txt");

            // Act
            int actual = Day1.SolvePart2(input);

            int expected = 5;

            // Asset
            Assert.AreEqual(actual, expected);
        }
    }
}
