using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VarDepartments",
                columns: table => new
                {
                    departmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarDepartments", x => x.departmentID);
                });

            migrationBuilder.CreateTable(
                name: "VarEmployees",
                columns: table => new
                {
                    employeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    photoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarEmployees", x => x.employeeID);
                });

            migrationBuilder.InsertData(
                table: "VarDepartments",
                columns: new[] { "departmentID", "departmentName" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" }
                });

            migrationBuilder.InsertData(
                table: "VarEmployees",
                columns: new[] { "employeeID", "DepartmentId", "dateOfBirth", "emailID", "firstName", "gender", "lastName", "photoPath" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1982, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "smartydarren@gmail.com", "Darren", 0, "Quadros", "images/Boy.jpg" },
                    { 2, 2, new DateTime(1985, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "aislinn.quadros@gmail.com", "Aislinn", 1, "Quadros", "images/Girl.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VarDepartments");

            migrationBuilder.DropTable(
                name: "VarEmployees");
        }
    }
}
