using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
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

            int actual = Day6.SolvePart1(input);
            int expected = 0;

            Assert.AreEqual(actual, expected);
        }
    }
}
