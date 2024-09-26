using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 悲观并发控制
{
    class MyDbContext : DbContext
    {
        public DbSet<House> Houses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //TrustServerCertificate = True 忽略 SSL 证书的验证，只能在测试环境使用
            //MultipleActiveResultSets是一个数据库连接选项，它允许在同一个数据库连接上同时执行多个批处理或存储过程。
            //数据库连接
            optionsBuilder.UseSqlServer("Server=.;Database=Demo6;Trusted_Connection=True;MultipleActiveResultSets=true");
            //optionsBuilder.UseMySql("server=localhost;user=root;password=adfa3_ioz09_08nljo;database=ef",
            // new MySqlServerVersion(new Version(8, 6, 20)));
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //从当前程序集加载所有的IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
