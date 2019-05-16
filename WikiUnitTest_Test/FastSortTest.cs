using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Wiki_UnitTest.BLL;

namespace WikiUnitTest_Test
{
    [TestClass]
    public class FastSortTest
    {
        [TestMethod]
        public void FastSortTest1()
        {
            int[] input = new int[] { 5, 4, 10, 9, 8, 3, 2, 7, 6, 1 };
            FastSort fastSort = new FastSort();
            fastSort.Sort<int>(input, 0, input.Length - 1);
            for (int i = 0; i < input.Length; i++)
            {
                Assert.IsTrue(input[i] == i + 1);
            }
        }

        [TestMethod]
        public void FastSortTest2()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            FastSort fastSort = new FastSort();
            fastSort.Sort<int>(input, 0, input.Length - 1);
            for (int i = 0; i < input.Length; i++)
            {
                Assert.IsTrue(input[i] == i + 1);
            }
        }

        [TestMethod]
        public void FastSortTest3()
        {
            int[] input = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            FastSort fastSort = new FastSort();
            fastSort.Sort<int>(input, 0, input.Length - 1);
            for (int i = 0; i < input.Length; i++)
            {
                Assert.IsTrue(input[i] == i + 1);
            }
        }
    }
}
