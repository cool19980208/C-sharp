﻿using Microsoft.EntityFrameworkCore;
using System;

namespace 一对多1
{
    class MyDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Leave> Leaves { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //TrustServerCertificate = True 忽略 SSL 证书的验证，只能在测试环境使用
            //MultipleActiveResultSets是一个数据库连接选项，它允许在同一个数据库连接上同时执行多个批处理或存储过程。
            //数据库连接
            optionsBuilder.UseSqlServer("Server=.;Database=Demo1;Trusted_Connection=True;MultipleActiveResultSets=true");
            optionsBuilder.LogTo(Console.WriteLine);//简单日志
            optionsBuilder.UseBatchEF_MSSQL();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //从当前程序集加载所有的IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
