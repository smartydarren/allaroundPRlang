using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityProject.Migrations
{
    public partial class role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "db_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<byte>(type: "tinyint", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_db_Roles_CreatedBy",
                table: "db_Roles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_db_Roles_UpdatedBy",
                table: "db_Roles",
                column: "UpdatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "db_Roles");

            
        }
    }
}
