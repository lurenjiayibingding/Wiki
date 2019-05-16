using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wiki_UnitTest.BLL
{
    public class InsertSort
    {
        /// <summary>
        /// 排序方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        public void Sort<T>(IList<T> input) where T : IComparable
        {
            if (input.Count <= 1)
            {
                return;
            }

            for (int i = 1; i < input.Count; i++)
            {
                if (input[i].CompareTo(input[i - 1]) < 0)
                {
                    var temp = input[i];
                    int j = i - 1;
                    for (; j >= 0 && input[j].CompareTo(temp) > 0; j--)
                    {
                        input[j + 1] = input[j];
                    }
                    input[j + 1] = temp;
                }
            }
        }
    }
}
