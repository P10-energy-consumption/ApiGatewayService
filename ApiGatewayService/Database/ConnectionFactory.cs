using ApiGatewayService.Database.Interfaces;
using System.Data.SqlClient;

namespace ApiGatewayService.Database
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private readonly Lazy<string> _connectionString;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = new Lazy<string>(() => _configuration.GetValue<string>("postgres"));
        }

        public SqlConnection CreateDBConnection()
        {
            return new SqlConnection(_connectionString.Value);
        }
    }
}
