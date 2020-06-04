using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psymend.Infrastructure.Core.Entities.LusherTest;

namespace Psymend.Infrastructure.EntityTypeConfigurations.LusherTest
{
    public class LusherChoiceColorEntityTypeConfiguration : IEntityTypeConfiguration<LusherChoiceColorEntity>
    {
        public void Configure(EntityTypeBuilder<LusherChoiceColorEntity> builder)
        {
            builder.ToTable("lusher_choice_color").HasKey(p => p.LusherChoiceColorId);

            builder.HasOne(p => p.LusherChoice)
                .WithMany(u => u.LusherChoices)
                .HasForeignKey(i => i.LusherChoiceId);

        }
    }
}