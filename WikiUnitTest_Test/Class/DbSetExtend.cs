using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WikiUnitTest_Test.Class
{
    /// <summary>
    /// DbSet扩展方法
    /// </summary>
    public static class DbSetExtend
    {
        /// <summary>
        /// 设置DbSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mockSet"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static Mock<DbSet<T>> SetupArray<T>(this Mock<DbSet<T>> mockSet, params T[] array) where T : class
        {
            var queryable = array.AsQueryable();
            mockSet.As<IAsyncEnumerable<T>>().Setup(m => m.GetEnumerator()).Returns(new MyAsyncEnumerator<T>(queryable.GetEnumerator()));
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(new MyAsyncQueryProvider<T>(queryable.Provider));
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            return mockSet;
        }
    }
}
