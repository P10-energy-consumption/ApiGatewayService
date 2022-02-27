using System.Data;
using System.Data.SqlClient;

namespace ApiGatewayService.Database.Interfaces
{
    public interface IConnectionFactory
    {
        SqlConnection CreateDBConnection();
    }
}
