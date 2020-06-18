using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;

namespace Psymend.Infrastructure.EntityTypeConfigurations.PsychoBioTest
{
    public class PsychoBioTestQuestionEntityTypeConfiguration : IEntityTypeConfiguration<PsychoBioTestQuestionEntity>
    {
        public void Configure(EntityTypeBuilder<PsychoBioTestQuestionEntity> builder)
        {
            builder.ToTable("psychobio_question").HasKey(p => p.PsychoBioQuestionId);

        }
    }
}