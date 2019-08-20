using JaggedArray;
using NUnit.Framework;

namespace JaggedArrayTests
{
    public class JaggedArraySortTests
    {
        [Test]
        public void BubbleSortMaxTest()
        {
            int[][] jaggedArray =
            {
                new int[] { 9, 39, 8, 8, 9 },
                new int[] { 6, 221, 1 },
                new int[] { 0, 0, 0 }
            };

            int[][] result =
            {
                new int[] { 6, 221, 1 },
                new int[] { 9, 39, 8, 8, 9 },
                new int[] { 0, 0, 0 }
            };

            Assert.AreEqual(JaggedArraySort.Sort(jaggedArray, new Max()), result);
        }

        [Test]
        public void BubbleSortMinTest()
        {
            int[][] jaggedArray =
            {
                new int[] { 9, 39, 8, 8, 9 },
                new int[] { 6, 221, 1 },
                new int[] { 0, 0, 0 }
            };

            int[][] result =
            {
                new int[] { 0, 0, 0 },
                new int[] { 6, 221, 1 },
                new int[] { 9, 39, 8, 8, 9 }
            };

            Assert.AreEqual(JaggedArraySort.Sort(jaggedArray, new Min()), result);
        }

        [Test]
        public void BubbleSortSumTest()
        {
            int[][] jaggedArray =
            {
                new int[] { 6, 221, 1 },
                new int[] { 9, 39, 8, 8, 9 },
                new int[] { 0, 0, 0 }
            };

            int[][] result =
            {
                new int[] { 6, 221, 1 },
                new int[] { 9, 39, 8, 8, 9 },
                new int[] { 0, 0, 0 }
            };

            Assert.AreEqual(JaggedArraySort.Sort(jaggedArray, new Sum()), result);
        }
    }
}