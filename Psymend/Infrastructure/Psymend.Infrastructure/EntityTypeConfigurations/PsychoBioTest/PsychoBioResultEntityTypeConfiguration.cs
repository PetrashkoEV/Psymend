using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;

namespace Psymend.Infrastructure.EntityTypeConfigurations.PsychoBioTest
{
    public class PsychoBioResultEntityTypeConfiguration : IEntityTypeConfiguration<PsychoBioTestResultEntity>
    {
        public void Configure(EntityTypeBuilder<PsychoBioTestResultEntity> builder)
        {
            builder.ToTable("psychobio_result").HasKey(p => p.PsychobioResultId);

            builder.HasOne(p => p.Disadaptation)
                .WithMany(u => u.DisadaptationResults)
                .HasForeignKey(i => i.DisadaptationId);

            builder.HasOne(p => p.Anxiety)
                .WithMany(u => u.AnxietyResults)
                .HasForeignKey(i => i.AnxietyId);

            builder.HasOne(p => p.Frustration)
                .WithMany(u => u.FrustrationResults)
                .HasForeignKey(i => i.FrustrationId);

            builder.HasOne(p => p.GeneralCondition)
                .WithMany(u => u.GeneralConditionResults)
                .HasForeignKey(i => i.GeneralConditionId);
        }
    }
}