using Microsoft.EntityFrameworkCore;
using System.Data;

namespace webapiLearn.Models.Data
{
    public class DapperDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionstring;

        public DapperDbContext(DbContextOptions<DapperDbContext> options) : base(options)
        {            
        }

        public DbSet<UserCar_Model> user { get; set; }
    }
}
