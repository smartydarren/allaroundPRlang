using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DInventory_MVCApplication.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Masters");

            migrationBuilder.CreateTable(
                name: "BusParents",
                schema: "Masters",
                columns: table => new
                {
                    BusParentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusParentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BusParentShortName = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusParents", x => x.BusParentID);
                });

            migrationBuilder.CreateTable(
                name: "BusChildren",
                schema: "Masters",
                columns: table => new
                {
                    BusChildID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusParentID = table.Column<int>(type: "int", nullable: false),
                    BusChildName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BusChildShortName = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusChildren", x => x.BusChildID);
                    table.ForeignKey(
                        name: "FK_BusChildren_BusParents_BusParentID",
                        column: x => x.BusParentID,
                        principalSchema: "Masters",
                        principalTable: "BusParents",
                        principalColumn: "BusParentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusChildren_BusParentID",
                schema: "Masters",
                table: "BusChildren",
                column: "BusParentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusChildren",
                schema: "Masters");

            migrationBuilder.DropTable(
                name: "BusParents",
                schema: "Masters");
        }
    }
}
