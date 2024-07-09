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
        public DapperController(DapperStraightContextdqdb dapperStraightContextdqdb)
        {
            _dapperStraightContextdqdb = dapperStraightContextdqdb;
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
                    ,UserCar_Model.UserCar
                    ,UserCar_Model.UserCar>
                    (sql: queryProductClasses, map: (u, c) =>
                {
                    //if its not true ! means if its false
                    if (!users.Any(x => x.id == u.id))
                    {
                        users.Add(u);                                            
                    }
                    var curUser = users.FirstOrDefault(x => x.id == u.id);
                    if(c != null && !curUser.cars.Any(x => x. id_cars == c.id_cars))
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
