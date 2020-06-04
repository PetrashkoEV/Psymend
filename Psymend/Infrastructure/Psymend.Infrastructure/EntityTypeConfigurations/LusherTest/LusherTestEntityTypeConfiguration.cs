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

            builder.HasOne(p => p.User)
                .WithMany(u => u.LusherTests)
                .HasForeignKey(i => i.UserId);
        }
    }
}