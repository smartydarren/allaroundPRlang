using ConsoleAppLearning.LearnConcepts.data;
using Microsoft.EntityFrameworkCore;
using ConsoleProject.Models;

namespace ConsoleAppLearning.LearnConcepts.Data
{
    internal class AppDataContext : DbContext
    {
        public DbSet<Users> db_Users { get; set; }
        public DbSet<Master_Product> db_Products { get; set; }        
        public DbSet<Access_Menu> db_Menu { get; set; }
        public DbSet<Access_RoleMenuMap> db_RoleMenuMap { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\darrensql;database=identitydb;Trusted_Connection=true");
        }
    }
}
