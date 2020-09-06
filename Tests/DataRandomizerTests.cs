using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestFramework.API;
using MSTestFramework.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestFramework.Tests
{
    [TestClass]
    public class DataRandomizerTests
    {
        [TestMethod]
        public void AlphaLowerTest()
        {
            var alphaLower = DataRandomizer.CreateString(DataRandomizer.DataType.AlphaLower, 10);
            Assert.IsTrue(alphaLower.All(ch => char.IsLower(ch)), $"The string {alphaLower} wasn't all lowercase.");
            Assert.AreEqual(10, alphaLower.Length, "The string length wasn't 10.");
        }

        [TestMethod]
        public void AlphaUpperTest()
        {
            var alphaUpper = DataRandomizer.CreateString(DataRandomizer.DataType.AlphaUpper, 10);
            Assert.IsTrue(alphaUpper.All(ch => char.IsUpper(ch)), $"The string {alphaUpper} wasn't all uppercase.");
            Assert.AreEqual(10, alphaUpper.Length, "The string length wasn't 10.");
        }

        [TestMethod]
        public void AlphaLowerUpperTest()
        {
            var alphaLowerUpper = DataRandomizer.CreateString(DataRandomizer.DataType.AlphaLowerUpper, 10);
            Assert.IsTrue(alphaLowerUpper.Any(ch => char.IsUpper(ch)), $"The string {alphaLowerUpper} didn't contain uppercase.");
            Assert.IsTrue(alphaLowerUpper.Any(ch => char.IsLower(ch)), $"The string {alphaLowerUpper} didn't contain lowercase.");
            Assert.AreEqual(10, alphaLowerUpper.Length, "The string length wasn't 10.");
        }

        [TestMethod]
        public void AlphaLowerNumericTest()
        {
            var alphaLowerNumeric = DataRandomizer.CreateString(DataRandomizer.DataType.AlphaLowerNumeric, 10);
            Assert.IsTrue(alphaLowerNumeric.Any(ch => char.IsLower(ch)), $"The string {alphaLowerNumeric} didn't contain lowercase.");
            Assert.IsTrue(alphaLowerNumeric.Any(ch => char.IsNumber(ch)), $"The string {alphaLowerNumeric} didn't contain a number.");
            Assert.AreEqual(10, alphaLowerNumeric.Length, "The string length wasn't 10.");
        }

        [TestMethod]
        public void AlphaUpperNumericTest()
        {
            var alphaUpperNumeric = DataRandomizer.CreateString(DataRandomizer.DataType.AlphaUpperNumeric, 10);
            Assert.IsTrue(alphaUpperNumeric.Any(ch => char.IsUpper(ch)), $"The string {alphaUpperNumeric} didn't contain uppercase.");
            Assert.IsTrue(alphaUpperNumeric.Any(ch => char.IsNumber(ch)), $"The string {alphaUpperNumeric} didn't contain a number.");
            Assert.AreEqual(10, alphaUpperNumeric.Length, "The string length wasn't 10.");
        }

        [TestMethod]
        public void AlphaLowerUpperNumericTest()
        {
            var alphaLowerUpperNumeric = DataRandomizer.CreateString(DataRandomizer.DataType.AlphaLowerUpperNumeric, 10);
            Assert.IsTrue(alphaLowerUpperNumeric.Any(ch => char.IsUpper(ch)), $"The string {alphaLowerUpperNumeric} didn't contain uppercase.");
            Assert.IsTrue(alphaLowerUpperNumeric.Any(ch => char.IsLower(ch)), $"The string {alphaLowerUpperNumeric} didn't contain lowercase.");
            Assert.IsTrue(alphaLowerUpperNumeric.Any(ch => char.IsNumber(ch)), $"The string {alphaLowerUpperNumeric} didn't contain a number.");
            Assert.AreEqual(10, alphaLowerUpperNumeric.Length, "The string length wasn't 10.");
        }

        [TestMethod]
        public void NumericTest()
        {
            var numeric = DataRandomizer.CreateString(DataRandomizer.DataType.Numeric, 10);
            Assert.IsTrue(numeric.All(ch => char.IsNumber(ch)), $"The string {numeric} didn't contain all numbers.");
            Assert.AreEqual(10, numeric.Length, "The string length wasn't 10.");
        }
    }
}
