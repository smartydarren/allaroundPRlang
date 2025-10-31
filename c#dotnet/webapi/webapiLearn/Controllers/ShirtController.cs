using Dapper;
using Microsoft.AspNetCore.Mvc;
using webapiLearn.Models;
using webapiLearn.Models.Data;

namespace webapiLearn.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ShirtController : ControllerBase
    {
        private readonly DapperDbContext _context;
        private readonly DapperStraightContext _dapperStraightContext;
        public ShirtController(DapperDbContext context, DapperStraightContext dapperStraightContext)
        {
            _context = context;
            _dapperStraightContext = dapperStraightContext;
        }

        //[HttpGet]
        //public string getShirts()
        //{
        //    return "Reading all the shirts";
        //}

        [HttpGet("{iid}/{color}")]
        public string getShirtById(int iid, string color)
        {
            Console.WriteLine("inside the get by iid method");
            return $"Reading shirt no : {iid} with color {color}";
        }

        [HttpGet]
        //[Route("/user")]
        public async Task<ActionResult<IEnumerable<UserCar_Model>>> GetArticles()
        {
            string query = "select * from dbo.user";

            using (var conStr = this._dapperStraightContext.CreateConnection()) {
                var jj = await conStr.QueryAsync<UserCar_Model>(query);
                //var jj = await _context.user.ToListAsync();
                return jj.ToList();
            }
        }

        [HttpGet("enumtest/{foodI}")]        
        public string GetEnum(FoodILike foodI)
        {
            //FoodILike f1 =  Enum.Parse<FoodILike>(foodI);
            return foodI.ToString();
            //return "soups";
        }

        [HttpPost]
        public string createShirt([FromBody]Shirt shirt)
        {
            return $"Creating Shirt with iid no {shirt.ShirtId}";
        }
    }
}
