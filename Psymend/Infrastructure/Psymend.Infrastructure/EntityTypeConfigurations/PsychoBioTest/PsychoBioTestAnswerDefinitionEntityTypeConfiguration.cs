using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;

namespace Psymend.Infrastructure.EntityTypeConfigurations.PsychoBioTest
{
    public class PsychoBioTestAnswerDefinitionEntityTypeConfiguration : IEntityTypeConfiguration<PsychoBioTestAnswerDefinitionEntity>
    {
        public void Configure(EntityTypeBuilder<PsychoBioTestAnswerDefinitionEntity> builder)
        {
            builder.ToTable("psychobio_answer_definition").HasKey(p => p.PsychoBioTestAnswerDefinitionId);

            builder.HasOne(p => p.Question)
                .WithMany(u => u.AnswerDefinitions)
                .HasForeignKey(i => i.PsychoBioQuestionId);

        }
    }
}