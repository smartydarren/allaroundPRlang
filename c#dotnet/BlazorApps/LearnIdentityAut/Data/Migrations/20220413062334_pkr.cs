using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnIdentityAut.Data.Migrations
{
    public partial class pkr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageIDRef",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_LanguageIDRef",
                table: "Books",
                column: "LanguageIDRef");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Language_LanguageIDRef",
                table: "Books",
                column: "LanguageIDRef",
                principalTable: "Language",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Language_LanguageIDRef",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropIndex(
                name: "IX_Books_LanguageIDRef",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LanguageIDRef",
                table: "Books");
        }
    }
}
