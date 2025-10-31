using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityProject.Migrations
{
    public partial class keytoAudittable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Access_UserRolesMap_Audit",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Access_UserRolesMap_Audit",
                table: "Access_UserRolesMap_Audit",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Access_UserRolesMap_Audit",
                table: "Access_UserRolesMap_Audit");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Access_UserRolesMap_Audit");
        }
    }
}
