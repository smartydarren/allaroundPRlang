using ConsoleProject.DataCon;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.LinqLearn
{
    internal class linqlearn
    {
        private readonly pgsql _pgdb;

        public linqlearn()
        {
            _pgdb = new pgsql();
        }

        public void printCategories()
        {
            using var conn = new NpgsqlConnection(_pgdb.connectionString);
            conn.OpenAsync();

            Console.WriteLine($"The PostgreSQL version: {conn.PostgreSqlVersion}");
        }

        public  void printCategories1()
        {

            using (var conStr = this._pgdb.CreateConnection())
            {
                var cmd = conStr.CreateCommand().ExecuteNonQuery();                
                
            }

            //    using var dataSource = NpgsqlDataSource.Create(_pgdb.connectionString);

            //using var command = dataSource.CreateCommand("select * from public.categories");
            //using var reader = command.ExecuteReader();

            //while (reader.Read())
            //{
            //    Console.WriteLine(reader.GetString("description"));
            //}
        }

        public void printCategories2()
        {            
            var conn = _pgdb.GetMeANewConnection();

            conn.ConnectionString = _pgdb.connectionString;            
        }
    }
}
