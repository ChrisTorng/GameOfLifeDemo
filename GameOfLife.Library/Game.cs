using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GameOfLife.LibraryTests")]

namespace GameOfLife.Library
{
    public class Game
    {
        public Board Board { get; private set; }

        public Game()
        {
        }

        public Board CreateBoard(int width, int height)
        {
            this.Board = new Board(width, height);
            return this.Board;
        }

        public Board NextBoard()
        {
            var nextBoard = new Board(this.Board.Width, this.Board.Height);

            this.ApplyBoardRules(nextBoard);

            return nextBoard;
        }

        public Board Step()
        {
            this.Board = this.NextBoard();
            return this.Board;
        }

        private void ApplyBoardRules(Board nextBoard)
        {
            for (int widthIndex = 0; widthIndex < this.Board.Width; widthIndex++)
            {
                this.ApplyColumnRules(nextBoard, widthIndex);
            }
        }

        private void ApplyColumnRules(Board nextBoard, int widthIndex)
        {
            for (int heightIndex = 0; heightIndex < this.Board.Height; heightIndex++)
            {
                this.ApplyCellRules(nextBoard, widthIndex, heightIndex);
            }
        }

        internal void ApplyCellRules(Board nextBoard, int widthIndex, int heightIndex)
        {
            // this.Board.Columns[widthIndex][heightIndex]
            int aliveNeighbors = this.GetAliveNeighbors(widthIndex, heightIndex);

            if (this.Board.Columns[widthIndex][heightIndex])
            {
                if (aliveNeighbors >= 2 && aliveNeighbors <= 3)
                {
                    nextBoard.Columns[widthIndex][heightIndex] = true;
                }
            }
            else
            {
                if (aliveNeighbors == 3)
                {
                    nextBoard.Columns[widthIndex][heightIndex] = true;
                }
            }
        }

        internal int GetAliveNeighbors(int widthIndex, int heightIndex)
        {
            int aliveNeighbors = 0;

            aliveNeighbors += this.CurrentState(widthIndex - 1, heightIndex - 1);
            aliveNeighbors += this.CurrentState(widthIndex, heightIndex - 1);
            aliveNeighbors += this.CurrentState(widthIndex + 1, heightIndex - 1);
            aliveNeighbors += this.CurrentState(widthIndex - 1, heightIndex);
            aliveNeighbors += this.CurrentState(widthIndex + 1, heightIndex);
            aliveNeighbors += this.CurrentState(widthIndex - 1, heightIndex + 1);
            aliveNeighbors += this.CurrentState(widthIndex, heightIndex + 1);
            aliveNeighbors += this.CurrentState(widthIndex + 1, heightIndex + 1);

            return aliveNeighbors;
        }

        internal int CurrentState(int widthIndex, int heightIndex)
        {
            if (widthIndex < 0 || widthIndex >= this.Board.Width ||
                heightIndex < 0 || heightIndex >= this.Board.Height)
            {
                return 0;
            }

            return this.Board.Columns[widthIndex][heightIndex] ? 1 : 0;
        }
    }
}
