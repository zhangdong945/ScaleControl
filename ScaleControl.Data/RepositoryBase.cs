using System;
using System.Data;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data
{
    /// <summary>
    /// Base class for all repository classes, providing common connection handling
    /// and parameter creation helpers.
    /// </summary>
    public abstract class RepositoryBase
    {
        protected readonly IDatabaseConnectionFactory ConnectionFactory;

        protected RepositoryBase(IDatabaseConnectionFactory connectionFactory)
        {
            ConnectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        protected IDbConnection CreateConnection()
        {
            return ConnectionFactory.CreateConnection();
        }

        protected void AddParameter(IDbCommand cmd, string name, object value)
        {
            var parameter = cmd.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value ?? DBNull.Value;
            cmd.Parameters.Add(parameter);
        }
    }
}
