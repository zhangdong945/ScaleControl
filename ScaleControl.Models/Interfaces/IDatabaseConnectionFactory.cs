using System.Data;

namespace ScaleControl.Models.Interfaces
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection CreateConnection();
        string ProviderName { get; }
    }
}
