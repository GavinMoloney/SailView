using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SailView.Migrations
{
    public partial class SailingMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoatDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SailNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoatType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    BoatDetailsId = table.Column<int>(type: "int", nullable: true),
                    RacePosition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Race_BoatDetail_BoatDetailsId",
                        column: x => x.BoatDetailsId,
                        principalTable: "BoatDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Race_BoatDetailsId",
                table: "Race",
                column: "BoatDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "BoatDetail");
        }
    }
}
