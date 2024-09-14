using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreTest1
{
    class DogConfig
    {
        public void Configure(EntityTypeBuilder<Dog> builder)
        {
            //Kingdee的格式:T_   S
            builder.ToTable("T_Dogs");
        }
    }
}
