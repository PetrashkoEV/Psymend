﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psymend.Infrastructure.Core.Entities.LusherTest;

namespace Psymend.Infrastructure.EntityTypeConfigurations.LusherTest
{
    public class LusherResultEntityTypeConfiguration : IEntityTypeConfiguration<LusherResultEntity>
    {
        public void Configure(EntityTypeBuilder<LusherResultEntity> builder)
        {
            builder.ToTable("lusher_result").HasKey(p => p.LusherResultId);

            builder.HasOne(p => p.LusherTest)
                .WithMany(u => u.LusherResults)
                .HasForeignKey(i => i.LusherTestId);

            builder.HasOne(p => p.LusherInterpretation)
                .WithMany(u => u.LusherResults)
                .HasForeignKey(i => i.LusherInterpretationId);
        }
    }
}