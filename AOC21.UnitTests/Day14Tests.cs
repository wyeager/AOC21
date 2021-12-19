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
        public void Day14_Part1()
        {
            string input = Util.GetInput("Day14/Input.txt");

            long actual = Day14.SolvePart1(input);
            long expected = 3230;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day14_Part1Example()
        {
            string input = Util.GetInput("Day14/Example.txt");

            long actual = Day14.SolvePart1(input);
            long expected = 1588;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day14_Part2()
        {
            string input = Util.GetInput("Day14/Input.txt");

            long actual = Day14.SolvePart2(input);
            long expected = 3542388214529;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day14_Part2Example()
        {
            string input = Util.GetInput("Day14/Example.txt");

            long actual = Day14.SolvePart2(input);
            long expected = 2188189693529;

            Assert.AreEqual(actual, expected);
        }
    }
}
