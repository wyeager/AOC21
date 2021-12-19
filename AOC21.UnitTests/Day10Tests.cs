using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day10Tests
    {
        [TestMethod]
        public void Day10_Part1()
        {
            string input = Util.GetInput("Day10/Input.txt");

            int actual = Day10.SolvePart1(input);
            int expected = 278475;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day10_Part1Example()
        {
            string input = Util.GetInput("Day10/Example.txt");

            int actual = Day10.SolvePart1(input);
            int expected = 26397;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day10_Part2()
        {
            string input = Util.GetInput("Day10/Input.txt");

            long actual = Day10.SolvePart2(input);
            long expected = 3015539998;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day10_Part2Example()
        {
            string input = Util.GetInput("Day10/Example.txt");

            long actual = Day10.SolvePart2(input);
            long expected = 288957;

            Assert.AreEqual(actual, expected);
        }
    }
}
