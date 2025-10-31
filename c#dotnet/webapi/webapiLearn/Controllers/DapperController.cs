using System.Dynamic;
using System.Text.Json;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using webapiLearn.Models;
using webapiLearn.Models.Data;

namespace webapiLearn.Controllers
{
  [ApiController]
  [Route("api/[Controller]")]
  public class DapperController : ControllerBase
  {
    private readonly DapperStraightContextdqdb _dapperStraightContextdqdb;
    private readonly DapperContextMssql _dappermssqlContext;
    public DapperController(DapperStraightContextdqdb dapperStraightContextdqdb, DapperContextMssql dapperContextMssql)
    {
      _dapperStraightContextdqdb = dapperStraightContextdqdb;
      _dappermssqlContext = dapperContextMssql;
    }

    [HttpGet]
    [Route("tryme", Name = "http://localhost:5261/api/dapper/tryme")]
    public string TryMe()
    {
      return "you have reached the DapperController";
    }

    [HttpGet]
    [Route("version")]
    public IActionResult GetVersion()
    {
      //string connectionStr = $"ConnectionString: {_dappermssqlContext.CreateConnection().ConnectionString}";

      string query = @" SELECT @@version AS version ";
      using (var con = _dappermssqlContext.CreateConnection())
      {        
        var jj = con.QuerySingle(query);               

        Console.WriteLine($"JJ is: {jj.version}");        
        return Ok(new {MSSQLVersion = jj.version});
        }              

    }

    [HttpGet]
    [Route("vendor")]
    public async Task<List<Vendor>> GetVendor()
    {
      string query = @" select top 10 * from dbo.Vendor ";
      using (var con = _dappermssqlContext.CreateConnection())
      {
        var vendors = await con.QueryAsync<Vendor>(query);

        return vendors.ToList();
      }
    }

    [HttpGet]
    [Route("configs")]
    public async Task<List<DownloaderConfig>> GetConfig()
    {
      string query = @" select
dc.id,dc.Name,dc.WebURL,dc.SiteAgent
,acf.DownloaderConfigId, acf.Config
,xm.Id,xm.ConfigFileId,xm.XPath, xm.[Action]
--,xmh.ConfigFileId ,xmh.WebPageHtml
from dbo.DownloaderConfigs dc 
inner JOIN dbo.AutomationConfigFiles acf with (nolock) on acf.DownloaderConfigId = dc.Id
inner join dbo.XPathMaps xm with(nolock) on acf.Id = xm.ConfigFileId
--inner join dbo.XPathMapsHtml xmh with(nolock) on xm.ConfigFileId = xmh.ConfigFileId
--where dc.SiteAgent = 'uc_adt_security_services' 
order by xm.XPath asc
";
      using (var con = _dappermssqlContext.CreateConnection())
      {
        List<DownloaderConfig> allConfigs = new List<DownloaderConfig>();

        var configs = await con.QueryAsync<DownloaderConfig, AutomationConfigFile, XPathMaps, DownloaderConfig>(query,
        (dc, ac, xp) =>
        {
          if (!allConfigs.Any(x => x.Id == dc.Id))
          {
            dc.automationConfigFile = ac;
            ac.xPathMaps.Add(xp);
            allConfigs.Add(dc);
          }
          else
          {
            allConfigs.Single(x => x.Id == dc.Id && x.automationConfigFile.DownloaderConfigId == ac.DownloaderConfigId).automationConfigFile.xPathMaps.Add(xp);
          }
          return null;
        },
          splitOn: "DownloaderConfigId, Id");
        return allConfigs;
      }
            
    }

    [HttpGet]
    [Route("usercar")]
    public async Task<List<UserCar_Model.User>> GetCarsByUser()
    {
      string queryProductClasses = @"
select u.id,u.name
,c.id_cars, c.userid ,c.brand, c.model from dqdb.dbo.user u 
left outer join dqdb.dbo.cars c on u.id = c.userID
order by u.id asc, c.model asc;
";
      List<UserCar_Model.User> users = new List<UserCar_Model.User>();
      using (var conStr = this._dapperStraightContextdqdb.CreateConnection())
      {
        var response = await conStr.QueryAsync<UserCar_Model.User
            , UserCar_Model.UserCar
            , UserCar_Model.UserCar>
            (sql: queryProductClasses, map: (u, c) =>
        {
          //if its not true ! means if its false
          if (!users.Any(x => x.id == u.id))
          {
            users.Add(u);
          }
          var curUser = users.FirstOrDefault(x => x.id == u.id);
          if (c != null && !curUser.cars.Any(x => x.id_cars == c.id_cars))
          {
            curUser.cars.Add(c);
          }

          return null;

        }, splitOn: "id_cars");

        return users;
      }

      //https://localhost:7163/api/bss/productCatalog/dapper/usercar
    }

  }
}
