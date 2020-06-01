using System;
using Microsoft.EntityFrameworkCore;
using Psymend.Infrastructure.Core.Configuration;

namespace Psymend.Infrastructure.Core
{
    public abstract class BaseSqlContext : DbContext
    {
        private readonly ISqlConnectionStringProvider _connectionStringProvider;

        public virtual string ConnectionStingConfigurationName { get; set; }

        protected BaseSqlContext(ISqlConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _connectionStringProvider.GetConnectionSting(ConnectionStingConfigurationName);

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Empty connection string. Please add the '{ConnectionStingConfigurationName}' values to the configuration.");
            }

            optionsBuilder.UseMySQL(connectionString);
        }
    }
}