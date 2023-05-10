using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SailView.Migrations
{
    public partial class removecollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoatRace_BoatRace_BoatRacesBoatId_BoatRacesRaceId",
                table: "BoatRace");

            migrationBuilder.DropIndex(
                name: "IX_BoatRace_BoatRacesBoatId_BoatRacesRaceId",
                table: "BoatRace");

            migrationBuilder.DropColumn(
                name: "BoatRacesBoatId",
                table: "BoatRace");

            migrationBuilder.DropColumn(
                name: "BoatRacesRaceId",
                table: "BoatRace");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoatRacesBoatId",
                table: "BoatRace",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BoatRacesRaceId",
                table: "BoatRace",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoatRace_BoatRacesBoatId_BoatRacesRaceId",
                table: "BoatRace",
                columns: new[] { "BoatRacesBoatId", "BoatRacesRaceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BoatRace_BoatRace_BoatRacesBoatId_BoatRacesRaceId",
                table: "BoatRace",
                columns: new[] { "BoatRacesBoatId", "BoatRacesRaceId" },
                principalTable: "BoatRace",
                principalColumns: new[] { "BoatId", "RaceId" });
        }
    }
}
