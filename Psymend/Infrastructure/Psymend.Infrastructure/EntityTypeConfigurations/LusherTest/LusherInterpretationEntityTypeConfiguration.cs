using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psymend.Infrastructure.Core.Entities.LusherTest;

namespace Psymend.Infrastructure.EntityTypeConfigurations.LusherTest
{
    public class LusherInterpretationEntityTypeConfiguration : IEntityTypeConfiguration<LusherInterpretationEntity>
    {
        public void Configure(EntityTypeBuilder<LusherInterpretationEntity> builder)
        {
            builder.ToTable("lusher_interpretation").HasKey(p => p.LusherInterpretationId);
        }
    }
}