using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SailView.Migrations
{
    public partial class NewProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FinishingStatus",
                table: "BoatRace",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishingStatus",
                table: "BoatRace");
        }
    }
}
