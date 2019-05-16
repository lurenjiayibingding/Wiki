using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wiki_UnitTest.BLL
{
    public class FastSort
    {
        /// <summary>
        /// 快速排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="low"></param>
        /// <param name="height"></param>
        public void Sort<T>(IList<T> input, int low, int height) where T : IComparable
        {
            if (low >= height || height < 0 || low < 0)
                return;

            if (height - low == 1)
            {
                if (input[low].CompareTo(input[height]) >= 0)
                {
                    Exchange(input, low, height);
                }
                return;
            }

            int i = low;
            int j = height;
            T median = input[low];

            while (i < j)
            {
                while (i < j && input[j].CompareTo(median) > 0)
                {
                    j--;
                }
                while (i < j && input[i].CompareTo(median) <= 0)
                {
                    i++;
                }

                if (i < j)
                {
                    Exchange(input, i, j);
                }
            }
            Exchange(input, low, j);
            Sort(input, low, j - 1);
            Sort(input, j + 1, height);
        }

        /// <summary>
        /// 交换两个元素的位置
        /// </summary>
        /// <param name="input"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void Exchange<T>(IList<T> input, int i, int j)
        {
            if (i == j)
                return;
            T temp = input[i];
            input[i] = input[j];
            input[j] = temp;
        }
    }
}
