using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeService.Repositories.Migrations
{
    public partial class addedTableBike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Style = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Kilometers = table.Column<double>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_UserId",
                table: "Bikes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bikes");
        }
    }
}
