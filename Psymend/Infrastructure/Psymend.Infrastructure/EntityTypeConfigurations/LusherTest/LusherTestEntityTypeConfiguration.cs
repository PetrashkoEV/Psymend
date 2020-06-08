using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psymend.Infrastructure.Core.Entities.LusherTest;

namespace Psymend.Infrastructure.EntityTypeConfigurations.LusherTest
{
    public class LusherTestEntityTypeConfiguration : IEntityTypeConfiguration<LusherTestEntity>
    {
        public void Configure(EntityTypeBuilder<LusherTestEntity> builder)
        {
            builder.ToTable("lusher_test").HasKey(p => p.LusherTestId);
        }
    }
}