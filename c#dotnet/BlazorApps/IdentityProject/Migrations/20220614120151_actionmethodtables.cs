using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityProject.Migrations
{
    public partial class actionmethodtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowCreate",
                table: "Access_RoleMenuMap",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowDelete",
                table: "Access_RoleMenuMap",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowEdit",
                table: "Access_RoleMenuMap",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowView",
                table: "Access_RoleMenuMap",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Access_MenuContrlrActionMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllowViewType = table.Column<bool>(type: "bit", nullable: false),
                    AllowCreateType = table.Column<bool>(type: "bit", nullable: false),
                    AllowEditType = table.Column<bool>(type: "bit", nullable: false),
                    AllowDeleteType = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access_MenuContrlrActionMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Access_MenuContrlrActionMap_Access_Menu_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Access_Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Access_MenuContrlrActionMap_MenuID",
                table: "Access_MenuContrlrActionMap",
                column: "MenuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Access_MenuContrlrActionMap");

            migrationBuilder.DropColumn(
                name: "AllowCreate",
                table: "Access_RoleMenuMap");

            migrationBuilder.DropColumn(
                name: "AllowDelete",
                table: "Access_RoleMenuMap");

            migrationBuilder.DropColumn(
                name: "AllowEdit",
                table: "Access_RoleMenuMap");

            migrationBuilder.DropColumn(
                name: "AllowView",
                table: "Access_RoleMenuMap");
        }
    }
}
