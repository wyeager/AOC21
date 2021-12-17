using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day14Tests
    {
        [TestMethod]
        public void Day14_Part1_ReturnsCorrect()
        {
            string input = Util.GetInput("Day14/Input.txt");

            int actual = Day14.SolvePart1(input);
            int expected = 3230;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day14_Part1Example_ReturnsCorrect()
        {
            string input = Util.GetInput("Day14/Example.txt");

            int actual = Day14.SolvePart1(input);
            int expected = 1588;

            Assert.AreEqual(actual, expected);
        }
    }
}
