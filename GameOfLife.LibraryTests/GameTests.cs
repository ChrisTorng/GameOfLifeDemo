using GameOfLife.LibraryTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Library.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void CreateBoardTest()
        {
            // Arrange
            var game = new Game();

            // Act
            var board = game.CreateBoard(1, 1);

            // Assert
            Assert.IsNotNull(board);
            Assert.IsNotNull(game.Board);
            Assert.AreEqual(board, game.Board);
        }

        [TestMethod]
        public void CurrentState_Test()
        {
            var game = new Game();
            var board = game.CreateBoard(1, 1);

            int actual = game.CurrentState(0, 0);

            Assert.AreEqual(0, actual);

            actual = game.CurrentState(-1, 0);
            Assert.AreEqual(0, actual);

            actual = game.CurrentState(0, -1);
            Assert.AreEqual(0, actual);

            board.Columns[0][0] = true;

            actual = game.CurrentState(0, 0);
            Assert.AreEqual(1, actual);

            actual = game.CurrentState(-1, 0);
            Assert.AreEqual(0, actual);

            actual = game.CurrentState(0, -1);
            Assert.AreEqual(0, actual);

            actual = game.CurrentState(1, 0);
            Assert.AreEqual(0, actual);

            actual = game.CurrentState(0, 1);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GetAliveNeighbors_3x3Empty_Test()
        {
            var game = new Game();
            game.CreateBoard(3, 3);

            var actual = game.GetAliveNeighbors(0, 0);
            Assert.AreEqual(0, actual);

            actual = game.GetAliveNeighbors(1, 1);
            Assert.AreEqual(0, actual);

            actual = game.GetAliveNeighbors(2, 2);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GetAliveNeighbors_3x3Full_Test()
        {
            var game = new Game();
            var board = game.CreateBoard(3, 3);

            board.Columns[0][0] = true;
            board.Columns[1][0] = true;
            board.Columns[2][0] = true;
            board.Columns[0][1] = true;
            board.Columns[1][1] = true;
            board.Columns[2][1] = true;
            board.Columns[0][2] = true;
            board.Columns[1][2] = true;
            board.Columns[2][2] = true;

            var actual = game.GetAliveNeighbors(0, 0);
            Assert.AreEqual(3, actual);

            actual = game.GetAliveNeighbors(1, 1);
            Assert.AreEqual(8, actual);

            actual = game.GetAliveNeighbors(2, 2);
            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void ApplyCellRules_1x1_Test()
        {
            var game = new Game();
            var board = game.CreateBoard(1, 1);
            var nextBoard = new Board(1, 1);

            game.ApplyCellRules(nextBoard, 0, 0);
            Assert.AreEqual(false, nextBoard.Columns[0][0]);

            board.Columns[0][0] = true;
            game.ApplyCellRules(nextBoard, 0, 0);
            Assert.AreEqual(false, nextBoard.Columns[0][0]);
        }

        [TestMethod]
        public void ApplyCellRules_3x3Empty_Test()
        {
            var game = new Game();
            var board = game.CreateBoard(3, 3);
            var nextBoard = new Board(3, 3);

            game.ApplyCellRules(nextBoard, 1, 1);
            Assert.AreEqual(false, nextBoard.Columns[1][1]);

            board.Columns[1][1] = true;
            game.ApplyCellRules(nextBoard, 1, 1);
            Assert.AreEqual(false, nextBoard.Columns[1][1]);
        }

        [TestMethod]
        public void ApplyCellRules_3x3Full_Test()
        {
            var game = new Game();
            var board = game.CreateBoard(3, 3);
            var nextBoard = new Board(3, 3);

            board.Columns[0][0] = true;
            board.Columns[1][0] = true;
            board.Columns[2][0] = true;
            board.Columns[0][1] = true;
            board.Columns[1][1] = true;
            board.Columns[2][1] = true;
            board.Columns[0][2] = true;
            board.Columns[1][2] = true;
            board.Columns[2][2] = true;

            game.ApplyCellRules(nextBoard, 1, 1);
            Assert.AreEqual(false, nextBoard.Columns[1][1]);
        }

        [TestMethod]
        public void ApplyCellRules_3x3Alive1_Test()
        {
            var game = new Game();
            var board = game.CreateBoard(3, 3);
            var nextBoard = new Board(3, 3);

            board.Columns[0][1] = true;
            board.Columns[1][1] = true;

            game.ApplyCellRules(nextBoard, 1, 1);
            Assert.AreEqual(false, nextBoard.Columns[1][1]);
        }

        [TestMethod]
        public void ApplyCellRules_3x3Alive2_Test()
        {
            var game = new Game();
            var board = game.CreateBoard(3, 3);
            var nextBoard = new Board(3, 3);

            board.Columns[0][1] = true;
            board.Columns[1][1] = true;
            board.Columns[2][1] = true;

            game.ApplyCellRules(nextBoard, 1, 1);
            Assert.AreEqual(true, nextBoard.Columns[1][1]);
        }

        [TestMethod]
        public void ApplyCellRules_3x3Alive3_Test()
        {
            var game = new Game();
            var board = game.CreateBoard(3, 3);
            var nextBoard = new Board(3, 3);

            board.Columns[1][0] = true;
            board.Columns[0][1] = true;
            board.Columns[1][1] = true;
            board.Columns[2][1] = true;

            game.ApplyCellRules(nextBoard, 1, 1);
            Assert.AreEqual(true, nextBoard.Columns[1][1]);
        }

        [TestMethod]
        public void ApplyCellRules_3x3Alive4_Test()
        {
            var game = new Game();
            var board = game.CreateBoard(3, 3);
            var nextBoard = new Board(3, 3);

            board.Columns[1][0] = true;
            board.Columns[0][1] = true;
            board.Columns[1][1] = true;
            board.Columns[2][1] = true;
            board.Columns[1][2] = true;

            game.ApplyCellRules(nextBoard, 1, 1);
            Assert.AreEqual(false, nextBoard.Columns[1][1]);
        }

        [TestMethod]
        public void ApplyCellRules_3x3Born2_Test()
        {
            var game = new Game();
            var board = game.CreateBoard(3, 3);
            var nextBoard = new Board(3, 3);

            board.Columns[0][1] = true;
            board.Columns[2][1] = true;

            game.ApplyCellRules(nextBoard, 1, 1);
            Assert.AreEqual(false, nextBoard.Columns[1][1]);
        }

        [TestMethod]
        public void ApplyCellRules_3x3Born3_Test()
        {
            var game = new Game();
            var board = game.CreateBoard(3, 3);
            var nextBoard = new Board(3, 3);

            board.Columns[1][0] = true;
            board.Columns[0][1] = true;
            board.Columns[2][1] = true;

            game.ApplyCellRules(nextBoard, 1, 1);
            Assert.AreEqual(true, nextBoard.Columns[1][1]);
        }

        [TestMethod]
        public void ApplyCellRules_3x3Born4_Test()
        {
            var game = new Game();
            var board = game.CreateBoard(3, 3);
            var nextBoard = new Board(3, 3);

            board.Columns[1][0] = true;
            board.Columns[0][1] = true;
            board.Columns[2][1] = true;
            board.Columns[1][2] = true;

            game.ApplyCellRules(nextBoard, 1, 1);
            Assert.AreEqual(false, nextBoard.Columns[1][1]);
        }

        [TestMethod]
        public void NextBoard_1x1Empty_Test()
        {
            var game = new Game();
            var board = game.CreateBoard(1, 1);
            var nextBoard = game.NextBoard();

            Assert.AreEqual(false, nextBoard.Columns[0][0]);

            board.Columns[0][0] = true;

            Assert.AreEqual(false, nextBoard.Columns[0][0]);
        }

        [TestMethod]
        public void NextBoard_3x3Empty_Test()
        {
            var game = new Game();
            game.CreateBoard(3, 3);
            var nextBoard = game.NextBoard();

            Assert.AreEqual(false, nextBoard.Columns[0][0]);
            Assert.AreEqual(false, nextBoard.Columns[1][0]);
            Assert.AreEqual(false, nextBoard.Columns[2][0]);
            Assert.AreEqual(false, nextBoard.Columns[0][1]);
            Assert.AreEqual(false, nextBoard.Columns[1][1]);
            Assert.AreEqual(false, nextBoard.Columns[2][1]);
            Assert.AreEqual(false, nextBoard.Columns[0][2]);
            Assert.AreEqual(false, nextBoard.Columns[1][2]);
            Assert.AreEqual(false, nextBoard.Columns[2][2]);
        }

        [TestMethod]
        public void NextBoard_3x3Full_Test()
        {
            var game = new Game();
            var board = game.CreateBoard(3, 3);

            board.Columns[0][0] = true;
            board.Columns[1][0] = true;
            board.Columns[2][0] = true;
            board.Columns[0][1] = true;
            board.Columns[1][1] = true;
            board.Columns[2][1] = true;
            board.Columns[0][2] = true;
            board.Columns[1][2] = true;
            board.Columns[2][2] = true;

            var nextBoard = game.NextBoard();
            Assert.AreEqual(true, nextBoard.Columns[0][0]);
            Assert.AreEqual(false, nextBoard.Columns[1][0]);
            Assert.AreEqual(true, nextBoard.Columns[2][0]);
            Assert.AreEqual(false, nextBoard.Columns[0][1]);
            Assert.AreEqual(false, nextBoard.Columns[1][1]);
            Assert.AreEqual(false, nextBoard.Columns[2][1]);
            Assert.AreEqual(true, nextBoard.Columns[0][2]);
            Assert.AreEqual(false, nextBoard.Columns[1][2]);
            Assert.AreEqual(true, nextBoard.Columns[2][2]);
        }

        [TestMethod]
        public void NextBoard_3x3OneLine_Test()
        {
            var game = new Game();
            var board = game.CreateBoard(3, 3);

            board.Columns[0][1] = true;
            board.Columns[1][1] = true;
            board.Columns[2][1] = true;

            var actualNextBoard = game.NextBoard();

            var expectedBoard = new Board(3, 3);
            expectedBoard.Columns[1][0] = true;
            expectedBoard.Columns[1][1] = true;
            expectedBoard.Columns[1][2] = true;

            Assert.That.BoardsEqual(expectedBoard, actualNextBoard);
        }

        [TestMethod]
        public void Step_Test()
        {
            var game = new Game();
            var board = game.CreateBoard(3, 3);

            board.Columns[0][1] = true;
            board.Columns[1][1] = true;
            board.Columns[2][1] = true;

            // Act
            var actualNextBoard = game.Step();

            var expectedBoard = new Board(3, 3);
            expectedBoard.Columns[1][0] = true;
            expectedBoard.Columns[1][1] = true;
            expectedBoard.Columns[1][2] = true;

            Assert.AreSame(actualNextBoard, game.Board);
            Assert.That.BoardsEqual(expectedBoard, actualNextBoard);
        }
    }
}
