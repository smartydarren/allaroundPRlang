using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityProject.Migrations
{
    public partial class iden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Access_SubMenu");

            migrationBuilder.DropTable(
                name: "db_Roles");

            migrationBuilder.DropTable(
                name: "Access_MainMenu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Access_MainMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    MainMenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access_MainMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Access_MainMenu_db_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "db_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "db_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_db_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_db_Roles_db_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "db_Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_db_Roles_db_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "db_Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Access_SubMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    MainMenuId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    OrderBy = table.Column<int>(type: "int", nullable: true),
                    SubMenu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access_SubMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Access_SubMenu_Access_MainMenu_MainMenuId",
                        column: x => x.MainMenuId,
                        principalTable: "Access_MainMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Access_SubMenu_db_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "db_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Access_MainMenu_CreatedBy",
                table: "Access_MainMenu",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Access_SubMenu_CreatedBy",
                table: "Access_SubMenu",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Access_SubMenu_MainMenuId",
                table: "Access_SubMenu",
                column: "MainMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_db_Roles_CreatedBy",
                table: "db_Roles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_db_Roles_UpdatedBy",
                table: "db_Roles",
                column: "UpdatedBy");
        }
    }
}
