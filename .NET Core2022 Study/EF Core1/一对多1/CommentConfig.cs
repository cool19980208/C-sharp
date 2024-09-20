using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace 一对多1
{
    class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("T_Comments");
            builder.Property(a => a.Message).IsUnicode().IsRequired();
            //HasForeignKey(c=>c.ArticleId)  指定这个属性为外键
            builder.HasOne<Article>(c => c.Article).WithMany(a => a.Comments).HasForeignKey(c => c.ArticleId).IsRequired();
        }
    }
}
