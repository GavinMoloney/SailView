using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SailView.Migrations
{
    public partial class Inseerts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BoatDetail",
                columns: new[] { "Id", "BoatName", "BoatType", "CreatedDate", "SailNumber" },
                values: new object[] { 1, "Asterix", "1720", new DateTime(2022, 11, 24, 20, 15, 10, 902, DateTimeKind.Local).AddTicks(8598), "IRL123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BoatDetail",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
