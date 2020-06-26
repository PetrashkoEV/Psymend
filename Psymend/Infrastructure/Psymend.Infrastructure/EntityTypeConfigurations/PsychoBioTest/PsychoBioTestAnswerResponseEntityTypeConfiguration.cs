using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;

namespace Psymend.Infrastructure.EntityTypeConfigurations.PsychoBioTest
{
    public class PsychoBioTestAnswerResponseEntityTypeConfiguration : IEntityTypeConfiguration<PsychoBioTestAnswerResponseEntity>
    {
        public void Configure(EntityTypeBuilder<PsychoBioTestAnswerResponseEntity> builder)
        {
            builder.ToTable("psychobio_answer_response").HasKey(p => p.PsychoBioTestAnswerResponseId);

            builder.HasOne(p => p.PsychoBioTest)
                .WithMany(u => u.AnswerResponses)
                .HasForeignKey(i => i.PsychoBioTestId);

            builder.HasOne(p => p.PsychoBioTestAnswerDefinition)
                .WithMany(u => u.AnswerResponses)
                .HasForeignKey(i => i.PsychoBioTestAnswerDefinitionId);

        }
    }
}