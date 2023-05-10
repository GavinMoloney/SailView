using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SailView.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Race_BoatDetail_BoatDetailsId",
                table: "Race");

            migrationBuilder.DropIndex(
                name: "IX_Race_BoatDetailsId",
                table: "Race");

            migrationBuilder.RenameColumn(
                name: "BoatDetailsId",
                table: "Race",
                newName: "BoatDetailsID");

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

            migrationBuilder.UpdateData(
                table: "BoatDetail",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 9, 9, 42, 1, 861, DateTimeKind.Local).AddTicks(7420));

            migrationBuilder.CreateIndex(
                name: "IX_BoatDetailsRaces_RaceId",
                table: "BoatDetailsRaces",
                column: "RaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoatDetailsRaces");

            migrationBuilder.RenameColumn(
                name: "BoatDetailsID",
                table: "Race",
                newName: "BoatDetailsId");

            migrationBuilder.UpdateData(
                table: "BoatDetail",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 26, 18, 56, 0, 270, DateTimeKind.Local).AddTicks(4025));

            migrationBuilder.CreateIndex(
                name: "IX_Race_BoatDetailsId",
                table: "Race",
                column: "BoatDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Race_BoatDetail_BoatDetailsId",
                table: "Race",
                column: "BoatDetailsId",
                principalTable: "BoatDetail",
                principalColumn: "Id");
        }
    }
}
