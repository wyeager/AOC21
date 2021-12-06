using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day6Tests
    {
        [TestMethod]
        public void Day6_Part1_ReturnsCorrect()
        {
            string input = Util.GetInput("Day6/Input.txt");

            BigInteger actual = Day6.SolvePart1(input);
            BigInteger expected = 383160;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day6_Part2_ReturnsCorrect()
        {
            string input = Util.GetInput("Day6/Input.txt");

            BigInteger actual = Day6.SolvePart2(input);
            BigInteger expected = 1721148811504;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day6_Part1Example_ReturnsCorrect()
        {
            string input = Util.GetInput("Day6/Example.txt");

            BigInteger actual = Day6.SolvePart1(input);
            BigInteger expected = 5934;

            Assert.AreEqual(actual, expected);
        }
    }
}
