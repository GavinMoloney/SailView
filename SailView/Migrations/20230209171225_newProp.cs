using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SailView.Migrations
{
    public partial class newProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowBoatDetails",
                table: "Race",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "BoatDetail",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 9, 17, 12, 25, 411, DateTimeKind.Local).AddTicks(2138));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowBoatDetails",
                table: "Race");

            migrationBuilder.UpdateData(
                table: "BoatDetail",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 9, 9, 42, 1, 861, DateTimeKind.Local).AddTicks(7420));
        }
    }
}
