using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityProject.Migrations
{
    public partial class product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Master_Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Master_Product_db_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "db_Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Master_Product_db_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "db_Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Master_Product_CreatedBy",
                table: "Master_Product",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Master_Product_UpdatedBy",
                table: "Master_Product",
                column: "UpdatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Master_Product");
        }
    }
}
