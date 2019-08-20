using System;
using System.Collections.Generic;
using System.Linq;

namespace JaggedArray
{
    public class JaggedArraySort
    {
        /// <summary>
        /// Swaps array strings.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        static void Swap(ref int[] left, ref int[] right)
        {
            var temp = left;
            left = right;
            right = temp;
        }

        /// <summary>
        /// Sorts an jagged array.
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <param name="comparer"></param>
        /// <returns>A sorted array.</returns>
        public static int[][] BubbleSort(int[][] jaggedArray, Comparison<int[]> comparer)
        {
            if (ReferenceEquals(jaggedArray, null))
                throw new ArgumentNullException(nameof(jaggedArray));

            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException(nameof(comparer));

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - 1; j++)
                {
                    if (comparer(jaggedArray[j], jaggedArray[j + 1]) < 0)
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                    }
                }
            }
            return jaggedArray;
        }

        public static int[][] Sort(int[][] jaggedArray, IComparer<int[]> comparer) =>
            BubbleSort(jaggedArray, comparer.Compare);
    }

    public class Max : IComparer<int[]>
    {
        /// <summary>
        /// Compares jagged array strings.
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public int Compare(int[] array1, int[] array2)
        {
            if (array1 == null)
                return -1;
            if (array1.Length == 0)
                return -1;

            if (array2 == null)
                return 1;
            if (array2.Length == 0)
                return 1;

            if (array1.Max() > array2.Max())
                return 1;
            if (array1.Max() == array2.Max())
                return 0;

            return -1;
        }
    }

    public class Min : IComparer<int[]>
    {
        /// <summary>
        /// Compares jagged array strings.
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public int Compare(int[] array1, int[] array2)
        {
            if (array1 == null)
                return -1;
            if (array1.Length == 0)
                return -1;

            if (array2 == null)
                return 1;
            if (array2.Length == 0)
                return 1;

            if (array1.Min() < array2.Min())
                return 1;
            if (array1.Min() == array2.Min())
                return 0;

            return -1;
        }
    }

    public class Sum : IComparer<int[]>
    {
        /// <summary>
        /// Compares jagged array strings.
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public int Compare(int[] array1, int[] array2)
        {
            if (array1 == null)
                return -1;
            if (array1.Length == 0)
                return -1;

            if (array2 == null)
                return 1;
            if (array2.Length == 0)
                return 1;

            if (array1.Sum() > array2.Sum())
                return 1;
            if (array1.Sum() == array2.Sum())
                return 0;

            return -1;
        }
    }
}