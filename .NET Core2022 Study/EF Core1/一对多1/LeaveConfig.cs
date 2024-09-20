using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace 一对多1
{
    class LeaveConfig : IEntityTypeConfiguration<Leave>
    {
        public void Configure(EntityTypeBuilder<Leave> builder)
        {
            builder.ToTable("T_Leaves");
            //下面两句是单项导航
            builder.HasOne<User>(l => l.Requester).WithMany().IsRequired();
            builder.HasOne<User>(l => l.Approver).WithMany();
        }
    }
}
