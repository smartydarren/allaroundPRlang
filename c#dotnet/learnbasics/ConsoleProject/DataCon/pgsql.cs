using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.DataCon
{
    internal class pgsql
    {
        public string connectionString = "Host=localhost; Port=5432; Database=northwind; Username =admin ; Password=admin;";

        public IDbConnection CreateConnection() => new NpgsqlConnection(connectionString);

        public IDbConnection GetMeANewConnection(){
          NpgsqlConnection con = new NpgsqlConnection();

          return con;
        }
    }
}
