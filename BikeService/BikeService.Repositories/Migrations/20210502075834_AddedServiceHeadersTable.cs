using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeService.Repositories.Migrations
{
    public partial class AddedServiceHeadersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kilometers = table.Column<double>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    BikeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceHeaders_Bikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHeaders_BikeId",
                table: "ServiceHeaders",
                column: "BikeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceHeaders");
        }
    }
}
