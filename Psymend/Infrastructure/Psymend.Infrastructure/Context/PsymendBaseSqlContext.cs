using Microsoft.EntityFrameworkCore;
using Psymend.Infrastructure.Core;
using Psymend.Infrastructure.Core.Configuration;
using Psymend.Infrastructure.Core.Entities;
using Psymend.Infrastructure.EntityTypeConfigurations;

namespace Psymend.Infrastructure.Context
{
    public class PsymendBaseSqlContext : BaseSqlContext
    {
        public override string ConnectionStingConfigurationName => "Store";

        public PsymendBaseSqlContext(ISqlConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PasswordEntityTypeConfiguration());
        }

        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<PasswordEntity> Passwords { get; set; }
    }
}