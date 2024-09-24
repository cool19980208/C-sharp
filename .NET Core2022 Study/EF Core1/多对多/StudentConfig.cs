using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 多对多
{
    internal class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("T_Students");
            builder.Property(s => s.Name).IsUnicode().HasMaxLength(20);
            builder.HasMany<Teacher>(s => s.Teachers).WithMany(t => t.Students).UsingEntity(j => j.ToTable("T_Students_Teachers"));
        }
    }
}
