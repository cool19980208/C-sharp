using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksEFCore
{
    public class MyDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options){ }//构造函数，将MyDbContext传到父类DbContext中去
       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(...);之前是在这里面写死数据库了，后续我们尽量数据库配置的代码写到ASP.NET Core项目中，这样可以（连接不同的DB甚至不同类型的DB）
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

    }
}
