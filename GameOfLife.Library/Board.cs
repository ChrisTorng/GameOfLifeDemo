using System;
using System.Collections;

namespace GameOfLife.Library
{
    public class Board
    {
        public BitArray[] Rows { get; }

        public int Width { get; }

        public int Height { get; }

        public Board(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width));
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height));
            }

            this.Width = width;
            this.Height = height;
        }
    }
}
