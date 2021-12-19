﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC21.UnitTests
{
    [TestClass]
    public class Day16Tests
    {
        [TestMethod]
        public void Day16_Part1_ReturnsCorrect()
        {
            string input = Util.GetInput("Day16/Input.txt");

            long actual = Day16.SolvePart1(input);
            long expected = 1038;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day16_Part1ExampleLiteral_ReturnsCorrect()
        {
            string input = Util.GetInput("Day16/ExampleLiteral.txt");

            long actual = Day16.SolvePart1(input);
            long expected = 6;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day16_Part1ExampleOperator_ReturnsCorrect()
        {
            string input = Util.GetInput("Day16/ExampleOperator.txt");

            long actual = Day16.SolvePart1(input);
            long expected = 9;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day16_Part2_ReturnsCorrect()
        {
            string input = Util.GetInput("Day16/Input.txt");

            long actual = Day16.SolvePart2(input);
            long expected = 246761930504;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day16_Part2ExampleSum_ReturnsCorrect()
        {
            string input = Util.GetInput("Day16/ExampleSum.txt");

            long actual = Day16.SolvePart2(input);
            long expected = 3;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day16_Part2ExampleProduct_ReturnsCorrect()
        {
            string input = Util.GetInput("Day16/ExampleProduct.txt");

            long actual = Day16.SolvePart2(input);
            long expected = 54;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day16_Part2ExampleMin_ReturnsCorrect()
        {
            string input = Util.GetInput("Day16/ExampleMin.txt");

            long actual = Day16.SolvePart2(input);
            long expected = 7;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day16_Part2ExampleMax_ReturnsCorrect()
        {
            string input = Util.GetInput("Day16/ExampleMax.txt");

            long actual = Day16.SolvePart2(input);
            long expected = 9;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day16_Part2ExampleLessThan_ReturnsCorrect()
        {
            string input = Util.GetInput("Day16/ExampleLessThan.txt");

            long actual = Day16.SolvePart2(input);
            long expected = 1;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day16_Part2ExampleGreaterThan_ReturnsCorrect()
        {
            string input = Util.GetInput("Day16/ExampleGreaterThan.txt");

            long actual = Day16.SolvePart2(input);
            long expected = 0;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day16_Part2ExampleEqual_ReturnsCorrect()
        {
            string input = Util.GetInput("Day16/ExampleEqual.txt");

            long actual = Day16.SolvePart2(input);
            long expected = 0;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Day16_Part2Example_ReturnsCorrect()
        {
            string input = Util.GetInput("Day16/Example.txt");

            long actual = Day16.SolvePart2(input);
            long expected = 1;

            Assert.AreEqual(actual, expected);
        }
    }
}
