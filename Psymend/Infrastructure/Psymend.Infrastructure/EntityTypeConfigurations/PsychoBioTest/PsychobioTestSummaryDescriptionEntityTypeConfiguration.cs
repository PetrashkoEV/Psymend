using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;

namespace Psymend.Infrastructure.EntityTypeConfigurations.PsychoBioTest
{
    public class PsychobioTestSummaryDescriptionEntityTypeConfiguration : IEntityTypeConfiguration<PsychobioTestSummaryDescriptionEntity>
    {
        public void Configure(EntityTypeBuilder<PsychobioTestSummaryDescriptionEntity> builder)
        {
            builder.ToTable("psychobio_test_summary_description").HasKey(p => p.PsychobioTestSummaryDescriptionId);
        }
    }
}