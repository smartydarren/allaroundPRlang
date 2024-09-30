using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeMVCApp.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AddressEmp_AddressID",
                schema: "Employee",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "AddressID",
                schema: "Employee",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AddressEmp_AddressID",
                schema: "Employee",
                table: "Employee",
                column: "AddressID",
                principalSchema: "Employee",
                principalTable: "AddressEmp",
                principalColumn: "AddressID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AddressEmp_AddressID",
                schema: "Employee",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "AddressID",
                schema: "Employee",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AddressEmp_AddressID",
                schema: "Employee",
                table: "Employee",
                column: "AddressID",
                principalSchema: "Employee",
                principalTable: "AddressEmp",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
