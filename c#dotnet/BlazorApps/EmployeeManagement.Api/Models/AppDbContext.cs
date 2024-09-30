using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Employee> VarEmployees { get; set; }
        public DbSet<Departments> VarDepartments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed department table
            modelBuilder.Entity<Departments>().HasKey(c => new { c.departmentID});
            modelBuilder.Entity<Departments>().HasData(new Departments {departmentID=1,departmentName="IT" });
            modelBuilder.Entity<Departments>().HasData(new Departments {departmentID = 2, departmentName = "HR" });

        
            //seed employee table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                employeeID = 1,
                firstName = "Darren",
                lastName = "Quadros",
                emailID = "smartydarren@gmail.com",
                dateOfBirth = new DateTime(1982,9,23),
                gender = Gender.Male,
                DepartmentId = 1,
                photoPath = "images/Boy.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                employeeID = 2,
                firstName = "Aislinn",
                lastName = "Quadros",
                emailID = "aislinn.quadros@gmail.com",
                dateOfBirth = new DateTime(1985, 7, 24),
                gender = Gender.Female,
                DepartmentId = 2,
                photoPath = "images/Girl.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                employeeID = 3,
                firstName = "Denver",
                lastName = "Quadros",
                emailID = "denver.quadros@gmail.com",
                dateOfBirth = new DateTime(1985, 7, 24),
                gender = Gender.Male,
                DepartmentId = 1,
                photoPath = "images/Girl.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                employeeID = 4,
                firstName = "Adelyn",
                lastName = "Quadros",
                emailID = "adelyn.quadros@gmail.com",
                dateOfBirth = new DateTime(1985, 7, 24),
                gender = Gender.Male,
                DepartmentId = 1,
                photoPath = "images/Girl.jpg"
            });


        }
    }
}
