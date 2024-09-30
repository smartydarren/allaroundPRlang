using IdentityProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityProject.Data
{
    //public class ApplicationDbContext :IdentityDbContext<ApplicationUser,Access_ApplicationRole,int>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,Access_ApplicationRole,int,IdentityUserClaim<int>?
        ,Access_ApplicationUserRoles,IdentityUserLogin<int>?,
        IdentityRoleClaim<int>?, IdentityUserToken<int>?>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Master_Product> db_Product { get; set; }
        public DbSet<Access_Menu> db_Menu { get; set; }
        public DbSet<Access_RoleMenuMap> db_RoleMenuMap { get; set; }
        public DbSet<Access_RoleMenuMap_Audit> db_RoleMenuMap_Audit { get; set; }
        public DbSet<Access_MenuContrlrActionMap> db_MenuCtrActionMap { get; set; }
        public DbSet<Access_UserRolesMap_Audit> db_UserRoleMap_Audit { get; set; }
        
        //Identity Tables
        public DbSet<ApplicationUser> db_UsersIdentity { get; set; }
        public DbSet<Access_ApplicationRole> db_RolesIdentity { get; set; }
        public DbSet<Access_ApplicationUserRoles> db_UserRolesIdentity { get; set; }


        /*
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.Entity<IdentityUserLogin<int>>()
            .HasKey(x => x.LoginProvider);


        modelBuilder.Entity<IdentityUserRole<int>>()
            .HasKey(x => x.UserId);


        modelBuilder.Entity<Access_UserRolesMap_Audit>()
            .HasNoKey();

        modelBuilder.Entity<Access_ApplicationUserRoles>()
            .HasNoKey();

        modelBuilder.Entity<IdentityUserToken<int>>()
            .HasNoKey();
        
    }*/

    }
}
