using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Api.Migrations
{
    public partial class addingAdelyn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VarEmployees",
                columns: new[] { "employeeID", "DepartmentId", "dateOfBirth", "emailID", "firstName", "gender", "lastName", "photoPath" },
                values: new object[] { 4, 1, new DateTime(1985, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "adelyn.quadros@gmail.com", "Adelyn", 0, "Quadros", "images/Girl.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VarEmployees",
                keyColumn: "employeeID",
                keyValue: 4);
        }
    }
}
