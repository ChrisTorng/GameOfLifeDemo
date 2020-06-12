using GameOfLife.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.LibraryTests
{
    public static class AssertExtensions
    {
#pragma warning disable SA1313 // Parameter names should begin with lower-case letter
        public static void BoardsEqual(this Assert _, Board expected, Board actual)
#pragma warning restore SA1313 // Parameter names should begin with lower-case letter
        {
#pragma warning disable CA1062 // Validate arguments of public methods
            Assert.AreEqual(expected.Width, actual.Width);
#pragma warning restore CA1062 // Validate arguments of public methods
            Assert.AreEqual(expected.Height, actual.Height);

            for (int widthIndex = 0; widthIndex < expected.Columns.Length; widthIndex++)
            {
                CollectionAssert.AreEqual(expected.Columns[widthIndex], actual.Columns[widthIndex]);
            }
        }
    }
}
