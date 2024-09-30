using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityProject.Migrations
{
    public partial class menus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Access_MainMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainMenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Access_SubMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubMenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    MainMenuId = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    OrderBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access_SubMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Access_SubMenu_Access_MainMenu_MainMenuId",
                        column: x => x.MainMenuId,
                        principalTable: "Access_MainMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Access_SubMenu_db_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "db_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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


            //migrationBuilder.InsertData(table: "Access_MainMenu", 
               // columns: new[] { "MainMenu", "CreatedDate", "CreatedBy", "Enabled", "OrderBy" }
           // , values:new object[,] { { "AccessMgmnt" },{ DateTime.Now },{1},{true},{0}});

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Access_SubMenu");

            migrationBuilder.DropTable(
                name: "Access_MainMenu");
        }
    }
}
