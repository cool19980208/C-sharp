using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

#nullable disable

namespace NewTest
{
    public partial class TestCoolContext : DbContext
    {
        //public static ILoggerFactory loggerFactory = LoggerFactory.Create(b => b.AddConsole());//日志
        public TestCoolContext()
        {
        }

        public TestCoolContext(DbContextOptions<TestCoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TDog> TDogs { get; set; }
        public virtual DbSet<TPerson> TPersons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=TestCool;Trusted_Connection=True;MultipleActiveResultSets=true");
                //optionsBuilder.UseLoggerFactory(loggerFactory);//日志
                /*optionsBuilder.LogTo(msg => {
                    if (!msg.Contains("CommandExecuting"))return;
                    Console.WriteLine(msg); });//简单日志*/
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_PRC_CI_AS");

            modelBuilder.Entity<TDog>(entity =>
            {
                entity.ToTable("T_Dogs");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TPerson>(entity =>
            {
                entity.ToTable("T_Persons");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
