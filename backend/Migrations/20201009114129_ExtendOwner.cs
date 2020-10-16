using Microsoft.EntityFrameworkCore.Migrations;

namespace RoadTollAPI.Migrations
{
    public partial class ExtendOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "adress",
                table: "Owners",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "Owners",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adress",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "age",
                table: "Owners");
        }
    }
}
