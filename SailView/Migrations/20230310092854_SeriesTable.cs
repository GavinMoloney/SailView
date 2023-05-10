using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SailView.Migrations
{
    public partial class SeriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeriesId",
                table: "Race",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Race_SeriesId",
                table: "Race",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Race_Series_SeriesId",
                table: "Race",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Race_Series_SeriesId",
                table: "Race");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Race_SeriesId",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "SeriesId",
                table: "Race");
        }
    }
}
