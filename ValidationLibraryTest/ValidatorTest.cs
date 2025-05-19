using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using ValidationLibrary;

namespace ValidationLibraryTest
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void IsDecimal_ValidValue()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "3.14";

            string expected = ""; // arrange
            var result = Validator.IsDecimal(txtBox, "Test"); // act
            Assert.AreEqual(expected, result); // assert
        }

        [TestMethod]
        public void IsDecimal_InvalidValue()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "abc";

            string expected = $"\nTest needs to be a number ex, 100 - 2000000"; // arrange
            var result = Validator.IsDecimal(txtBox, "Test"); // act
            Assert.AreEqual(expected, result); // assert
        }

        [TestMethod]
        public void IsInt_ValidValue()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "1";

            string expected = ""; // arrange
            var result = Validator.IsInt(txtBox, "Decimal Test"); // act
            Assert.AreEqual(expected, result); // assert
        }

        [TestMethod]
        public void IsInt_InvalidValue()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "1.1";

            string expected = $"\nTest needs to be a number ex, 0 - 20"; // arrange
            var result = Validator.IsInt(txtBox, "Test"); // act
            Assert.AreEqual(expected, result); // assert
        }

        [TestMethod]
        public void IsPresent_InvalidValue()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "";

            string expected = $"\nTest is a required field"; // arrange
            var result = Validator.IsPresent(txtBox, "Test"); // act
            Assert.AreEqual(expected, result); // assert
        }

        [TestMethod]
        public void IsPresent_ValidValue()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "test";

            string expected = ""; // arrange
            var result = Validator.IsPresent(txtBox, "Test"); // act
            Assert.AreEqual(expected, result); // assert
        }
    }
}
