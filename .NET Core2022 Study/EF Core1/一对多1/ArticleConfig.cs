using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;


namespace 一对多1
{
    class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("T_Articles");
            builder.HasMany<Comment>(a => a.Comments).WithOne(c => c.Article).HasForeignKey(c => c.ArticleId).IsRequired();//一对多
            builder.HasQueryFilter(b => b.IsDeleted == false);//全局软删除筛选器
        }
    }
}
