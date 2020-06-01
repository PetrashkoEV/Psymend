namespace Psymend.Infrastructure.Core.Configuration
{
    public interface ISqlConnectionStringProvider
    {
        string GetConnectionSting(string configurationName);
    }
}