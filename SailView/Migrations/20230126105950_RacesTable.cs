using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SailView.Migrations
{
    public partial class RacesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Race",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "BoatDetail",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 26, 10, 59, 50, 73, DateTimeKind.Local).AddTicks(3028));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Race");

            migrationBuilder.UpdateData(
                table: "BoatDetail",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 24, 19, 0, 21, 310, DateTimeKind.Local).AddTicks(7984));
        }
    }
}
