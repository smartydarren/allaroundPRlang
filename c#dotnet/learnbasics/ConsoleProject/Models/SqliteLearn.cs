using System.Data;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace ConsoleProject.Models
{
  public class SqliteLearn
  {
    private readonly static string filename = @"C:\Users\dquadros\OneDrive\Office\LEARNING\mycodepath\allaroundPRlang\c#dotnet\learnbasics\ConsoleProject\Dbs\test.db";
    private readonly IDbConnection _Connect = new SQLiteConnection($"Data Source={filename};Version=3;");


    public async Task StepsInLine()
    {

      DeleteSqliteDb().Wait();
      using (_Connect)
      {
        _Connect.Open();
        Console.WriteLine("State: {0}", _Connect.State);
        await CreateSqliteTable(_Connect);
        await CreateSqlRecord(_Connect);
        await CreateDapperRecord(_Connect);
        Console.WriteLine("State: {0}", _Connect.State);
      }

    }

    public async Task DeleteSqliteDb()
    {
      FileInfo testDbFile = new FileInfo(filename);

      if (testDbFile.Exists)
      {
        testDbFile.Delete();
        Task.Delay(5000).Wait();
      }

      await using (FileStream fs = new FileStream(filename, FileMode.Create))
      {
        Console.WriteLine("File created");
      }

      Task.Delay(1000).Wait();

    }

    protected internal async Task CreateSqliteTable(IDbConnection conn)
    {

      SQLiteCommand cmd = (SQLiteCommand)conn.CreateCommand();
      cmd.CommandText = """
        create table IF NOT EXISTS test 
        (id integer primary key,
        name varchar(20)
        )
        """;
      var res = await cmd.ExecuteNonQueryAsync();
      Console.WriteLine("SqlLite Table created with Id : {0} ", res);
      Console.WriteLine("State: {0}", conn.State);
    }

    internal async Task CreateSqlRecord(IDbConnection conn)
    {
      Console.WriteLine("State: {0}", conn.State);
      var cmd = (SQLiteCommand)conn.CreateCommand();
      cmd.CommandText = "insert into test (name) values ('Darren') RETURNING id;";
      var res = await cmd.ExecuteNonQueryAsync();
      Console.WriteLine("SqlLite record inserted with Id : {0} ", res);
    }
    internal async Task CreateDapperRecord(IDbConnection conn)
    {
      var res = await conn.ExecuteAsync(
         """
        insert into test (name) values (@name)
        RETURNING id;
        """, new { name = "Aislinn" }
        );
      Console.WriteLine("Dapper record inserted with Id : {0}", res);

    }

  }
}