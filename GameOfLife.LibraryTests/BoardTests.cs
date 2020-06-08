using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Library.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void Constructor_Valid_Test()
        {
            // Arrange
            var board = new Board(10, 20);

            // Act

            // Assert
            Assert.AreEqual(10, board.Width);
            Assert.AreEqual(20, board.Height);
        }

        [TestMethod]
        public void Constructor_InvalidWidth_Test()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                new Board(0, 20));
        }

        [TestMethod]
        public void Constructor_InvalidHeight_Test()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                new Board(10, 0));
        }
    }
}
