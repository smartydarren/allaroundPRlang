using System.Data;
using Microsoft.Data.SqlClient;

namespace webapiLearn.Models.Data
{
  public class DapperContextMssql
  {
    private IConfiguration _configuration;
    private readonly string connectionstring = string.Empty;

    public DapperContextMssql(IConfiguration configuration)
    {
      this._configuration = configuration;
      this.connectionstring = this._configuration.GetConnectionString("BruinDevDb_mssql");
    }

    public IDbConnection CreateConnection() => new SqlConnection(connectionstring);
  }
}
