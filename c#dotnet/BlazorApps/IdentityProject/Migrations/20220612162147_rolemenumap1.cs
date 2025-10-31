using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityProject.Migrations
{
    public partial class rolemenumap1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Access_RoleMenuMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    BatchNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access_RoleMenuMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Access_RoleMenuMap_Access_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Access_Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Access_RoleMenuMap_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Access_RoleMenuMap_AspNetUsers_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Access_RoleMenuMap_MenuId",
                table: "Access_RoleMenuMap",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Access_RoleMenuMap_ModifiedBy",
                table: "Access_RoleMenuMap",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Access_RoleMenuMap_RoleId_MenuId",
                table: "Access_RoleMenuMap",
                columns: new[] { "RoleId", "MenuId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Access_RoleMenuMap");
        }
    }
}
