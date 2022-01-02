using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day22Tests
    {
        [TestMethod]
        public void Day22_Part1()
        {
            string input = Util.GetInput("Day22/Input.txt");

            long actual = Day22.SolvePart1(input);
            long expected = 642125;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day22_Part1Example()
        {
            string input = Util.GetInput("Day22/Example.txt");

            long actual = Day22.SolvePart1(input);
            long expected = 590784;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day22_Part2()
        {
            string input = Util.GetInput("Day22/Input.txt");

            long actual = Day22.SolvePart2(input);
            long expected = 1235164413198198;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day22_Part2Example()
        {
            string input = Util.GetInput("Day22/Example2.txt");

            long actual = Day22.SolvePart2(input);
            long expected = 2758514936282235;

            Assert.AreEqual(actual, expected);
        }
    }
}
