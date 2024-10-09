using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksEFCore
{
    internal class MyDesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        //开发时(Add-Migration 、Update-Database等)运行，项目运行的时候不会有这个类的事情
        public MyDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();
            //string connStr = Environment.GetEnvironmentVariable("ConnStr");
            //如果不在乎连接字符串被上传到Git，就可以把连接字符串直接写死到CreateDbContext；
            //如果在乎，那么CreateDbContext里面很难读取到VS中通过简单的方法设置的环境变量，
            //所以必须把连接字符串配置到Windows的正式的环境变量中，然后再 Environment.GetEnvironmentVariable读取。

            string connStr = "Data Source=.;Initial Catalog=demo666;Integrated Security=SSPI;";
            builder.UseSqlServer(connStr);
            MyDbContext ctx = new MyDbContext(builder.Options);
            return ctx;
            //return new MyDbContext(builder.Options);
        }
    }
}
