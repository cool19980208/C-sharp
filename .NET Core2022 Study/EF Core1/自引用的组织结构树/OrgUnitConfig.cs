using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自引用的组织结构树
{
    internal class OrgUnitConfig : IEntityTypeConfiguration<OrgUnit>
    {
        public void Configure(EntityTypeBuilder<OrgUnit> builder)
        {
            builder.ToTable("T_OrgUnits");
            builder.Property(o => o.Name).IsUnicode().IsRequired().HasMaxLength(50);
            //根节点没有Parent，因此这个关系不能修饰为“不可为空”
            builder.HasOne<OrgUnit>(o => o.Parent).WithMany(o => o.Children);
        }
    }
}
