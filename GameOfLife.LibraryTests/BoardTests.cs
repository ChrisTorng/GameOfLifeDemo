using GameOfLife.Library;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Library.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void Constructor_ValidWidth1_Test()
        {
            // Arrange
            var board = new Board(1, 1);

            // Act

            // Assert
            Assert.AreEqual(1, board.Width);
        }

        [TestMethod]
        public void Constructor_ValidHeight1_Test()
        {
            // Arrange
            var board = new Board(1, 1);

            // Act

            // Assert
            Assert.AreEqual(1, board.Height);
        }

        [TestMethod]
        public void Constructor_InvalidWidth0_Test()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                new Board(0, 20));
        }

        [TestMethod]
        public void Constructor_InvalidHeight0_Test()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                new Board(10, 0));
        }

        [TestMethod]
        public void Constructor_Columns_Test()
        {
            var board = new Board(2, 3);

            Assert.IsNotNull(board.Columns);
            Assert.AreEqual(2, board.Columns.Length);
            Assert.AreEqual(3, board.Columns[0].Length);
            Assert.AreEqual(3, board.Columns[1].Length);

            board.Columns[1][2] = true;

            Assert.AreEqual(false, board.Columns[0][0]);
            Assert.AreEqual(true, board.Columns[1][2]);
        }

        [TestMethod]
        public void Flip_Test()
        {
            var board = new Board(1, 1);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                board.Flip(-1, 0));

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                board.Flip(1, 0));

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                board.Flip(0, -1));

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                board.Flip(0, 1));

            var actual = board.Flip(0, 0);
            Assert.AreEqual(true, actual);

            actual = board.Flip(0, 0);
            Assert.AreEqual(false, actual);
        }
    }
}
