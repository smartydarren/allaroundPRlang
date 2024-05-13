using Dapper;
using Microsoft.AspNetCore.Mvc;
using webapiLearn.Models;
using webapiLearn.Models.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace webapiLearn.Controllers
{

    [Route("api/bss/productCatalog")]
    public class BssController : ControllerBase
    {
        private readonly DapperStraightContext _dapperStraightContext;
        private readonly DapperStraightContextdqdb _dapperStraightContextdqdb;

        public BssController(DapperDbContext context, DapperStraightContext dapperStraightContext, DapperStraightContextdqdb dapperStraightContextdqdb)
        {            
            _dapperStraightContext = dapperStraightContext;
            _dapperStraightContextdqdb = dapperStraightContextdqdb;
        }

        [HttpGet]
        [Route("carrier")]
        public async Task<List<Carrier>> GetListOfCarriers()
        {
            string query = @"
                            SELECT ""CarrierCode"",
                                   ""Name"",                                
                                   ""Id"" as ""BSSNetworkId""                                 
                            FROM dbo.""Networks""                                                        
                            ";


            using (var conStr = this._dapperStraightContext.CreateConnection())
            {
                var jj = await conStr.QueryAsync<Carrier>(query);
                //var jj = await _context.user.ToListAsync();
                return jj.ToList();
            }

        //https://localhost:7163/api/bss/productCatalog/carrier
        }

        [HttpGet]
        [Route("networks/{isActive}")]
        public async Task<OSNetworksGetResponse> GetNetworks(int isActive)
        {
            bool isActv = (isActive == 0 ? false : true);
            string isActvb = "";
            if (isActive == 0)
            {
                isActvb = "where n.\"IsActive\"=false";
            }
            else if (isActive < 0)
            {
                isActvb = "";
            }
            else
            {
                isActvb = "where n.\"IsActive\"=true";
            }

            string queryNetwork = @"
SELECT 
n.""Id"",
n.""Name"" 
,n.""Description""
,n.""LogoId""
,Logos.""Name"" as ""LogoName""
,Images.""ImageURL"" as ""LogoUrl""
,n.""IsActive""
from ""ProductCatalog"".dbo.""Networks"" n
left outer join ""ProductCatalog"".dbo.""Logos"" Logos on n.""LogoId"" = Logos.""Id"" 
left outer join ""ProductCatalog"".dbo.""Images"" Images on Images.""Id"" = Logos.""ImageId""
" + isActvb;

            string queryLogos = @"
SELECT 
logos.""Id""
,logos.""Name"" 
,logos.""ImageId""
,Images.""ImageURL"" as ""LogoUrl""
from ""ProductCatalog"".dbo.""Logos"" Logos
left outer join ""ProductCatalog"".dbo.""Images"" Images on Images.""Id"" = Logos.""ImageId""
";
            var os = new OSNetworksGetResponse();
            using (var conStr = this._dapperStraightContext.CreateConnection())
            {
                var res = await conStr.QueryAsync<OSNetworksGetResponse.NetworkItem>(queryNetwork, new {isActv});
                var res1 = await conStr.QueryAsync<OSNetworksGetResponse.LogoItem> (queryLogos);
                //var jj = await _context.user.ToListAsync();
                foreach (var networkItem in res)
                {
                    os.Networks.Add(networkItem);
                }

                foreach (var logos in res1)
                {
                    os.Logos.Add(logos);
                }
                return os;
            }

            //https://localhost:7163/api/bss/productCatalog/networks
        }

        [HttpGet]
        [Route("productClasses")]
        public async Task<ProductClassesResponseModel> GetProductClasses()
        {
            string query = @"
select 
""Id"" 
,""Name"" 
,""Description"" 
,""GLAccountNumber"" 
,""IsActive"" 
,""CreatedAt"" 
,""CreatedBy"" 
,""ModifiedAt"" 
,""ModifiedBy"" 
from ""ProductCatalog"".dbo.""ProductClasses"" pc
";

            using (var conStr = this._dapperStraightContext.CreateConnection())
            {
                var response = await conStr.QueryAsync<ProductClass>(query);

                return new ProductClassesResponseModel { ProductClasses = response.ToList() };
            }

            //https://localhost:7163/api/bss/productCatalog/productclasses
        }

        [HttpGet]
        [Route("productClasses/usercar")]
        public async Task<List<User>> GetCarsByUser()
        {
            string queryProductClasses = @"
select u.id,u.""name"",c.userid ,c.brand, c.model from dqdb.dbo.""user"" u 
inner join dqdb.dbo.cars c on u.id = c.userID
order by u.id asc, c.model asc;
";
            List<User> users = new List<User>();
            using (var conStr = this._dapperStraightContextdqdb.CreateConnection())
            {
                var response = await conStr.QueryAsync<User, Car, User>(sql:queryProductClasses,map:(u, c) =>
                {
                    if(!users.Any(x => x.id == c.userId)){
                        u.cars.Add(c);
                        users.Add(u);
                    }
                    else
                    {
                        users.Single(x => x.id == c.userId).cars.Add(c);
                    }
                    return null;
                    
                },splitOn:"userid");

                return users;
            }

            //https://localhost:7163/api/bss/productCatalog/productclasses/usercar
        }

    }
}
