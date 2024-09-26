using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 乐观并发控制
{
    class HouseEntityConfig : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.ToTable("T_Houses");
            builder.Property(h => h.Name).IsUnicode();
            //builder.Property(h => h.Owner).IsConcurrencyToken();//乐观并发的令牌
            builder.Property(h => h.RowVer).IsRowVersion();//乐观并发的令牌
        }
    }
}
