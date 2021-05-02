using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeService.Repositories.Migrations
{
    public partial class AddedServiceShoppingCartsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeId = table.Column<int>(nullable: false),
                    ServiceTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceShoppingCarts_Bikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceShoppingCarts_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceShoppingCarts_BikeId",
                table: "ServiceShoppingCarts",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceShoppingCarts_ServiceTypeId",
                table: "ServiceShoppingCarts",
                column: "ServiceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceShoppingCarts");
        }
    }
}
