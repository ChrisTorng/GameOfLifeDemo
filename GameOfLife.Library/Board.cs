using System;
using System.Collections;

namespace GameOfLife.Library
{
    public class Board
    {
#pragma warning disable CA1819 // Properties should not return arrays
        public BitArray[] Columns { get; }
#pragma warning restore CA1819 // Properties should not return arrays

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

            this.Columns = new BitArray[width];

            for (int index = 0; index < width; index++)
            {
                this.Columns[index] = new BitArray(height);
            }
        }

        public bool Flip(int widthIndex, int heightIndex)
        {
            if (widthIndex < 0 || widthIndex >= this.Width)
            {
                throw new ArgumentOutOfRangeException(nameof(widthIndex));
            }

            if (heightIndex < 0 || heightIndex >= this.Height)
            {
                throw new ArgumentOutOfRangeException(nameof(heightIndex));
            }

            this.Columns[widthIndex][heightIndex] = !this.Columns[widthIndex][heightIndex];
            return this.Columns[widthIndex][heightIndex];
        }
    }
}
