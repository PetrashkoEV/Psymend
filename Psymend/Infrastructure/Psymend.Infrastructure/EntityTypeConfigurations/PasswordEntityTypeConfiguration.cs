using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psymend.Infrastructure.Core.Entities;

namespace Psymend.Infrastructure.EntityTypeConfigurations
{
    public class PasswordEntityTypeConfiguration : IEntityTypeConfiguration<PasswordEntity>
    {
        public void Configure(EntityTypeBuilder<PasswordEntity> builder)
        {
            builder.ToTable("password").HasKey(p => p.PasswordId);

            builder.HasOne(p => p.User)
                .WithMany(u => u.Passwords)
                .HasForeignKey(i => i.UserId);
        }
    }
}