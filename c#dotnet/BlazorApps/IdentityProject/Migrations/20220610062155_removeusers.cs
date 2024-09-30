using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityProject.Migrations
{
    public partial class removeusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Access_Menu_db_Users_CreatedBy",
                table: "Access_Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Master_Product_db_Users_CreatedBy",
                table: "Master_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Master_Product_db_Users_UpdatedBy",
                table: "Master_Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_db_Users",
                table: "db_Users");

            migrationBuilder.RenameTable(
                name: "db_Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Access_Menu_User_CreatedBy",
                table: "Access_Menu",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Master_Product_AspNetUsers_CreatedBy",
                table: "Master_Product",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Master_Product_AspNetUsers_UpdatedBy",
                table: "Master_Product",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Access_Menu_User_CreatedBy",
                table: "Access_Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Master_Product_AspNetUsers_CreatedBy",
                table: "Master_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Master_Product_AspNetUsers_UpdatedBy",
                table: "Master_Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "db_Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_db_Users",
                table: "db_Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Access_Menu_db_Users_CreatedBy",
                table: "Access_Menu",
                column: "CreatedBy",
                principalTable: "db_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Master_Product_db_Users_CreatedBy",
                table: "Master_Product",
                column: "CreatedBy",
                principalTable: "db_Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Master_Product_db_Users_UpdatedBy",
                table: "Master_Product",
                column: "UpdatedBy",
                principalTable: "db_Users",
                principalColumn: "Id");
        }
    }
}
