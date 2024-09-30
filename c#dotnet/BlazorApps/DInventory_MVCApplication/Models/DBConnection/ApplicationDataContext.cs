using DInventory_Models;
using Microsoft.EntityFrameworkCore;

namespace DInventory_MVCApplication.Models
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
            
        }
        public virtual DbSet<BusParents> busParents { get; set; }
        public virtual DbSet<BusChildren> busChildren { get; set; }
    }
}
