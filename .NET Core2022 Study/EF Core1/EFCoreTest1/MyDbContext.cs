using Microsoft.EntityFrameworkCore;

namespace EFCoreTest1
{
    class MyDbContext : DbContext
    {
        public DbSet<Dog> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //TrustServerCertificate = True 忽略 SSL 证书的验证，只能在测试环境使用
            //MultipleActiveResultSets是一个数据库连接选项，它允许在同一个数据库连接上同时执行多个批处理或存储过程。
            //数据库连接
            optionsBuilder.UseSqlServer("Server=.;Database=Test;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //从当前程序集加载所有的IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
