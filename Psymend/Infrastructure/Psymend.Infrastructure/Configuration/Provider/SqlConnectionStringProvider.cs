using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Psymend.Infrastructure.Core.Configuration;

namespace Psymend.Infrastructure.Configuration.Provider
{
    public class SqlConnectionStringProvider : ISqlConnectionStringProvider
    {
        private readonly IConfiguration _configuration;
        private readonly Dictionary<string, string> _connectionStings = new Dictionary<string, string>();

        public SqlConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionSting(string configurationName)
        {
            if (!_connectionStings.TryGetValue(configurationName, out var connectionString))
            {
                connectionString = _configuration.GetConnectionString(configurationName);
                _connectionStings.Add(configurationName, connectionString);
            }

            return connectionString;
        }
    }
}