using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wiki_UnitTest.Mold.DBModel;

namespace Wiki_UnitTest.Common
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class MariaDbContext : DbContext
    {
        private string dbConnection;

        public MariaDbContext(DbContextOptions options) : base(options)
        {

        }

        public MariaDbContext(string connection)
        {
            dbConnection = connection;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WUserInfoModel>().ToTable("WUserInfo");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(dbConnection);

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<WUserInfoModel> UserInfoModels { get; set; }
    }
}
