using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psymend.Infrastructure.Core.Entities.LusherTest;

namespace Psymend.Infrastructure.EntityTypeConfigurations.LusherTest
{
    public class LusherChoiceEntityTypeConfiguration : IEntityTypeConfiguration<LusherChoiceEntity>
    {
        public void Configure(EntityTypeBuilder<LusherChoiceEntity> builder)
        {
            builder.ToTable("lusher_choice").HasKey(p => p.LusherChoiceId);

            builder.HasOne(p => p.LusherTest)
                .WithMany(u => u.LusherChoices)
                .HasForeignKey(i => i.LusherTestId);
        }
    }
}