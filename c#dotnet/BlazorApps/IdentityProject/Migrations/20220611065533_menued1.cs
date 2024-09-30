using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityProject.Migrations
{
    public partial class menued1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ControllerMenu",
                table: "Access_Menu");

            migrationBuilder.DropColumn(
                name: "ListingType",
                table: "Access_Menu");

            migrationBuilder.RenameColumn(
                name: "ParentMenu",
                table: "Access_Menu",
                newName: "ParentMenuId");

            migrationBuilder.RenameColumn(
                name: "Menu",
                table: "Access_Menu",
                newName: "MenuName");

            migrationBuilder.AlterColumn<string>(
                name: "Controller",
                table: "Access_Menu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsForMenu",
                table: "Access_Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsForRole",
                table: "Access_Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsForMenu",
                table: "Access_Menu");

            migrationBuilder.DropColumn(
                name: "IsForRole",
                table: "Access_Menu");

            migrationBuilder.RenameColumn(
                name: "ParentMenuId",
                table: "Access_Menu",
                newName: "ParentMenu");

            migrationBuilder.RenameColumn(
                name: "MenuName",
                table: "Access_Menu",
                newName: "Menu");

            migrationBuilder.AlterColumn<string>(
                name: "Controller",
                table: "Access_Menu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ControllerMenu",
                table: "Access_Menu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListingType",
                table: "Access_Menu",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
