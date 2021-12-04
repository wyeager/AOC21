using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day4Tests
    {
        [TestMethod]
        public void Day4_Part1_ReturnsCorrect()
        {
            string input = Util.GetInput("Day4/Input.txt");

            int actual = Day4.SolvePart1(input);
            int expected = 60368;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day4_Part2_ReturnsCorrect()
        {
            string input = Util.GetInput("Day4/Input.txt");

            int actual = Day4.SolvePart2(input);
            int expected = 17435;

            Assert.AreEqual(actual, expected);
        }
    }
}
