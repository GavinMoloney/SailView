using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SailView.Migrations
{
    public partial class _3rdTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoatDetailsRaces");

            migrationBuilder.DeleteData(
                table: "BoatDetail",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "BoatRace",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    BoatId = table.Column<int>(type: "int", nullable: false),
                    TimingRecord = table.Column<TimeSpan>(type: "time", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatRace", x => new { x.BoatId, x.RaceId });
                    table.ForeignKey(
                        name: "FK_BoatRace_BoatDetail_BoatId",
                        column: x => x.BoatId,
                        principalTable: "BoatDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoatRace_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoatRace_RaceId",
                table: "BoatRace",
                column: "RaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoatRace");

            migrationBuilder.CreateTable(
                name: "BoatDetailsRaces",
                columns: table => new
                {
                    BoatDetailsId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatDetailsRaces", x => new { x.BoatDetailsId, x.RaceId });
                    table.ForeignKey(
                        name: "FK_BoatDetailsRaces_BoatDetail_BoatDetailsId",
                        column: x => x.BoatDetailsId,
                        principalTable: "BoatDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoatDetailsRaces_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BoatDetail",
                columns: new[] { "Id", "BoatName", "BoatType", "CreatedDate", "SailNumber" },
                values: new object[] { 1, "Asterix", "1720", new DateTime(2023, 2, 9, 17, 12, 25, 411, DateTimeKind.Local).AddTicks(2138), "IRL123" });

            migrationBuilder.CreateIndex(
                name: "IX_BoatDetailsRaces_RaceId",
                table: "BoatDetailsRaces",
                column: "RaceId");
        }
    }
}
