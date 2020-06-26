using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;

namespace Psymend.Infrastructure.EntityTypeConfigurations.PsychoBioTest
{
    public class PsychoBioTestEntityTypeConfiguration : IEntityTypeConfiguration<PsychoBioTestEntity>
    {
        public void Configure(EntityTypeBuilder<PsychoBioTestEntity> builder)
        {
            builder.ToTable("psychobio_test").HasKey(p => p.PsychobioTestId);

            builder.HasOne(p => p.PsychoBioResult)
                .WithMany(u => u.PsychobioTests)
                .HasForeignKey(i => i.PsychobioResultId);
        }
    }
}