using System.Data;
using Npgsql;

namespace webapiLearn.Models.Data
{
  public class DapperStraightContextdqdb
  {
    private IConfiguration _configuration;
    private readonly string connectionstring;

    public DapperStraightContextdqdb(IConfiguration configuration)
    {
      this._configuration = configuration;
      this.connectionstring = this._configuration.GetConnectionString("dqdb");
    }

    public IDbConnection CreateConnection() => new NpgsqlConnection(connectionstring);
  }
}
