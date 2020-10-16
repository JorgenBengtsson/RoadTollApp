using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoadTollAPI.Migrations
{
    public partial class AddToll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tolls",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(nullable: false),
                    currentCarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tolls", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tolls_Cars_currentCarId",
                        column: x => x.currentCarId,
                        principalTable: "Cars",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tolls_currentCarId",
                table: "Tolls",
                column: "currentCarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tolls");
        }
    }
}
