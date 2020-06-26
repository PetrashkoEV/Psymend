using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psymend.Infrastructure.Core.Entities;

namespace Psymend.Infrastructure.EntityTypeConfigurations
{
    public class TestEntityTypeConfiguration : IEntityTypeConfiguration<TestEntity>
    {
        public void Configure(EntityTypeBuilder<TestEntity> builder)
        {
            builder.ToTable("test").HasKey(p => p.TestId);

            builder.HasOne(p => p.User)
                .WithMany(u => u.Tests)
                .HasForeignKey(i => i.UserId);

            builder.HasOne(p => p.LusherTest)
                .WithMany(u => u.Tests)
                .HasForeignKey(i => i.LusherTestId);
            
            builder.HasOne(p => p.PsychoBioTest)
                .WithMany(u => u.Tests)
                .HasForeignKey(i => i.PsychobioTestId);
        }
    }
}