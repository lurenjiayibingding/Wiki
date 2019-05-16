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
            InsertSort fastSort = new InsertSort();
            fastSort.Sort<int>(input);
            for (int i = 0; i < input.Length; i++)
            {
                Assert.IsTrue(input[i] == i + 1);
            }
        }
    }
}
