using System.Data;
using Npgsql;

namespace webapiLearn.Models.Data
{
    public class DapperStraightContext
    {
        private IConfiguration _configuration;
        private readonly string connectionstring;

        public DapperStraightContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.connectionstring = this._configuration.GetConnectionString("bss_pg");            
        }

        public IDbConnection CreateConnection() => new NpgsqlConnection(connectionstring);
    }
}
